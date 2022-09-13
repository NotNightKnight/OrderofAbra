using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAnim : MonoBehaviour
{
    PController myPController;
    private void Awake()
    {
        myPController = GetComponent<PController>();        
    }

    private void Update()
    {
        if(myPController.moveDirection < 0)
        {
            myPController.faceRight = false;
        }
        else if(myPController.moveDirection > 0)
        {
            myPController.faceRight = true;
        }
        
        if(myPController.faceRight)
        {
            transform.localScale = new Vector3(0.5712767f, 0.5712767f, 0.5712767f);
        }
        else
        {
            transform.localScale = new Vector3(-0.5712767f, 0.5712767f, 0.5712767f);
        }

        myPController.myAnimator.SetBool("run", myPController.run);
        myPController.myAnimator.SetBool("onWall", myPController.onWall);
    }
}
