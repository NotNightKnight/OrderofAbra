using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    PController myPController;

    private void Awake()
    {
        myPController = GetComponent<PController>();
    }

    private void Update()
    {
        if(myPController.startAttack1)
        {
            if(myPController.CheckAvailable())
            {
                myPController.myAnimator.SetTrigger("attack1");
            }
            myPController.startAttack1 = false;

            transform.position += new Vector3(0.001f, 0, 0);
        }
        else if (myPController.startAttack2)
        {
            if (myPController.CheckAvailable())
            {
                myPController.myAnimator.SetTrigger("attack2");
            }
            myPController.startAttack2 = false;

            transform.position += new Vector3(0.001f, 0, 0);
        }
        else if (myPController.startAttack3)
        {
            if (myPController.CheckAvailable())
            {
                myPController.myAnimator.SetTrigger("attack3");
            }
            myPController.startAttack3 = false;

            transform.position += new Vector3(0.001f, 0, 0);
        }

        if (myPController.attack)
        {
            myPController.myAttackArea.SetActive(true);
        }
        else
        {
            myPController.myAttackArea.SetActive(false);
        }
    }
}
