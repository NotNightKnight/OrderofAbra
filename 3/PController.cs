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
    public BoxCollider2D myBoxCollider2D
    { get; set; }
    public Animator myAnimator
    { get; set; }

    private void Awake()
    {
        myActAsset = (InputActionAsset)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Player/Input/MyInputController.inputactions", typeof(InputActionAsset));
        myGameplayMap = myActAsset.FindActionMap("Gameplay");
        myGameplayMap.Enable();

        myRigidbody2D = GetComponent<Rigidbody2D>();
        myCircleCollider2D = GetComponent<CircleCollider2D>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();

        layerMaskGround = LayerMask.GetMask("Ground");
    }

    //CHANGEABLE VARIABLES
    [SerializeField]
    public float movementSpeed = 14f;
    [SerializeField]
    public float jumpSpeed = 17f;

    //VARIABLES
    public float moveDirection
    { get; set; }
    public bool faceRight
    { get; set; }
    public LayerMask layerMaskGround
    { get; set; }
    public float checkDistanceGround
    { get; set; } = 0.01f;
    public float checkWallDistance
    { get; set; } = 0.4f;
    public float checkGroundTimer
    { get; set; } = 0;

    //CHECKS
    public bool checkGround
    {
        get 
        {
            return checkGroundTimer > 0;
        }
        set
        {
            checkGroundTimer = value ? 0.3f : checkGroundTimer;
        }
    }
    public bool checkWallFront
    { get; set; }
    public bool checkWallBack
    { get; set; }

    //STARTSTATE
    public bool startJump
    { get; set; }
    public bool startWallJump
    { get; set; }

    //STATES
    public bool idle
    { get; set; }
    public bool run
    { get; set; }
    public bool jump
    { get; set; }
    public bool attack
    { get; set; }
    public bool onWall
    { get; set; }
}
