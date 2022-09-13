using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if(PlayerController.buttonPressed == "left")
        {
            if(PlayerController.isJumping && PlayerController.isGrounded)
            {
                PlayerController.Rigidbody.AddForce(new Vector2((-PlayerController.playerMovementSpeed / 8), PlayerController.playerJumpSpeed), ForceMode2D.Impulse);
            }
            else
            {
                transform.position -= transform.right * (Time.deltaTime * PlayerController.playerMovementSpeed);
            }
        }
        if (PlayerController.buttonPressed == "right")
        {
            if (PlayerController.isJumping && PlayerController.isGrounded)
            {
                PlayerController.Rigidbody.AddForce(new Vector2((PlayerController.playerMovementSpeed / 8), PlayerController.playerJumpSpeed), ForceMode2D.Impulse);
            }
            else
            {
                transform.position += transform.right * (Time.deltaTime * PlayerController.playerMovementSpeed);
            }
        }
        if(PlayerController.buttonPressed == "stop")
        {
            if(PlayerController.isJumping && PlayerController.isGrounded)
            {
                PlayerController.Rigidbody.AddForce(new Vector2(0f, PlayerController.playerJumpSpeed), ForceMode2D.Impulse);
            }
        }
    }
}
