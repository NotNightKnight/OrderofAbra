using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public void ButtonTryAgainClick()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
    }

    public void ButtonMainMenuClick()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void ButtonQuitGameClick()
    {
        Application.Quit();
    }
}
