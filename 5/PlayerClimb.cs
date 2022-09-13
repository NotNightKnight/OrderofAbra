using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    PlayerController PlayerController;
    Collider2D LadderCollision;

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
        LadderCollision = GameObject.FindGameObjectWithTag("ladderCol").GetComponent<Collider2D>();
    }
    void Update()
    {
        if(PlayerController.ladderEE)
        {
            if(Input.GetKeyUp(PlayerController.ladderClimbKeyCode))
            {
                if (PlayerController.climb)
                {
                    PlayerController.climb = false;
                }
                else if (PlayerController.climb == false)
                {
                    PlayerController.climb = true;
                }
            }
        }
        if(PlayerController.ladder == false)
        {
            PlayerController.climb = false;
            PlayerController.climbingDown = false;
            PlayerController.climbingUp = false;
            PlayerController.ladderIdle = false;
            //PlayerController.climbingLeft = false;
            //PlayerController.climbingRight = false;
        }
        if(PlayerController.climb)
        {
            PlayerController.Rigidbody2D.gravityScale = 0f;
            LadderCollision.enabled = false;
        }
        if(PlayerController.climb == false)
        {
            LadderCollision.enabled = true;
            PlayerController.Rigidbody2D.gravityScale = 1f;
            PlayerController.climbingDown = false;
            PlayerController.climbingUp = false;
            PlayerController.ladderIdle = false;
            //PlayerController.climbingLeft = false;
            //PlayerController.climbingRight = false;
        }
        if (PlayerController.climb)
        {
            if (PlayerController.ladder)
            {
                if (Input.GetKeyDown(PlayerController.climbUpKeyCode))
                {
                    PlayerController.climbingUp = true;
                }
                if(Input.GetKeyUp(PlayerController.climbUpKeyCode))
                {
                    PlayerController.climbingUp = false;
                }
                if (Input.GetKeyDown(PlayerController.climbDownKeyCode))
                {
                    PlayerController.climbingDown = true;
                }
                if (Input.GetKeyUp(PlayerController.climbDownKeyCode))
                {
                    PlayerController.climbingDown = false;
                }
                //if(Input.GetKeyDown(PlayerController.leftKeyCode))
                //{
                //    PlayerController.climbingLeft = true;
                //}
                //if(Input.GetKeyDown(PlayerController.rightKeyCode))
                //{
                //    PlayerController.climbingRight = true;
                //}
                //if (Input.GetKeyUp(PlayerController.leftKeyCode))
                //{
                //    PlayerController.climbingLeft = false;
                //}
                //if (Input.GetKeyUp(PlayerController.rightKeyCode))
                //{
                //    PlayerController.climbingRight = false;
                //}
            }
        }
        if(PlayerController.climbingUp)
        {
            transform.position += new Vector3(0f, PlayerController.ClimbingSpeed, 0f);
        }
        if(PlayerController.climbingDown)
        {
            transform.position -= new Vector3(0f, PlayerController.ClimbingSpeed, 0f);
        }
        //if(PlayerController.climbingLeft)
        //{
        //    transform.position -= new Vector3(PlayerController.ClimbingSpeed, 0f, 0f);
        //}
        //if(PlayerController.climbingRight)
        //{
        //    transform.position += new Vector3(PlayerController.ClimbingSpeed, 0f, 0f);
        //}
        if(PlayerController.ladder && PlayerController.climb)
        {
            if (PlayerController.climbingUp == false && PlayerController.climbingDown == false/* && PlayerController.climbingLeft == false && PlayerController.climbingRight == false*/)
            {
                PlayerController.ladderIdle = true;
            }
            if (PlayerController.climbingUp == true | PlayerController.climbingDown == true/* | PlayerController.climbingLeft == true | PlayerController.climbingRight == true*/)
            {
                PlayerController.ladderIdle = false;
            }
        }
    }
}
