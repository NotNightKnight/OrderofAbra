using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBossMovement : MonoBehaviour
{
    public EBossController myEBossController;

    private void Update()
    {
        if(myEBossController.searchPlayer)
        {
            if(myEBossController.attack == false)
            {
                float distance = Mathf.Abs(transform.position.x - myEBossController.Player.transform.position.x);

                if (Mathf.Abs(distance) > 5f)
                {
                    if(myEBossController.faceLeft)
                    {
                        myEBossController.myRigidbody2D.velocity = new Vector2(-myEBossController.movementSpeed, 0f);
                        myEBossController.myAnimator.SetBool("idle", false);
                    }
                    else
                    {
                        myEBossController.myRigidbody2D.velocity = new Vector2(myEBossController.movementSpeed, 0f);
                        myEBossController.myAnimator.SetBool("idle", false);
                    }
                }
                else if (Mathf.Abs(distance) < 5f)
                {
                    myEBossController.myRigidbody2D.velocity = Vector2.zero;
                    myEBossController.myAnimator.SetBool("idle", true);
                }
            }
        }
    }
}
