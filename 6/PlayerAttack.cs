using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    PlayerController PlayerController;
    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }
}
