using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerController PlayerController;

    CircleCollider2D attackCircle;
    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
        attackCircle = PlayerController.GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if(PlayerController.attackState)
        {
            attackCircle.enabled = true;
            attackCircle.isTrigger = true;
        }
        if(PlayerController.attackState == false)
        {
            attackCircle.enabled = false;
            attackCircle.isTrigger = false;
        }
        if(PlayerController.attackMov)
        {
            if(PlayerController.faceLeft)
            {
                transform.position -= new Vector3(PlayerController.AttackDistance, 0f, 0f);
            }
            else if(PlayerController.faceLeft == false)
            {
                transform.position += new Vector3(PlayerController.AttackDistance, 0f, 0f);
            }
            PlayerController.attackMov = false;
        }
    }
}
