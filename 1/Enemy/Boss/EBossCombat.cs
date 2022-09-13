using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBossCombat : MonoBehaviour
{
    public EBossController myEBossController;

    private void Update()
    {
        if (myEBossController.searchPlayer)
        {
            if(myEBossController.death == false)
            {
                float distance = Mathf.Abs(transform.position.x - myEBossController.Player.transform.position.x);

                if (Mathf.Abs(distance) < 5f)
                {
                    myEBossController.myAnimator.SetBool("attack", true);
                    myEBossController.attack = true;
                }
            }
        }

        if(myEBossController.attack)
        {
            
        }
        else if(myEBossController.attack == false)
        {
            myEBossController.BossAttackArea.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PAttackArea"))
        {
            myEBossController.Die();
        }
    }
}
