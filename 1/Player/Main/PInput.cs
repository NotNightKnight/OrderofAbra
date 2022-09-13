using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PInput : MonoBehaviour
{
    PController myPController;

    private void Awake()
    {
        myPController = GetComponent<PController>();
    }

    private void Start()
    {
        myPController.myGameplayMap.actionTriggered += context => OnActionTriggeredGameplay(context);
        myPController.myMenuMap.actionTriggered += context => OnActionTriggeredMenu(context);
    }

    private void OnActionTriggeredGameplay(InputAction.CallbackContext context)
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
            case "Roll":
                Roll(context);
                break;
            case "Attack1":
                Attack1(context);
                break;
            case "Attack2":
                Attack2(context);
                break;
            case "Attack3":
                Attack3(context);
                break;
            case "Drop":
                Drop(context);
                break;
            case "Parry":
                Parry(context);
                break;
            case "GunClimb":
                GunClimb(context);
                break;
            case "Pause":
                Pause(context);
                break;
            case "Heal":
                Heal(context);
                break;
            default:
                break;
        }
    }

    private void Move(InputAction.CallbackContext context)
    {
        myPController.moveDirection = context.ReadValue<float>();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
            myPController.startJump = true;
    }

    private void Roll(InputAction.CallbackContext context)
    {
        if(context.performed)
            myPController.startRoll = true;
    }

    private void Attack1(InputAction.CallbackContext context)
    {
        if(context.performed)
            myPController.startAttack1 = true;
    }

    private void Attack2(InputAction.CallbackContext context)
    {
        if (context.performed)
            myPController.startAttack2 = true;
    }

    private void Attack3(InputAction.CallbackContext context)
    {
        if (context.performed)
            myPController.startAttack3 = true;
    }

    private void Drop(InputAction.CallbackContext context)
    {
        if (context.performed)
            myPController.startDrop = true;
    }

    private void Parry(InputAction.CallbackContext context)
    {
        if (context.performed)
            myPController.startParry = true;
    }

    private void GunClimb(InputAction.CallbackContext context)
    {
        if (context.performed)
            myPController.startGunClimb = true;
    }

    private void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
            myPController.ChangePause();
    }

    private void Heal(InputAction.CallbackContext context)
    {
        if (context.performed)
            myPController.UpBarUI.GetComponent<UpBarUIScript>().Healed();
    }


    private void OnActionTriggeredMenu(InputAction.CallbackContext context)
    {
        string action = context.action.name;

        switch(action)
        {
            case "Unpause":
                Unpause(context);
                break;
            default:
                break;
        }
    }

    private void Unpause(InputAction.CallbackContext context)
    {
        if (context.performed)
            myPController.ChangePause();
    }
}
