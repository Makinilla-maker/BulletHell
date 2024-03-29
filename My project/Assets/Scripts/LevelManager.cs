using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
[System.Serializable]
public enum Step
{
    NONE,
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
    LVL0,
    LVL1,
    LVL2,
}
public class LevelManager : MonoBehaviour
{
    static LevelManager instance;

    public Step step;
    public Level level;
    public TMP_Text text;
    public bool isTimer;
    public float timer = 900;
    //Players
    public GameObject[] selectableWeapons;
    public Character player;
    public GameObject playerObject;
    public GameObject[] spawners;

    private void Awake()
    {
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
        level = Level.LVL0;
        step = Step.ALLEY;
        isTimer = false;
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
        spawners = a;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
            timer -= Time.deltaTime;
        else 
            timer = 0;
        if (level != Level.BASE)
        {
            ChangeState();            
        }
        if(!isTimer)
        {
            if(GameObject.Find("Timer"))
            {
                text = GameObject.Find("Timer").gameObject.GetComponent<TMP_Text>();
                isTimer = true;
            }
        }
        else if(isTimer)
        {
            DisplayTimer();
        }
    }
    public void DisplayTimer()
    {
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        text.text = string.Format("{0:00}:{1:00}", minutes,seconds);
    }
    void ChangeState()
    {
        //if (timer > 0 && step == Step.NONE) step = Step.Step1;
        //if (timer > 60 && step == Step.Step1) step = Step.Step2;
        //if (timer > 120 && step == Step.Step2) step = Step.Step3;
    }
    public void SceneChanger(int sceneInt)
    {
        string sceneName;
        switch(sceneInt)
        {
            case 0:
                sceneName = "Base";
                level = Level.BASE;
                step = Step.Step1;
                Debug.Log("BASE");
                break;
            case 1:
                sceneName = "Level1";
                level = Level.LVL1;
                step = Step.Step1;
                Debug.Log("LVL1");
                break;
            case 2:
                sceneName = "Level2";
                level = Level.LVL2;
                step = Step.Step1;
                Debug.Log("LVL2");
                break;
            default:
                sceneName = "";
                break;
        }
        StartCoroutine(SceneChangerCorrutine(sceneName,level));
    }
    public IEnumerator SceneChangerCorrutine(string sceneName, Level l)
    {
        timer = 900;
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(0.16f);
        level = l;        
        playerObject.transform.position = Vector3.zero;
        GetSpawners();
        playerObject.GetComponent<CharacterController2D>().state = PlayerState.NORMAL;
    }
}
