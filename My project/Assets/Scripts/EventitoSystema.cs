using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventitoSystema : MonoBehaviour
{
    public string sceneGameOnline;
    public string sceneGameOffline;
    public void NewGameOnline()
    {
        SceneManager.LoadScene(sceneGameOnline);
    }
    public void NewGameOffline()
    {
        SceneManager.LoadScene(sceneGameOffline);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void TDM()
    {
        Application.OpenURL("https://twitter.com/TDMstudios3");
    }
}
