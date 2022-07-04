using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonNameClickhihi : MonoBehaviour
{
    public LevelManager levelManager;

    public GameObject cameraToErrase;
    public GameObject canvas;
    public Animator animator;
    public GameObject canvasTutorial;
    public bool a = false;
    public DialogeSystem sentences;

    private void Update()
    {
        if (a && sentences.sentences.Count < 0)
        {
            Debug.Log("AADSDADADASDA");
            canvasTutorial.SetActive(true);
            if(Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d"))
            {
                Destroy(canvasTutorial);
                Destroy(gameObject);
            }
        }
    }
    public void SetName(TMP_InputField inputfield)
    {
        levelManager.player.name = inputfield.text;
        Destroy(cameraToErrase);
        Destroy(canvas);
        animator.SetTrigger("trans");
        levelManager.InstatiatePlayer();
        StartCoroutine(aa());
    }
    IEnumerator aa()
    {
        yield return new WaitForSeconds(1);
        a = true;
    }
}
