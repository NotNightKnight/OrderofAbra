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

    private void FixedUpdate()
    {
        if(myPController.startJump && myPController.groundCheck)
        {
            myPController.myRigidbody2D.velocity = Vector2.up * myPController.jumpSpeed;
            myPController.startJump = false;
        }
    }
}
