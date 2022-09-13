using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //RIGIDBODY && ANIMATOR
    public Rigidbody2D Rigidbody2D
    { get; set; }
    public Animator Animator
    { get; set; }

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    //STATES
    public bool attack
    { get; set; }
    public bool attackS2
    { get; set; }
    public bool attackS3
    { get; set; }
    public bool attackMov
    { get; set; }
    public bool attackState
    { get; set; }
    public bool run
    { get; set; }
    public bool idle
    { get; set; }
    public bool dash
    { get; set; }
    public bool dashState
    { get; set; }
    public bool dashMov
    { get; set; }
    public bool stillJumping
    { get; set; }
    public bool directionalJumping
    { get; set; }
    public bool jumpingState
    { get; set; }
    public bool parry
    { get; set; }
    public bool parryState
    { get; set; }
    public bool death
    { get; set; }
    public bool ladderEE
    { get; set; }
    public bool ladder
    { get; set; }
    public bool climb
    { get; set; }
    public bool climbingUp
    { get; set; }
    public bool climbingDown
    { get; set; }
    public bool climbingLeft
    { get; set; }
    public bool climbingRight
    { get; set; }
    public bool ladderIdle
    { get; set; }

    //PLAYER STATES
    public bool invulnerable
    { get; set; }
    public bool injured
    { get; set; }

    //PLAYER CHANGEABLES
    public float MovementSpeed = 8f;
    public float JumpSpeed = 4f;
    public float DirectionalJumpSpeed = 1.7f;
    public float DashDistance = 2.7f;
    public float AttackDistance = 0.8f;
    public float ClimbingSpeed = 0.01f;
    public Vector3 scaleLeft = new Vector3(-0.4040613f, 0.4040613f, 0.4040613f);
    public Vector3 scaleRight = new Vector3(0.4040613f, 0.4040613f, 0.4040613f);

    //VARIABLES
    public float doubleClickTime
    { get; } = 0.2f;
    public float lastClickTime
    { get; set; } = 0f;
    public float timeSinceLastClick
    { get; set; }
    public string prevPresKey
    { get; set; }
    public string pressedKey
    { get; set; } = "";
    public bool faceLeft
    { get; set; }
    public string dashDirection
    { get; set; }
    public bool grounded
    { get; set; }
    public int lastExp
    { get; set; } = 0;
    public int experince
    { get; set; } = 0;
    public int medkitCount
    { get; set; } = 5;
    public int saveBarkat
    { get; set; } = 10;
    public bool expGained
    { get; set; }

    //KEYCODES
    public KeyCode leftKeyCode
    { get; set; } = KeyCode.A;
    public KeyCode rightKeyCode
    { get; set; } = KeyCode.D;
    public KeyCode jumpKeyCode
    { get; set; } = KeyCode.W;
    public KeyCode attackKeyCode
    { get; set; } = KeyCode.K;
    public KeyCode parryKeyCode
    { get; set; } = KeyCode.Space;
    public KeyCode ladderClimbKeyCode
    { get; set; } = KeyCode.F;
    public KeyCode climbUpKeyCode
    { get; set; } = KeyCode.W;
    public KeyCode climbDownKeyCode
    { get; set; } = KeyCode.S;
    public KeyCode healKeyCode
    { get; set; } = KeyCode.E;
}