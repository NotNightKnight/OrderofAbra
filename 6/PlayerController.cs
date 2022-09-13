using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    PlayerAttack PlayerAttack;
    [SerializeField]
    PlayerCollision PlayerCollision;
    [SerializeField]
    PlayerMovement PlayerMovement;
    [SerializeField]
    Rigidbody2D Rigidbody2D;
    [SerializeField]
    float PlayerMovementSpeed = 3f;
    [SerializeField]
    float PlayerJumpSpeed = 3f;
    [SerializeField]
    float PlayerFallSpeed = 3f;

    public string buttonPressed
    { get; set; }
    public Rigidbody2D Rigidbody
    {
        get { return Rigidbody2D; }
        set { Rigidbody2D = value; }
    }
    public float playerMovementSpeed
    {
        get { return PlayerMovementSpeed; }
        set { PlayerMovementSpeed = value; }
    }
    public float playerJumpSpeed
    {
        get { return PlayerJumpSpeed; }
        set { PlayerJumpSpeed = value; }
    }
    public float playerFallSpeed
    {
        get { return PlayerFallSpeed; }
        set { PlayerFallSpeed = value; }
    }
    public bool isJumping
    { get; set; }
    public bool isGrounded
    { get; set; }


    private void Awake()
    {
        PlayerAttack = GetComponent<PlayerAttack>();
        PlayerCollision = GetComponent<PlayerCollision>();
        PlayerMovement = GetComponent<PlayerMovement>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
