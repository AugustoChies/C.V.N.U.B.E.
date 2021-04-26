using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderButton : MonoBehaviour
{
    public string sceneName;
    public void ButtonPress()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}
