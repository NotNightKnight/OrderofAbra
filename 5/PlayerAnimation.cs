using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        PlayerController.Animator.SetBool("running", PlayerController.run);
        PlayerController.Animator.SetBool("stillJumping", PlayerController.stillJumping);
        PlayerController.Animator.SetBool("forwardJumping", PlayerController.directionalJumping);
        PlayerController.Animator.SetBool("dashing", PlayerController.dash);
        PlayerController.Animator.SetBool("attacking", PlayerController.attack);
        PlayerController.Animator.SetBool("attacking2", PlayerController.attackS2);
        PlayerController.Animator.SetBool("attacking3", PlayerController.attackS3);
        PlayerController.Animator.SetBool("parry", PlayerController.parry);
        PlayerController.Animator.SetBool("ladderIdle", PlayerController.ladderIdle);
        PlayerController.Animator.SetBool("climbing", PlayerController.climb);

        if (PlayerController.faceLeft)
        {
            transform.localScale = PlayerController.scaleLeft;
        }
        else
        {
            transform.localScale = PlayerController.scaleRight;
        }

        if (PlayerController.dashState | PlayerController.parryState)
            PlayerController.invulnerable = true;
        if (PlayerController.dashState == false && PlayerController.parryState == false)
            PlayerController.invulnerable = false;
    }
}
