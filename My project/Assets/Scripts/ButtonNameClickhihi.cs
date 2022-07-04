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
    public void SetName(TMP_InputField inputfield)
    {
        levelManager.player.name = inputfield.text;
        Destroy(cameraToErrase);
        Destroy(canvas);
        animator.SetTrigger("trans");
        levelManager.InstatiatePlayer();
    }
}
