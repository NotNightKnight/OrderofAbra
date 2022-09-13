using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PMovement : MonoBehaviour
{
    private PController pController;

    public InputActionAsset actionAsset;
    private InputActionMap gameplayMap;

    private float movement;

    private void Awake()
    {
        pController = GetComponent<PController>();

        gameplayMap = actionAsset.FindActionMap("Gameplay");
        gameplayMap.Enable();
    }

    private void Start()
    {
        gameplayMap.actionTriggered += ctx => OnActionTriggered(ctx);
    }

    private void Update()
    {
        Move();
    }

    private void OnActionTriggered(InputAction.CallbackContext context)
    {
        string action = context.action.name;

        switch(action)
        {
            case "Movement":
                OnMove(context);
                break;
            case "Jump":
                OnJump(context);
                break;
            default:
                break;
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<float>();
    }

    private void Move()
    {
        Vector3 moveVector = new Vector3(movement * Time.deltaTime * pController.movSpeed, 0f, 0f);
        transform.position += moveVector;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        
    }
}
