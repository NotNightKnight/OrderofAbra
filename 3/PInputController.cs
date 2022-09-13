using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PInputController : MonoBehaviour
{
    PController myPController;
    private void Awake()
    {
        myPController = GetComponent<PController>();
    }
    private void Start()
    {
        myPController.myGameplayMap.actionTriggered += context => OnActionTriggered(context);
    }

    void OnActionTriggered(InputAction.CallbackContext context)
    {
        string action = context.action.name;

        switch(action)
        {
            case "Movement":
                Move(context);
                break;
            case "Jump":
                Jump(context);
                break;
            case "Attack":
                Attack(context);
                break;
            case "Roll":
                Roll(context);
                break;
            case "Parry":
                Parry(context);
                break;
            default:
                break;
        }
    }

    void Move(InputAction.CallbackContext context)
    {
        myPController.moveDirection = context.ReadValue<float>();
    }

    void Jump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(myPController.checkGround)
            {
                myPController.startJump = true;
                myPController.myAnimator.SetTrigger("jump");
            }
            if(myPController.onWall)
            {
                myPController.startWallJump = true;
                myPController.myAnimator.SetTrigger("jump");
            }
        }
    }

    void Attack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            myPController.myAnimator.SetTrigger("attack");
        }
    }

    void Roll(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            myPController.myAnimator.SetTrigger("roll");
        }
    }

    void Parry(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            myPController.myAnimator.SetTrigger("parry");
        }
    }
}
