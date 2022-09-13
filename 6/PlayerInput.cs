using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerController.buttonPressed = "left";
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerController.buttonPressed = "right";
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerController.buttonPressed = "stop";
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) | Input.GetKeyUp(KeyCode.RightArrow))
        {
            PlayerController.buttonPressed = "stop";
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerController.isJumping = true;
        }
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            PlayerController.isJumping = false;
        }
    }
}
