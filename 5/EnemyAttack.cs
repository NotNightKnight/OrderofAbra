using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    EnemyController EnemyController;
    CapsuleCollider2D AttackCollider;
    private void Awake()
    {
        EnemyController = GetComponent<EnemyController>();
        AttackCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if(Mathf.Abs(EnemyController.playerTransform.position.x - transform.position.x) < EnemyController.DetectRange && Mathf.Abs(EnemyController.playerTransform.position.y - transform.position.y) < EnemyController.DetectRange)
        {
            EnemyController.playerInRange = true;
        }
        else
        {
            EnemyController.playerInRange = false;
        }
        if (Mathf.Abs(EnemyController.playerTransform.position.x - transform.position.x) < EnemyController.AttackRange && Mathf.Abs(EnemyController.playerTransform.position.y - transform.position.y) < EnemyController.AttackRange)
        {
            EnemyController.attack = true;
            AttackCollider.isTrigger = true;
        }
        else
        {
            EnemyController.attack = false;
            AttackCollider.isTrigger = false;
        }
    }
}