using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);

        while(!asyncLoad.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
    }
}
