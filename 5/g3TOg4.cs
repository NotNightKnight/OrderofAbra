using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g3TOg4 : MonoBehaviour
{
    GameObject Camera1;
    GameObject Camera2;

    Camera cam1;
    Camera cam2;

    private void Awake()
    {
        Camera1 = GameObject.Find("cam3");
        Camera2 = GameObject.Find("cam4");

        cam1 = Camera1.GetComponent<Camera>();
        cam2 = Camera2.GetComponent<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "yezek")
        {
            cam1.enabled = false;
            cam2.enabled = true;
        }
    }
}
