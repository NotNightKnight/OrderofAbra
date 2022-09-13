using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Player
    { get; set; }
    public Transform playerTransform
    { get; set; }
    public Animator Animator
    { get; set; }

    //CHANGEABLE VARIABLES
    public float MovementSpeed = 1.8f;
    public float AttackRange = 3f;
    public float DetectRange = 5f;
    public Vector2 limit1 = new Vector2(-7f, -8.290059f);
    public Vector2 limit2 = new Vector2(34.3f, -8.290059f);
    public Vector3 scaleLeft = new Vector3(0.3633892f, 0.3633892f, 0.3633892f);
    public Vector3 scaleRight = new Vector3(-0.3633892f, 0.3633892f, 0.3633892f);

    //STATES
    public bool run
    { get; set; }
    public bool attack
    { get; set; }
    public bool attackEnd
    { get; set; } = true;
    public bool attackState
    { get; set; }
    public bool death
    { get; set; }

    //VARIABLES
    public bool faceLeft
    { get; set; }
    public bool playerInRange
    { get; set; }

    private void Awake()
    {
        Player = GameObject.Find("yezek");
        playerTransform = Player.transform;
        Animator = GetComponent<Animator>();
    }

    public void AttackStart()
    {
        attackState = true;
    }
}
