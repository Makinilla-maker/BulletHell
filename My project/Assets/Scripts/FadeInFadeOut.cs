using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInFadeOut : MonoBehaviour
{
    
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(FindObjectOfType<LevelManager>().level);
        if(FindObjectOfType<LevelManager>().level != Level.LVL0)
        {
            animator.SetTrigger("trans");
        }
    }
}
