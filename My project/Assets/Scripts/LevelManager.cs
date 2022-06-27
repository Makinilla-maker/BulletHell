using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
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
public enum Level
{
    BASE,
    LVL1,
}
public class LevelManager : MonoBehaviour
{
    static LevelManager instance;

    public Step step;
    public Level level;
    public float timer = 0;
    //Players
    public GameObject[] selectablePlayers;
    public Players[] players;
    public GameObject[] playerObject;
    public List<GameObject> spawnDick = new List<GameObject>();

    private void Awake()
    {
        Debug.Log("MECAGOENDIOS");
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        level = Level.BASE;
        playerObject = new GameObject[players.Length];
        step = Step.NONE;
        InstatiatePlayer();
    }
    public void InstatiatePlayer()
    {
        Array.Clear(playerObject, 0, playerObject.Length);
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].name != "")
            {
                playerObject[i] = Instantiate(players[i].prefab);
            }
        }
        spawnDick.Clear();
        GameObject[] a = new GameObject[4];
        a = GameObject.FindGameObjectsWithTag("Spawnpoint");
        for (int i = 0; i <= 3; i++)
        {
            spawnDick.Add(a[i]);
            if (level == Level.BASE)
                spawnDick[i].SetActive(false);
        }
    }

    public void SetCharacterStats()
    {
        for (int i = 0; i < players.Length; i++)
        {
            playerObject[i].GetComponent<CharacterController2D>().character.dmg = players[i].dmg;
            playerObject[i].GetComponent<CharacterController2D>().character.life = players[i].life;
            playerObject[i].GetComponent<CharacterController2D>().money = players[i].money;
            playerObject[i].GetComponent<CharacterController2D>().character.attackSpeed = players[i].attackSpeed;
        }
    }
    public void SelectedCharacter(GameObject ch, GameObject player)
    {
        Debug.Log(selectablePlayers.Length);
        for(int i = 0; i < selectablePlayers.Length; i++)
        {
            if (selectablePlayers[i] == ch)
            {
                selectablePlayers[i].SetActive(false);
                player.GetComponent<CharacterController2D>().character = selectablePlayers[i].GetComponent<SelectionableCharacters>().character;
            }
            else
            {
                selectablePlayers[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(level != Level.BASE)
        {
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
    public IEnumerator SceneChanger()
    {
        timer = 0;
        SceneManager.LoadScene("SampleScene");
        yield return new WaitForSeconds(0.16f);
        level = Level.LVL1;
        for (int i = 0; i < playerObject.Length; i++)
        {
            playerObject[i].transform.position = Vector3.zero;
            playerObject[i].GetComponent<CharacterController2D>().bulletParent = GameObject.Find("Trash");
        }
    }
    public void NoSePorqueTengoQueHacerEsto()
    {
        StartCoroutine(SceneChanger());
    }
}
