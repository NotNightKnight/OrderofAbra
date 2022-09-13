using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    PlayerCollision PlayerCollision;
    PlayerInput PlayerInput;
    PlayerMovement PlayerMovement;

    [SerializeField]
    float playerMovementSpeed = 3f;
    [SerializeField]
    float playerJumpSpeed = 3f;
    [SerializeField]
    float playerFallSpeed = 3f;

    public Rigidbody2D rb2d
    {
        get { return Rigidbody2D; }
        set { Rigidbody2D = value; }
    }
    public float PlayerMovementSpeed
    {
        get { return playerMovementSpeed; }
        set { playerMovementSpeed = value; }
    }
    public float PlayerJumpSpeed
    {
        get { return playerJumpSpeed; }
        set { playerJumpSpeed = value; }
    }
    public float PlayerFallSpeed
    {
        get { return playerFallSpeed; }
        set { playerFallSpeed = value; }
    }

    public string pressedKey
    { get; set; }
    public bool jumping
    { get; set; }
    public bool grounded
    { get; set; }

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        PlayerCollision = GetComponent<PlayerCollision>();
        PlayerInput = GetComponent<PlayerInput>();
        PlayerMovement = GetComponent<PlayerMovement>();
    }
}
