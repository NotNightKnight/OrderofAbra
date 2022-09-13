using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJump : MonoBehaviour
{
    PController myPController;

    private void Awake()
    {
        myPController = GetComponent<PController>();
    }

    //VARIABLES
    public float jumpSpeed;
    public float directionalJumpSpeed;

    private void FixedUpdate()
    {
        if(myPController.startJump)
        {
            if(myPController.checkGround)
            {
                if (myPController.CheckAvailable())
                {
                    Vector2 jumpVector = new Vector2(myPController.myRigidbody2D.velocity.x, jumpSpeed);
                    myPController.myRigidbody2D.velocity = jumpVector;

                    myPController.myAnimator.SetTrigger("jump");
                }
            }
            else if(myPController.onWall)
            {
                if(myPController.moveDirection > 0)
                {
                    Vector2 jumpVector = new Vector2(directionalJumpSpeed, jumpSpeed);
                    myPController.myRigidbody2D.velocity = jumpVector;

                    myPController.myAnimator.SetTrigger("wallJump");
                }
                else if(myPController.moveDirection == 0)
                {
                    Vector2 jumpVector = new Vector2(0, jumpSpeed);
                    myPController.myRigidbody2D.velocity = jumpVector;

                    myPController.myAnimator.SetTrigger("wallJump");
                }
                else
                {
                    Vector2 jumpVector = new Vector2(-directionalJumpSpeed, jumpSpeed);
                    myPController.myRigidbody2D.velocity = jumpVector;

                    myPController.myAnimator.SetTrigger("wallJump");
                }
            }
            myPController.startJump = false;
        }
    }
}
