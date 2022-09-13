using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ECombat : MonoBehaviour
{
    public EController myEController;

    private float shootCD;
    private LayerMask playerLayer;

    private void Awake()
    {
        shootCD = myEController.ShootCoolDown;
        playerLayer = LayerMask.GetMask("Player");
    }

    private void Update()
    {
        if (myEController.searchPlayer)
        {
            myEController.ShootCoolDown -= Time.deltaTime;
            if (myEController.ShootCoolDown < 0)
                Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PAttackArea"))
        {
            myEController.Die();
        }
    }

    private void Shoot()
    {
        myEController.myAnimator.SetTrigger("Shoot");
        myEController.ShootCoolDown = shootCD;

        RaycastHit2D ShootRay = Physics2D.Raycast(myEController.Gun.transform.position, Vector2.right, playerLayer);
        if(ShootRay)
        {
            myEController.myPlayer.GetComponent<PController>().GetHit();
        }
    }
}
