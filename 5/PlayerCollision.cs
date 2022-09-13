using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    PlayerController PlayerController;
    EnemyController EnemyController;

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
            PlayerController.grounded = true;
        if (collision.gameObject.CompareTag("Death"))
            PlayerController.death = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
            PlayerController.grounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ladder"))
            PlayerController.ladder = true;
        if (collision.gameObject.CompareTag("ladderEE"))
            PlayerController.ladderEE = true;
        if (collision.gameObject.CompareTag("enemy"))
        {
            EnemyController = collision.GetComponent<EnemyController>();
            if(EnemyController.attackState == true && PlayerController.invulnerable == false)
            {
                if (PlayerController.injured)
                    PlayerController.death = true;
                else
                    PlayerController.injured = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ladder"))
            PlayerController.ladder = false;
        if (collision.gameObject.CompareTag("ladderEE"))
            PlayerController.ladderEE = false;
    }
}
