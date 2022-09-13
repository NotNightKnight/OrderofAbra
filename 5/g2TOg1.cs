using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g2TOg1 : MonoBehaviour
{
    GameObject Camera1;
    GameObject Camera2;

    Camera cam1;
    Camera cam2;

    private void Awake()
    {
        Camera1 = GameObject.Find("cam1");
        Camera2 = GameObject.Find("cam2");

        cam1 = Camera1.GetComponent<Camera>();
        cam2 = Camera2.GetComponent<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "yezek")
        {
            cam2.enabled = false;
            cam1.enabled = true;
        }
    }
}
