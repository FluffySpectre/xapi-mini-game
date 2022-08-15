using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 1f;
    public float RunningMultiplicator = 2.5f;
    [SerializeField] private Animator playerAnimator;

    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Vector3 movementInput = new Vector3(0f, 0f, 0f);
        if (Input.GetKey(KeyCode.W))
        {
            movementInput.z = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementInput.z = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementInput.x = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementInput.x = -1f;
        }

        movementInput *= MovementSpeed;

        // jumping?
        if (isJumping)
        {
            if (transform.position.y > 0f)
            {
                playerAnimator.SetBool("InAir", true);
            }
            else
            {
                playerAnimator.SetBool("InAir", false);
                isJumping = false;
            }
        }

        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("Jump");
            isJumping = true;
        }

        if (movementInput != Vector3.zero)
        {
            // running?
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movementInput *= RunningMultiplicator;

                playerAnimator.SetBool("IsWalking", false);
                playerAnimator.SetBool("IsRunning", true);
            }
            else
            {
                playerAnimator.SetBool("IsRunning", false);
                playerAnimator.SetBool("IsWalking", true);
            }

            // turning left?
            if (movementInput.x < 0f)
            {
                playerAnimator.SetBool("TurnRight", false);
                playerAnimator.SetBool("TurnLeft", true);
            }
            else if (movementInput.x > 0f)
            {
                playerAnimator.SetBool("TurnLeft", false);
                playerAnimator.SetBool("TurnRight", true);
            }
            else
            {
                playerAnimator.SetBool("TurnRight", false);
                playerAnimator.SetBool("TurnLeft", false);
            }
        }
        else
        {
            playerAnimator.SetBool("IsRunning", false);
            playerAnimator.SetBool("IsWalking", false);
            playerAnimator.SetBool("TurnRight", false);
            playerAnimator.SetBool("TurnLeft", false);
        }
    }
}
