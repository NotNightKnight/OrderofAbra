using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    EnemyController EnemyController;

    private void Awake()
    {
        EnemyController = GetComponent<EnemyController>();
    }

    private void Update()
    {
        EnemyController.Animator.SetBool("attack", EnemyController.attack);
        EnemyController.Animator.SetBool("death", EnemyController.death);

        if(EnemyController.playerInRange)
        {
            if (EnemyController.playerTransform.position.x < transform.position.x)
            {
                EnemyController.faceLeft = true;
            }
            if (EnemyController.playerTransform.position.x > transform.position.x)
            {
                EnemyController.faceLeft = false;
            }
        }
        if (EnemyController.faceLeft == true)
        {
            transform.localScale = EnemyController.scaleLeft;
        }
        if (EnemyController.faceLeft == false)
        {
            transform.localScale = EnemyController.scaleRight;
        }
    }
}
