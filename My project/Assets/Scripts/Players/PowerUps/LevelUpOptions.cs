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
        if(levelManager.playerObject.GetComponent<CharacterController2D>().state == PlayerState.SHOP && !activated)
        {
            UI.SetActive(true);
            SetPowerUps();
            activated = true;
        }
        if(levelManager.playerObject.GetComponent<CharacterController2D>().state != PlayerState.SHOP)
        {
            activated = false;
        }
    }

    public void SetPowerUps()
    {
        for(int i = 0; i < butons.Length; i++)
        {
            int x = Random.Range(0,powersUps.Length);
            butons[i].GetComponent<ButtonPowerUp>().powerUp = powersUps[x];
        }
    }
}
