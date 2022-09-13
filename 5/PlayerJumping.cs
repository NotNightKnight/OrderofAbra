using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if(PlayerController.grounded)
        {
            if(PlayerController.stillJumping)
            {
                Vector2 jump = new Vector2(0f, PlayerController.JumpSpeed);
                PlayerController.Rigidbody2D.AddForce(jump, ForceMode2D.Impulse);
            }
            if(PlayerController.directionalJumping)
            {
                Vector2 leftJump = new Vector2(-PlayerController.DirectionalJumpSpeed, PlayerController.JumpSpeed);
                Vector2 rightJump = new Vector2(PlayerController.DirectionalJumpSpeed, PlayerController.JumpSpeed);
                if (PlayerController.faceLeft)
                    PlayerController.Rigidbody2D.AddForce(leftJump, ForceMode2D.Impulse);
                else
                    PlayerController.Rigidbody2D.AddForce(rightJump, ForceMode2D.Impulse);
            }
        }
    }
}
