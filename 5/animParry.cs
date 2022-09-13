using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animParry : StateMachineBehaviour
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
        PlayerController.parryState = true;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerController.parry = false;
        PlayerController.parryState = false;
    }
}
