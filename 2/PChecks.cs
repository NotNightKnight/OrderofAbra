using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PChecks : MonoBehaviour
{
    PController myPController;
    private void Awake()
    {
        myPController = GetComponent<PController>();
    }

    private void Update()
    {
        GroundCheck();
    }

    void GroundCheck()
    {
        RaycastHit2D rayCastHit2D = Physics2D.Raycast(myPController.myCircleCollider2D.bounds.center, Vector2.down, myPController.groundCheckDistance + myPController.myCircleCollider2D.bounds.extents.y, myPController.groundLayerMask);
        if(rayCastHit2D)
        {
            myPController.groundCheck = true;
        }
        else
        {
            myPController.groundCheck = false;
        }
        Debug.Log(myPController.groundCheck);
    }
}
