using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadingSceneScript : MonoBehaviour
{
    public static int toScene;

    public GameObject PressKey;
    public GameObject Obron;
    public GameObject LoadText;

    Text pressKey;
    Text loadText;
    Animator Animator;
    private void Awake()
    {
        pressKey = PressKey.GetComponent<Text>();
        loadText = LoadText.GetComponent<Text>();
        Animator = Obron.GetComponent<Animator>();
    }
    void Start()
    {
        loadText.text = "Loading...";
        Animator.enabled = true;
        pressKey.enabled = false;
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(toScene);
        asyncOperation.allowSceneActivation = false;
        while(!asyncOperation.isDone)
        {
            if(asyncOperation.progress >= 0.9f)
            {
                loadText.text = "Loaded";
                Animator.enabled = false;
                pressKey.enabled = true;
                if(Input.anyKey)
                {
                    asyncOperation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}