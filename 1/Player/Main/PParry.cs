using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PParry : MonoBehaviour
{
    PController myPController;

    private void Awake()
    {
        myPController = GetComponent<PController>();
    }

    [SerializeField]
    private float parryLenght;

    private float parryTime;

    private void Update()
    {
        if(myPController.parry)
        {
            parryTime -= Time.deltaTime;
        }

        if(parryTime > 0)
        {
            myPController.parry = true;
        }
        else
        {
            myPController.parry = false;
        }

        if(myPController.startParry)
        {
            if(myPController.CheckAvailable())
            {
                myPController.myAnimator.SetTrigger("preParry");
                parryTime = parryLenght;
            }
            myPController.startParry = false;
        }
    }
}
