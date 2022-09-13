using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCheck : MonoBehaviour
{
    PController myPController;
    private void Awake()
    {
        myPController = GetComponent<PController>();
    }

    private void Update()
    {
        CheckGround();
        CheckWall();
        myPController.checkGroundTimer -= Time.deltaTime;
    }

    void CheckGround()
    {
        RaycastHit2D raycastGround = Physics2D.Raycast(myPController.myCircleCollider2D.bounds.center, Vector2.down, myPController.checkDistanceGround + myPController.myCircleCollider2D.bounds.extents.y, myPController.layerMaskGround);

        if (raycastGround)
            myPController.checkGround = true;
        else
            myPController.checkGround = false;
    }

    void CheckWall()
    {
        RaycastHit2D raycastWallFront = Physics2D.Raycast(myPController.myBoxCollider2D.bounds.center, Vector2.right, myPController.checkWallDistance + myPController.myBoxCollider2D.bounds.extents.x, myPController.layerMaskGround);
        RaycastHit2D raycastWallBack = Physics2D.Raycast(myPController.myBoxCollider2D.bounds.center, Vector2.left, myPController.checkWallDistance + myPController.myBoxCollider2D.bounds.extents.x, myPController.layerMaskGround);

        if(raycastWallFront)
        {
            myPController.checkWallFront = true;
        }
        else if(raycastWallBack)
        {
            myPController.checkWallBack = true;
        }
        else
        {
            myPController.checkWallFront = false;
            myPController.checkWallBack = false;
        }
    }
}
