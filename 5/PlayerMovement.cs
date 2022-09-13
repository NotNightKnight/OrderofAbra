using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if(PlayerController.run && PlayerController.grounded)
        {
            if (PlayerController.faceLeft)
                transform.position -= transform.right * (PlayerController.MovementSpeed * Time.deltaTime);
            else
                transform.position += transform.right * (PlayerController.MovementSpeed * Time.deltaTime);
        }
    }
}
