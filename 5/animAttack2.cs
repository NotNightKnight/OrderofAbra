using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animAttack2 : StateMachineBehaviour
{
    GameObject Player;
    PlayerController PlayerController;

    private void Awake()
    {
        Player = GameObject.Find("yezek");
        PlayerController = Player.GetComponent<PlayerController>();
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerController.attackState = true;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerController.attack = true;
        if (Input.GetKeyDown(PlayerController.attackKeyCode))
        {
            PlayerController.attackS3 = true;
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerController.attackS2 = false;
        PlayerController.attack = false;
        PlayerController.attackState = false;
    }
}
