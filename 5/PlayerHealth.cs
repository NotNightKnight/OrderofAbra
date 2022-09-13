using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    PlayerController PlayerController;
    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(PlayerController.healKeyCode))
        {
            if(PlayerController.medkitCount > 0)
            {
                PlayerController.injured = false;
                PlayerController.medkitCount--;
            }
        }
    }
}
