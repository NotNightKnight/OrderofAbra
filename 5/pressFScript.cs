using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressFScript : MonoBehaviour
{
    GameObject Player;
    GameObject pressf;
    PlayerController PlayerController;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerController = Player.GetComponent<PlayerController>();
        pressf = GameObject.Find("pressF");
    }

    private void Update()
    {
        if (PlayerController.ladderEE)
        {
            pressf.SetActive(true);
        }
        if(PlayerController.ladderEE == false)
        {
            pressf.SetActive(false);
        }
    }
}
