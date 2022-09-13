using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EController : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public BoxCollider2D myBoxCollider2D;
    public Animator myAnimator;
    public GameObject myPlayer;
    public GameObject AndroidParts;
    public GameObject AfterCombatArena1;
    public GameObject Gun;
    private void Update()
    {
        if (myPlayer.transform.position.x > transform.position.x)
            faceLeft = false;
        else if (myPlayer.transform.position.x < transform.position.x)
            faceLeft = true;

        if (faceLeft)
            transform.localScale = ScaleVector3;
        else if (faceLeft == false)
            transform.localScale = new Vector3(-ScaleVector3.x, ScaleVector3.y, ScaleVector3.z);
    }

    //VARIABLES
    public bool searchPlayer
    { get; set; } = false;
    public bool faceLeft
    { get; set; }
    public float ShootCoolDown;
    public float DestroyAfterTime;
    public Vector3 ScaleVector3;


    public void StartSearching()
    {
        searchPlayer = true;
    }

    public void StopSearching()
    {
        searchPlayer = false;
    }

    public void Die()
    {
        GameObject willDestroyedAndroidParts;
        willDestroyedAndroidParts = Instantiate(AndroidParts, transform.position, Quaternion.identity);
        Destroy(willDestroyedAndroidParts, DestroyAfterTime);
        AfterCombatArena1.SetActive(false);
        gameObject.SetActive(false);
    }
}
