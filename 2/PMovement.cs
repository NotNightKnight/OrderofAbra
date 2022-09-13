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

    private void FixedUpdate()
    {
        if(myPController.groundCheck)
        {
            myPController.myRigidbody2D.velocity = new Vector2(myPController.moveDirection * myPController.movementSpeed, myPController.myRigidbody2D.velocity.y);
        }
    }
}
