using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EnemyController EnemyController;
    private void Awake()
    {
        EnemyController = GetComponent<EnemyController>();
    }

    private void Update()
    {
        if(EnemyController.attack == false && EnemyController.attackEnd)
        {
            if (EnemyController.limit1.x < transform.position.x && transform.position.x < EnemyController.limit2.x)
            {
                if(EnemyController.playerInRange)
                {
                    if (EnemyController.faceLeft)
                    {
                        if (transform.position.x > EnemyController.limit1.x + 0.1f)
                        {
                            transform.position -= transform.right * (EnemyController.MovementSpeed * Time.deltaTime);
                        }
                    }
                    if (EnemyController.faceLeft == false)
                    {
                        if (transform.position.x < EnemyController.limit2.x - 0.1f)
                        {
                            transform.position += transform.right * (EnemyController.MovementSpeed * Time.deltaTime);
                        }
                    }
                }
                else
                {
                    if(EnemyController.faceLeft)
                    {
                        if (transform.position.x > EnemyController.limit1.x + 0.1f)
                        {
                            transform.position -= transform.right * (EnemyController.MovementSpeed * Time.deltaTime);
                            if (transform.position.x <= EnemyController.limit1.x + 1f)
                                EnemyController.faceLeft = false;
                        }
                    }
                    if(EnemyController.faceLeft == false)
                    {
                        if (transform.position.x < EnemyController.limit2.x - 0.1f)
                        {
                            transform.position += transform.right * (EnemyController.MovementSpeed * Time.deltaTime);
                            if (transform.position.x >= EnemyController.limit2.x - 1f)
                                EnemyController.faceLeft = true;
                        }
                    }
                }
            }
        }
    }
}