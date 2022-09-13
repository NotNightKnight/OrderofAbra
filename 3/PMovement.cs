using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    PController myPController;
    private void Awake()
    {
        myPController = GetComponent<PController>();
    }

    private void Update()
    {
        if(myPController.myRigidbody2D.velocity.x == 0)
        {
            myPController.run = false;
        }
        else
        {
            myPController.run = true;
        }
    }

    private void FixedUpdate()
    {
        if(myPController.checkGround)
        {
            myPController.myRigidbody2D.velocity = new Vector2(myPController.moveDirection * myPController.movementSpeed, myPController.myRigidbody2D.velocity.y);
        }
    }
}
