using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAnimator : MonoBehaviour
{
    PController myPController;

    private void Awake()
    {
        myPController = GetComponent<PController>();
    }

    private void Update()
    {
        if(myPController.CheckAvailable())
        {
            if (myPController.moveDirection < 0)
            {
                myPController.faceLeft = true;
            }
            else if (myPController.moveDirection > 0)
            {
                myPController.faceLeft = false;
            }
        }

        if(myPController.onWall)
        {
            if (myPController.checkWallFront)
                myPController.faceLeft = false;
            else
                myPController.faceLeft = true;
        }

        if(myPController.faceLeft)
            transform.localScale = new Vector3(-0.4f, 0.4f, 1);
        else
            transform.localScale = new Vector3(0.4f, 0.4f, 1);

        myPController.myAnimator.SetBool("idle", myPController.idle);
        myPController.myAnimator.SetBool("run", myPController.run);
        myPController.myAnimator.SetBool("onWall", myPController.onWall);
        myPController.myAnimator.SetBool("parry", myPController.parry);
    }
}
