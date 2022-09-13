using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPoint : MonoBehaviour
{
    //PController myPController;

    //private GameObject[] myGunPoints;

    //private GameObject myGunPoint;

    //private void Awake()
    //{
    //    myPController = GetComponent<PController>();

    //    myGunPoints = GameObject.FindGameObjectsWithTag("GunPoints");
    //}

    //private void FixedUpdate()
    //{
    //    if(myPController.startGunClimb)
    //    {
    //        if(myPController.CheckAvailable())
    //        {
    //            myGunPoint = FindNearest();

    //            transform.position = Vector2.MoveTowards(transform.position, myGunPoint.transform.position, 1f * Time.time);
    //            Debug.Log("Yeahhh");
    //        }
    //        if (Mathf.Abs(myGunPoint.transform.position.x - transform.position.x) < 0.1f)
    //        {
    //            myPController.startGunClimb = false;
    //        }
    //    }
    //}

    //private GameObject FindNearest()
    //{
    //    GameObject nearest = myGunPoints[0];
    //    foreach(GameObject gunpoint in myGunPoints)
    //    {
    //        if(Mathf.Abs(gunpoint.transform.position.x - transform.position.x) < Mathf.Abs(nearest.transform.position.x - transform.position.x))
    //        {
    //            nearest = gunpoint;
    //        }
    //    }
    //    return nearest;
    //}
}
