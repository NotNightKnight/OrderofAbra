using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    EnemyController EnemyController;
    GameObject Player;
    PlayerController PlayerController;
    private void Awake()
    {
        EnemyController = GetComponent<EnemyController>();
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerController = Player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (PlayerController.attackState)
            {
                PlayerController.lastExp = 200;
                PlayerController.expGained = true;
                gameObject.SetActive(false);
            }
        }
    }
}
