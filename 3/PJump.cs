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

    private void Update()
    {
        if(myPController.checkGround == false)
        {
            if(myPController.checkWallFront | myPController.checkWallBack)
            {
                myPController.onWall = true;
            }
            else
            {
                myPController.onWall = false;
            }
        }

        if(myPController.onWall)
        {
            myPController.myRigidbody2D.gravityScale = 0;
        }
        else
        {
            myPController.myRigidbody2D.gravityScale = 4;
        }
    }

    private void FixedUpdate()
    {
        if (myPController.startJump)
        {
            myPController.myRigidbody2D.velocity = new Vector2((myPController.myRigidbody2D.velocity.x), myPController.jumpSpeed);
            myPController.startJump = false;
        }
        if(myPController.startWallJump)
        {
            if(myPController.checkWallFront)
            {
                myPController.myRigidbody2D.velocity = new Vector2(-myPController.movementSpeed, myPController.jumpSpeed);
                myPController.faceRight = false;
            }
            else if(myPController.checkWallBack)
            {
                myPController.myRigidbody2D.velocity = new Vector2(myPController.movementSpeed, myPController.jumpSpeed);
                myPController.faceRight = true;
            }
            myPController.startWallJump = false;
        }
    }
}
