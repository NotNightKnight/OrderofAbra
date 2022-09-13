using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;

public class PController : MonoBehaviour
{
    //COMPONENTS
    public InputActionAsset myActAsset
    { get; set; }
    public InputActionMap myGameplayMap
    { get; set; }
    public Rigidbody2D myRigidbody2D
    { get; set; }
    public CircleCollider2D myCircleCollider2D
    { get; set; }

    private void Awake()
    {
        myActAsset = (InputActionAsset)AssetDatabase.LoadAssetAtPath("Assets/Input/myInputSystem.inputactions", typeof(InputActionAsset));
        myGameplayMap = myActAsset.FindActionMap("Gameplay");
        myGameplayMap.Enable();

        myRigidbody2D = GetComponent<Rigidbody2D>();
        
        groundLayerMask = LayerMask.GetMask("Ground");

        myCircleCollider2D = GetComponent<CircleCollider2D>();
    }

    //CHANGEABLE VARIABLES
    [SerializeField]
    public float movementSpeed = 4f;
    [SerializeField]
    public float jumpSpeed = 5f;
    

    //VARIABLES
    public float moveDirection
    { get; set; }
    public LayerMask groundLayerMask
    { get; set; }
    public float groundCheckDistance
    { get; set; } = 0.01f;


    //CHECKS
    public bool groundCheck
    { get; set; }

    //STATECHANGES
    public bool startJump
    { get; set; }

    //STATES
    public bool idle
    { get; set; }
    public bool run
    { get; set; }
    public bool jump
    { get; set; }
}
