using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCheck : MonoBehaviour
{
    PController myPController;

    private void Awake()
    {
        myPController = GetComponent<PController>();
        myParticleSystem = myPController.ParticleGameObject.GetComponent<ParticleSystem>();
    }

    //COMPONENTS
    public BoxCollider2D myBoxCollider2D;
    public CircleCollider2D myCircleCollider2D;

    //VARIABLES
    public float CheckGroundDistance;
    public float CheckWallDistance;
    public float CheckSlopeDistance;

    public ParticleSystem myParticleSystem
    { get; set; }

    public LayerMask layerMaskGround;

    private void Update()
    {
        CheckGround();
        CheckWall();

        if(myPController.checkGround == false)
        {
            if(myPController.checkWallFront | myPController.checkWallBack)
            {
                myPController.onWall = true;

                //myPController.myRigidbody2D.velocity = new Vector2(myPController.myRigidbody2D.velocity.x, -0.4f);

                myPController.ParticleGameObject.transform.position = transform.position + Vector3.down * 2f;
                myParticleSystem.Play();
            }
            else
            {
                myPController.onWall = false;

                myParticleSystem.Clear();
                myParticleSystem.Pause();
            }
        }
        else if(myPController.checkGround)
        {
            myPController.onWall = false;
        }

        if(myPController.startDrop)
        {
            if(myPController.onWall)
            {
                CheckWallDistance = 0f;
            }
            myPController.startDrop = false;
        }

        if(myPController.checkGround)
        {
            CheckWallDistance = 0.3f;
        }
    }

    private void CheckGround()
    {
        RaycastHit2D raycastGround = Physics2D.BoxCast(myCircleCollider2D.bounds.center, myCircleCollider2D.bounds.size, 0f, Vector2.down, CheckGroundDistance, layerMaskGround);
        if (raycastGround)
            myPController.checkGround = true;
        else
            myPController.checkGround = false;
    }

    private void CheckWall()
    {
        RaycastHit2D raycastFront = Physics2D.Raycast(myBoxCollider2D.bounds.center, Vector2.right, CheckWallDistance + myBoxCollider2D.bounds.extents.x, layerMaskGround);
        RaycastHit2D raycastBack = Physics2D.Raycast(myBoxCollider2D.bounds.center, Vector2.left, CheckWallDistance + myBoxCollider2D.bounds.extents.x, layerMaskGround);

        if (raycastFront)
        {
            myPController.checkWallFront = true;
        }
        else if (raycastBack)
        {
            myPController.checkWallBack = true;
        }
        else
        {
            myPController.checkWallBack = false;
            myPController.checkWallFront = false;
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("GunPointArea1"))
        {
            myPController.checkGunClimb = true;

            myPController.myUIPointer.SetActive(true);
            myPController.myUIPointer.transform.position += new Vector3(340, 495, 0);
        }

        if(collision.gameObject.CompareTag("DeathZone"))
        {
            myPController.death = true;
            myPController.myAnimator.SetTrigger("die");
        }

        if(collision.gameObject.CompareTag("CombatArea1"))
        {
            myPController.EnemyAndroid.GetComponent<EController>().StartSearching();
        }
        if (collision.gameObject.CompareTag("CombatArea2"))
        {
            myPController.EnemyBoss.GetComponent<EBossController>().SearchPlayer();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GunPointArea1"))
        {
            myPController.myUIPointer.transform.position -= new Vector3(340, 495, 0);
            myPController.myUIPointer.SetActive(false);
            myPController.checkGunClimb = false;
        }

        if (collision.gameObject.CompareTag("CombatArea1"))
        {
            myPController.EnemyAndroid.GetComponent<EController>().StopSearching();
        }
    }
}
