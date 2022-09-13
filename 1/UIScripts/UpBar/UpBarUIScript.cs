using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpBarUIScript : MonoBehaviour
{
    public GameObject player;

    public GameObject DeathTimeInfoObject;
    public GameObject DeathTimerObject;

    public float DeathTime;
    private float DeathTimeUpLimit;

    private PController myPController;
    private Text DeathTimeInfoText;
    private Text DeathTimerText;

    private void Awake()
    {
        myPController = player.GetComponent<PController>();
        DeathTimeInfoText = DeathTimeInfoObject.GetComponent<Text>();
        DeathTimerText = DeathTimerObject.GetComponent<Text>();

        DeathTimeUpLimit = DeathTime;
    }

    private void Update()
    {
        if(myPController.injured)
        {
            StartDeathTime();
            DeathTime -= Time.deltaTime;
            DeathTimerText.text = ((int)DeathTime).ToString();
            if(DeathTime < 0)
            {
                myPController.Die();
            }
        }
    }

    private void StartDeathTime()
    {
        DeathTimeInfoText.text = "Death clock is ticking";
    }
    
    private void ResetDeathTime()
    {
        DeathTimeInfoText.text = "You are not dying yet";
        DeathTimerText.text = "";
        DeathTime = DeathTimeUpLimit;
    }

    public void Healed()
    {
        ResetDeathTime();
        myPController.injured = false;
    }

    public void GetHit()
    {
        DeathTime -= 3f;
    }
}
