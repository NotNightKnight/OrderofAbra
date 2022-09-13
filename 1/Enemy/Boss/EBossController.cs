using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBossController : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public Animator myAnimator;
    public GameObject Player;
    public GameObject AfterArenaPlatform2;
    public GameObject BossAttackArea;

    //VARIABLES
    public bool faceLeft
    { get; set; }
    public Vector3 scaleVector3;
    public bool searchPlayer
    { get; set; } = false;
    public float movementSpeed;
    public bool attack
    { get; set; }
    public bool death
    { get; set; } = false;

    private void Update()
    {
        if(searchPlayer)
        {
            if (Player.transform.position.x > transform.position.x)
                faceLeft = false;
            else if (Player.transform.position.x < transform.position.x)
                faceLeft = true;

            if (faceLeft)
                transform.localScale = scaleVector3;
            else if (faceLeft == false)
                transform.localScale = new Vector3(-scaleVector3.x, scaleVector3.y, scaleVector3.z);
        }
    }
    public void SearchPlayer()
    {
        searchPlayer = true;
    }

    public void Die()
    {
        AfterArenaPlatform2.SetActive(true);
        myAnimator.SetTrigger("die");
        death = true;
    }
}
