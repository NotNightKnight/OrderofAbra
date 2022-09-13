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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerController.pressedKey = "left";
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerController.pressedKey = "right";
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerController.pressedKey = "stop";
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) | Input.GetKeyUp(KeyCode.RightArrow))
        {
            PlayerController.pressedKey = "stop";
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerController.jumping = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            PlayerController.jumping = false;
        }

        Debug.Log(PlayerController.grounded);
    }
}
