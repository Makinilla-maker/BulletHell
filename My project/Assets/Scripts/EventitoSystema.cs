using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventitoSystema : MonoBehaviour
{
    public string sceneGame;
    public Animator trans;
    public float transitionTime = 1f;
    public LevelManager levelManager;
    public void NewGame()
    {
        StartCoroutine(LoadLevel(sceneGame));
    }
    IEnumerator LoadLevel(string sceneGame)
    {
        trans.SetTrigger("trans");
        yield return new WaitForSeconds(transitionTime);
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
