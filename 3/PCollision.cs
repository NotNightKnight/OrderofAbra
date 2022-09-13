using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCollision : MonoBehaviour
{
    PController myPController;
    private void Awake()
    {
        myPController = GetComponent<PController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("climbArea"))
        {
            myPController.myAnimator.SetTrigger("climb");
            if(myPController.faceRight)
            {
                transform.position += new Vector3(1, 1, 0);
            }
            else
            {
                transform.position += new Vector3(-1, -1, 0);
            }
        }
    }
}
