using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFeatures : MonoBehaviour
{
    PlayerController PlayerController;

    public GameObject Obron;
    public GameObject TotalXP;
    public GameObject SaveBarkat;
    public GameObject MedPack;
    public GameObject BleedingText;
    public GameObject XPCounter;
    public GameObject BleedCounter;

    Animator Animator;

    Text totalXP;
    Text saveBarkat;
    Text medpack;
    Text bleeding;
    Text xpCounter;
    Text bleedCounter;

    float counter = 25;

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();

        Animator = Obron.GetComponent<Animator>();

        totalXP = TotalXP.GetComponent<Text>();
        saveBarkat = SaveBarkat.GetComponent<Text>();
        medpack = MedPack.GetComponent<Text>();
        bleeding = BleedingText.GetComponent<Text>();
        xpCounter = XPCounter.GetComponent<Text>();
        bleedCounter = BleedCounter.GetComponent<Text>();
    }
    private void Start()
    {
        InvokeRepeating("XPCounterDisabler", 0f, 2.5f);
    }
    private void Update()
    {
        totalXP.text = PlayerController.experince.ToString() + " xp";
        saveBarkat.text = PlayerController.saveBarkat.ToString();
        medpack.text = PlayerController.medkitCount.ToString();
        xpCounter.text = PlayerController.lastExp.ToString() + " xp";

        if(PlayerController.injured)
        {
            bleeding.enabled = true;
            bleedCounter.enabled = true;
            bleedCounter.text = ((int)counter).ToString();
            Animator.enabled = true;

            if(counter <= 0)
            {
                PlayerController.death = true;
            }

            counter -= (1f * Time.deltaTime);
        }
        if(PlayerController.injured == false)
        {
            bleeding.enabled = false;
            bleedCounter.enabled = false;
            Animator.enabled = false;
            counter = 25;
        }
        if(PlayerController.expGained)
        {
            xpCounter.enabled = true;
            if(PlayerController.injured)
            {
                bleeding.enabled = false;
                bleedCounter.enabled = false;
            }
        }
    }
    void XPCounterDisabler()
    {
        if(PlayerController.expGained)
        {
            PlayerController.experince += PlayerController.lastExp;
            xpCounter.enabled = false;
            PlayerController.expGained = false;
            if(PlayerController.injured)
            {
                bleeding.enabled = true;
                bleedCounter.enabled = true;
            }
        }        
    }
}
