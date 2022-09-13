using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEditor;

public class PController : MonoBehaviour
{
    //COMPONENTS
    public Rigidbody2D myRigidbody2D
    { get; set; }
    public Animator myAnimator
    { get; set; }
    public InputActionMap myGameplayMap
    { get; set; }
    public InputActionMap myMenuMap
    { get; set; }

    public GameObject ParticleGameObject;

    public GameObject myAttackArea;

    public GameObject myUIPointer;
    public GameObject myPauseMenu;

    public Button firstSelectedButton;

    public GameObject EnemyAndroid;
    public GameObject EnemyBoss;

    public InputActionAsset myActionAsset;

    public GameObject UpBarUI;


    private void Awake()
    {
        //myActionAsset = (InputActionAsset)AssetDatabase.LoadAssetAtPath("Assets/Scipts/Player/Input/MyInput.inputactions", typeof(InputActionAsset));
        myGameplayMap = myActionAsset.FindActionMap("Gameplay");
        myMenuMap = myActionAsset.FindActionMap("Menu");
        myGameplayMap.Enable();

        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        checkGroundTimer -= Time.deltaTime;

        if (onWall)
            myRigidbody2D.gravityScale = 0.2f;
        else
            myRigidbody2D.gravityScale = gravityScale;
    }


    //STATES
    public bool available
    { get; set; }
    public bool idle
    { get; set; }
    public bool run
    { get; set; }
    public bool jump
    { get; set; }
    public bool roll
    { get; set; }
    public bool attack
    { get; set; }
    public bool onWall
    { get; set; }
    public bool parry
    { get; set; }
    public bool faceLeft
    { get; set; } = false;
    public bool movementRoll
    { get; set; }
    public bool gunClimb1
    { get; set; }
    public bool gunClimb2
    { get; set; }
    public bool injured
    { get; set; }
    public bool death
    { get; set; }

    
    //STATESTARTERS
    public bool startJump
    { get; set; }
    public bool startRoll
    { get; set; }
    public bool startAttack1
    { get; set; }
    public bool startAttack2
    { get; set; }
    public bool startAttack3
    { get; set; }
    public bool startParry
    { get; set; }
    public bool startDrop
    { get; set; }
    public bool startGunClimb
    { get; set; }

    //VARIABLES
    public float moveDirection
    { get; set; }
    public float coyoteJumpTime;
    public float gravityScale;
    private bool gamePaused = false;

    //CHECKS
    private float checkGroundTimer = 0f;
    public bool checkGround
    {
        get
        {
            return checkGroundTimer > 0;
        }
        set
        {
            checkGroundTimer = value ? coyoteJumpTime : checkGroundTimer;
        }
    }
    public bool checkWallFront
    { get; set; }
    public bool checkWallBack
    { get; set; }
    public bool checkSlope
    { get; set; }
    public bool checkGunClimb
    { get; set; }

    public bool CheckAvailable()
    {
        if (roll)
            available = false;
        else if (attack)
            available = false;
        else if (jump)
            available = false;
        else if (onWall)
            available = false;
        else if (parry)
            available = false;
        else if (death)
            available = false;
        else
            available = true;
        return available;
    }

    public bool CheckOnlyRoll()
    {
        if (roll)
            available = true;
        if (attack)
            available = false;
        if (jump)
            available = false;
        if (onWall)
            available = false;
        if (parry)
            available = false;
        if (death)
            available = false;

        return available;
    }

    public void ChangePause()
    {
        if(gamePaused)
        {
            Time.timeScale = 1f;
            myPauseMenu.GetComponent<Canvas>().enabled = false;
            gamePaused = false;
            myGameplayMap.Enable();
            myMenuMap.Disable();
        }
        else if(gamePaused==false)
        {
            firstSelectedButton.Select();
            Time.timeScale = 0f;
            myPauseMenu.GetComponent<Canvas>().enabled = true;
            gamePaused = true;
            myGameplayMap.Disable();
            myMenuMap.Enable();
        }
    }

    public void GetHit()
    {
        if(injured == false)
        {
            injured = true;
        }
        else
        {
            UpBarUI.GetComponent<UpBarUIScript>().GetHit();
        }
    }

    public void Die()
    {
        death = true;
        firstSelectedButton.Select();
        Time.timeScale = 0f;
        myPauseMenu.GetComponent<Canvas>().enabled = true;
        gamePaused = true;
        myGameplayMap.Disable();
        myMenuMap.Enable();
    }
}
