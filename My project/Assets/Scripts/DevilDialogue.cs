using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilDialogue : MonoBehaviour
{
    public LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    private void Update()
    {
        if(levelManager.player.life <= 0)
        {
            this.transform.position = levelManager.playerObject.transform.position;
            levelManager.playerObject.GetComponent<CharacterController2D>().state = PlayerState.CANTMOVE;
        }
    }
}
