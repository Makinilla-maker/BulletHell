using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;
[Serializable]
public enum Step
{
    NONE,
    CANTMOVE,
    ALLEY,
    Step1,
    Step2,
    Step3,
    BOSS,
}
public enum Level
{
    NONE,
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
    public GameObject[] selectableWeapons;
    public Character player;
    public GameObject playerObject;
    public GameObject[] spawners;

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
        level = Level.LVL1;
        step = Step.ALLEY;
        GetSpawners();
    }
    public void InstatiatePlayer()
    {        
        playerObject = Instantiate(player.prefab);         
    }

    public void NewWeapon(GameObject ch, GameObject player)
    {
        player.GetComponent<CharacterController2D>().character.weapon = ch.GetComponent<WeaponsGeneral>().weapon;
        player.GetComponent<CharacterController2D>().firstTime = false;
        
    }

    public void GetSpawners()
    {
        GameObject[] a;
        a = GameObject.FindGameObjectsWithTag("Spawners");
        Debug.Log(a.Length);
        spawners = a;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(level != Level.BASE)
        {
            ChangeState();            
        }        
    }
    void ChangeState()
    {
        //if (timer > 0 && step == Step.NONE) step = Step.Step1;
        //if (timer > 60 && step == Step.Step1) step = Step.Step2;
        //if (timer > 120 && step == Step.Step2) step = Step.Step3;
    }
    public IEnumerator SceneChanger(string sceneName, Level l)
    {
        timer = 0;
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(0.16f);
        level = l;        
        playerObject.transform.position = Vector3.zero;
        GetSpawners();
    }
}
