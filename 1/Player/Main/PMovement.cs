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

    private void Start()
    {
        tempSpeed = movementSpeed;
    }

    //VARIABLES
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rollSpeed;

    private float tempSpeed;

    private void Update()
    {
        if(myPController.roll)
        {
            movementSpeed = rollSpeed;
        }
        else
        {
            movementSpeed = tempSpeed;
        }

        if (myPController.moveDirection == 0)
        {
            myPController.idle = true;
            myPController.run = false;
        }
        else
        {
            myPController.idle = false;
            myPController.run = true;
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveVector;
        
        if(myPController.checkGround)
        {
            if (myPController.CheckAvailable())
            {
                moveVector = new Vector2(myPController.moveDirection * movementSpeed, myPController.myRigidbody2D.velocity.y);
                myPController.myRigidbody2D.velocity = moveVector;
            }
            else if(myPController.CheckOnlyRoll())
            {
                if (myPController.faceLeft)
                {
                    Vector2 rollVector = new Vector2(-rollSpeed, 0);
                    myPController.myRigidbody2D.velocity = rollVector;
                }
                else
                {
                    Vector2 rollVector = new Vector2(rollSpeed, 0);
                    myPController.myRigidbody2D.velocity = rollVector;
                }
            }
            //else if (myPController.CheckOnlyRoll())
            //{
            //    moveVector = new Vector2(myPController.moveDirection * movementSpeed, myPController.myRigidbody2D.velocity.y);
            //    myPController.myRigidbody2D.velocity = moveVector;
            //}
        }
    }
}
