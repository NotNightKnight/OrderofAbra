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

    private void OnActionTriggered(InputAction.CallbackContext context)
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
            default:
                myPController.idle = true;
                break;
        }
    }

    private void Move(InputAction.CallbackContext context)
    {
        myPController.moveDirection = context.ReadValue<float>();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if(myPController.groundCheck)
        {
            myPController.startJump = true;
        }
    }
}
