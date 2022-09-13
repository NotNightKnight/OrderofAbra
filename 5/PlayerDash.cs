using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if(PlayerController.dashMov)
        {
            if (PlayerController.dashDirection == "left")
                transform.position -= new Vector3(PlayerController.DashDistance, 0f, 0f);
            else
                transform.position += new Vector3(PlayerController.DashDistance, 0f, 0f);
            PlayerController.dashMov = false;
        }
    }
}
