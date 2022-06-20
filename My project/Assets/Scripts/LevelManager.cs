using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public enum Step
{
    NONE,
    Step1,
    Step2,
    Step3,
    Step4,
    Step5,
    Step6,
    Step7,
    Step8,
    Step9,
    Step10,
    BOSS,
}
public class LevelManager : MonoBehaviour
{
    public Step step;
    public float timer = 0;
    //Players
    public Players[] players;
    public GameObject[] playerObject;
    public List<GameObject> spawnDick = new List<GameObject>();

    private void Awake()
    {
        playerObject = new GameObject[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].name != "")
            {
                playerObject[i] = Instantiate(players[i].prefab);
                playerObject[i].GetComponent<CharacterController2D>().dmg = players[i].dmg;
                playerObject[i].GetComponent<CharacterController2D>().life = players[i].life;
                playerObject[i].GetComponent<CharacterController2D>().money = players[i].money;
                playerObject[i].GetComponent<CharacterController2D>().attackSpeed = players[i].attackSpeed;

            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       step = Step.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0 && step == Step.NONE) step = Step.Step1;
        if (timer > 60 && step == Step.Step1) step = Step.Step2;
        if (timer > 120 && step == Step.Step2) step = Step.Step3;
        if (timer > 180 && step == Step.Step3) step = Step.Step4;
        if (timer > 240 && step == Step.Step4) step = Step.Step5;
        if (timer > 300 && step == Step.Step5) step = Step.Step6;
        if (timer > 360 && step == Step.Step6) step = Step.Step7;
        if (timer > 420 && step == Step.Step7) step = Step.Step8;
        if (timer > 480 && step == Step.Step8) step = Step.Step9;
        if (timer > 540 && step == Step.Step9) step = Step.Step10;
        if (timer > 600 && step == Step.Step10) step = Step.BOSS;
    }
}
