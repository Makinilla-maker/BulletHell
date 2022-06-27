using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventitoSystema : MonoBehaviour
{
    public string sceneGame;
    public void NewGame()
    {
        SceneManager.LoadScene(sceneGame);
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
