using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunClimb : MonoBehaviour
{
    PController myPController;

    private void Awake()
    {
        myPController = GetComponent<PController>();
    }

    Vector3 targetLocation;

    private void Update()
    {
        if(myPController.startGunClimb)
        {
            if(myPController.checkGunClimb)
            {
                myPController.gunClimb1 = true;

                targetLocation = transform.position + new Vector3(7f, 9f, 0f);
            }
            myPController.startGunClimb = false;
        }

        if (myPController.gunClimb1)
        {
            if (myPController.CheckAvailable())
            {
                transform.position = Vector2.MoveTowards(transform.position, targetLocation, 0.7f * Time.time);
            }
            if (Mathf.Abs(targetLocation.x - transform.position.x) < 0.1f)
            {
                myPController.gunClimb1 = false;
            }
        }
    }
}
