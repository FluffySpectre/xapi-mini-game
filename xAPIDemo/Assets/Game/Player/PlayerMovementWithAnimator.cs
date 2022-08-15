using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWithAnimator : MonoBehaviour
{
    public float MovementSpeed = 1f;
    public float RunningMultiplicator = 2.5f;
    [SerializeField] private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        movementInput *= MovementSpeed;

        if (movementInput != Vector3.zero)
        {
            // running?
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movementInput *= RunningMultiplicator;
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

            playerAnimator.SetFloat("MoveSpeed", movementInput.magnitude);
        }
    }
}
