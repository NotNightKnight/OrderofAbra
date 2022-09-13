using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animEnemyAttack : StateMachineBehaviour
{
    GameObject Enemy;
    EnemyController EnemyController;

    private void Awake()
    {
        Enemy = GameObject.Find("android 1");
        EnemyController = Enemy.GetComponent<EnemyController>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyController.attackEnd = false;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyController.attackEnd = true;
        EnemyController.attackState = false;
    }
}
