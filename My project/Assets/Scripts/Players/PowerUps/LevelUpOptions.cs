using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUpOptions : MonoBehaviour
{
    public GameObject UI;
    public PowerUp[] powersUps;
    public GameObject[] butons;
    LevelManager levelManager;
    bool activated;
    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        activated = false;
    }

    public void Update()
    {
        if(levelManager.playerObject.GetComponent<CharacterController2D>().isShopping && !activated)
        {
            UI.SetActive(true);
            SetPowerUps();
            activated = true;
        }
        if(!levelManager.playerObject.GetComponent<CharacterController2D>().isShopping)
        {
            activated = false;
        }
    }

    public void SetPowerUps()
    {
        for(int i = 0; i < butons.Length; i++)
        {
            bool bulean = false;
            while (!bulean)
            {
                int a = Random.Range(0, powersUps.Length);
                if (!powersUps[a].isPicked)
                {
                    bulean = true;
                    butons[i].GetComponent<ButtonPowerUp>().powerUp = powersUps[a];
                }
            }
        }
    }
}
