using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        //mov1();
        //mov2();
        //mov3();
        //mov4();
        //mov5();
        //mov6();
        mov7();
    }

    void mov1()
    {
        PlayerController.rb2d.velocity = new Vector2(PlayerController.PlayerMovementSpeed, 0f);
    }
    void mov2()
    {
        PlayerController.rb2d.AddForce(new Vector2(PlayerController.PlayerMovementSpeed, 0f) * Time.deltaTime);
    }
    void mov3()
    {
        PlayerController.rb2d.MovePosition(PlayerController.rb2d.position + new Vector2(PlayerController.PlayerMovementSpeed, 0f) * Time.deltaTime);
    }
    void mov4()
    {
        transform.Translate(new Vector2(1f, 0f) * PlayerController.PlayerMovementSpeed * Time.deltaTime);
    }
    void mov5()
    {
        //transform.position = new Vector2(PlayerController.PlayerMovementSpeed, transform.position.y);
        transform.position = new Vector2(transform.position.x + .1f, transform.position.y);
    }
    void mov6()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(PlayerController.PlayerMovementSpeed, transform.position.y), 1f * Time.deltaTime);
    }
    void mov7()
    {
        if (PlayerController.pressedKey == "left")
        {
            if (PlayerController.jumping && PlayerController.grounded)
            {
                PlayerController.rb2d.AddForce(new Vector2((-PlayerController.PlayerMovementSpeed / 8), PlayerController.PlayerJumpSpeed), ForceMode2D.Impulse);
            }
            else
            {
                transform.position -= transform.right * (Time.deltaTime * PlayerController.PlayerMovementSpeed);
            }
        }
        if (PlayerController.pressedKey == "right")
        {
            if (PlayerController.jumping && PlayerController.grounded)
            {
                PlayerController.rb2d.AddForce(new Vector2((PlayerController.PlayerMovementSpeed / 8), PlayerController.PlayerJumpSpeed), ForceMode2D.Impulse);
            }
            else
            {
                transform.position += transform.right * (Time.deltaTime * PlayerController.PlayerMovementSpeed);
            }
        }
        if (PlayerController.pressedKey == "stop")
        {
            if (PlayerController.jumping && PlayerController.grounded)
            {
                PlayerController.rb2d.AddForce(new Vector2(0f, PlayerController.PlayerJumpSpeed), ForceMode2D.Impulse);
            }
        }
    }
}
