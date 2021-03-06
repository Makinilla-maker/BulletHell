using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl0 : MonoBehaviour
{
    public LevelManager levelManager;
    public Collider2D[] colliders;
    public Collider2D enable;
    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            levelManager.step = Step.Step1;
            for(int i = 0; i < colliders.Length; i++)
            {
                enable.gameObject.SetActive(true);
                Destroy(colliders[i].gameObject);
            }
        }
    }
}
