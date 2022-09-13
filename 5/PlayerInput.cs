using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(PlayerController.climb == false)
        {
            if (Input.GetKeyDown(PlayerController.leftKeyCode) && (PlayerController.parry == false) && (PlayerController.attack == false))
            {
                PlayerController.prevPresKey = PlayerController.pressedKey;
                PlayerController.timeSinceLastClick = Time.time - PlayerController.lastClickTime;
                if (PlayerController.prevPresKey == "left" && PlayerController.dash == false)
                {
                    if (PlayerController.timeSinceLastClick < PlayerController.doubleClickTime)
                    {
                        PlayerController.dash = true;
                        PlayerController.dashMov = true;
                        PlayerController.dashDirection = "left";
                    }
                }

                PlayerController.pressedKey = "left";
                PlayerController.run = true;
                PlayerController.faceLeft = true;

                PlayerController.lastClickTime = Time.time;
            }
            if (Input.GetKeyDown(PlayerController.rightKeyCode) && (PlayerController.parry == false) && (PlayerController.attack == false))
            {
                PlayerController.prevPresKey = PlayerController.pressedKey;
                PlayerController.timeSinceLastClick = Time.time - PlayerController.lastClickTime;
                if (PlayerController.prevPresKey == "right" && PlayerController.dash == false)
                {
                    if (PlayerController.timeSinceLastClick < PlayerController.doubleClickTime)
                    {
                        PlayerController.dash = true;
                        PlayerController.dashMov = true;
                        PlayerController.dashDirection = "right";
                    }
                }

                PlayerController.pressedKey = "right";
                PlayerController.run = true;
                PlayerController.faceLeft = false;

                PlayerController.lastClickTime = Time.time;
            }
            if (Input.GetKeyUp(PlayerController.leftKeyCode))
                PlayerController.run = false;
            if (Input.GetKeyUp(PlayerController.rightKeyCode))
                PlayerController.run = false;
            if (Input.GetKeyDown(PlayerController.jumpKeyCode) && (PlayerController.parry == false) && (PlayerController.attack == false))
            {
                if (PlayerController.run)
                    PlayerController.directionalJumping = true;
                else
                    PlayerController.stillJumping = true;
            }
            if (Input.GetKeyDown(PlayerController.attackKeyCode))
            {
                if (PlayerController.attack)
                {
                    PlayerController.attackMov = true;
                }
                PlayerController.attack = true;
            }
            if (Input.GetKeyUp(PlayerController.attackKeyCode))
                PlayerController.attack = false;
            if (Input.GetKeyDown(PlayerController.parryKeyCode))
                PlayerController.parry = true;
            if (Input.GetKeyUp(PlayerController.parryKeyCode))
                PlayerController.parry = false;
        }
    }
}