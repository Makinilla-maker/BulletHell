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

    public void LoadGame()
    {
        SaveData data = SaveSystem.LoadData();
        if (data != null)
        {
            StartCoroutine(LoadGameIterator(data));
        }
    }
    IEnumerator LoadGameIterator(SaveData data)
    {
        trans.SetTrigger("trans");
        SetPlayer(data);
        yield return new WaitForSeconds(transitionTime);
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        SceneManager.LoadScene("Base");
        Debug.Log("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
        levelManager.InstatiatePlayer();
        Debug.Log("CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC");
    }
    public void SetPlayer(SaveData data)
    {
        levelManager.player = data.character;
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
