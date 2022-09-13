using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animStillJump : StateMachineBehaviour
{
    GameObject Player;
    PlayerController PlayerController;

    private void Awake()
    {
        Player = GameObject.Find("yezek");
        PlayerController = Player.GetComponent<PlayerController>();
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerController.stillJumping = false;
    }
}
