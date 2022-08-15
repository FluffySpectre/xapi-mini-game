using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCharacterController : MonoBehaviour
{
    public float Speed = 10f;
    public float RunSpeedMultiplicator = 2f;
    public float JumpHeight = 2f;
    public float RotateSpeed = 40f;
    public float gravity = -20f;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private CharacterController characterController;

    private bool isGrounded;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool doJump = false;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2 * gravity);
            doJump = true;
        }

        bool doAttack = false;
        if (Input.GetKeyDown(KeyCode.E))
        {
            doAttack = true;
        }

        transform.eulerAngles = new Vector3(0.0f, transform.eulerAngles.y + (x * RotateSpeed * Time.deltaTime), 0.0f);

        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 move = transform.forward * z;

        float runSpeedMulti = 1f;
        if (Input.GetButton("Run"))
        {
            runSpeedMulti = RunSpeedMultiplicator;
        }

        Vector3 motion = move * Speed * runSpeedMulti * Time.deltaTime + velocity * Time.deltaTime;
        // Debug.Log(motion);

        characterController.Move(motion);

        ProcessAnimation(move, x, runSpeedMulti > 1f, doJump, doAttack);
    }

    void ProcessAnimation(Vector3 move, float horizontalInput, bool running, bool jump, bool attack)
    {
        playerAnimator.SetBool("IsGrounded", isGrounded);

        if (jump)
        {
            playerAnimator.SetTrigger("Jump");
        }

        playerAnimator.SetBool("TurnRight", horizontalInput > 0f);
        playerAnimator.SetBool("TurnLeft", horizontalInput < 0f);

        if (move != Vector3.zero)
        {
            playerAnimator.SetBool("IsRunning", running);
            playerAnimator.SetBool("IsWalking", !running);
        }
        else if (horizontalInput != 0f)
        {
            playerAnimator.SetBool("IsRunning", false);
            playerAnimator.SetBool("IsWalking", true);
        }
        else
        {
            playerAnimator.SetBool("IsRunning", false);
            playerAnimator.SetBool("IsWalking", false);
        }

        //Debug.Log("Attack=" + attack);
        if (attack)
        {
            playerAnimator.SetTrigger("Attack");
        }
    }
}
