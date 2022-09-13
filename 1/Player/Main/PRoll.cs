using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRoll : MonoBehaviour
{
    PController myPController;

    private void Awake()
    {
        myPController = GetComponent<PController>();
    }

    [SerializeField]
    private float rollSpeed;

    private void Update()
    {
        if(myPController.roll)
        {
            Physics2D.IgnoreLayerCollision(layer1: 7, layer2: 6, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(layer1: 7, layer2: 6, false);
        }
    }

    private void FixedUpdate()
    {
        if(myPController.startRoll)
        {
            if(myPController.CheckAvailable())
            {
                if(myPController.idle)
                {
                    myPController.myAnimator.SetTrigger("roll");
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
                else
                {
                    myPController.myAnimator.SetTrigger("roll");
                    myPController.movementRoll = true;
                }
            }
            myPController.startRoll = false;
        }
    }
}
