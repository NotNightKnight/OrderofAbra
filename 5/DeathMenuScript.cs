using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenuScript : MonoBehaviour
{
    GameObject Player;
    PlayerController PlayerController;

    public GameObject DeathMenuUI;
    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerController = Player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(PlayerController.death)
        {
            DeathMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
