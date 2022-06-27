using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]


public class EnemyManager : MonoBehaviour
{
    //Enemies
    public Enemy[] enemy;
    public List<GameObject> enemies = new List<GameObject>();
    public Vector3 place;

    public LevelManager levelManger;

    public float delayEnemy;
    [SerializeField] private float timeBetween = 0;

    public float percentBasicEnemy;
    public float percentTankEnemy;

    public int enemyCuant = 2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] a = new GameObject[4];
        a = GameObject.FindGameObjectsWithTag("Spawnpoint");
        for (int i = 0; i <= 3; i++)
        {
            levelManger.spawnDick.Add(a[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeBetween += Time.deltaTime;
        if (timeBetween > delayEnemy)
        {
            CreateEnemy();
            timeBetween = 0;
        }
        StateMachine();
    }

    void StateMachine()
    {
        switch(levelManger.step)
        {
            case 0:
                break;
            case Step.Step1:
                delayEnemy = 5;
                percentBasicEnemy = 100;
                percentTankEnemy = 100 - percentBasicEnemy;
                break;
            case Step.Step2:
                delayEnemy = 4;
                percentBasicEnemy = 100;
                percentTankEnemy = 100 - percentBasicEnemy;
                break;
            case Step.Step3:
                delayEnemy = 3.5f;
                percentBasicEnemy = 100;
                percentTankEnemy = 100 - percentBasicEnemy;
                break;
            case Step.Step4:
                delayEnemy = 3f;
                percentBasicEnemy = 100;
                percentTankEnemy = 100 - percentBasicEnemy;
                break;
            case Step.Step5:
                delayEnemy = 2.5f;
                percentBasicEnemy = 80;
                percentTankEnemy = 100 - percentBasicEnemy;
                break;
            case Step.Step6:
                delayEnemy = 2f;
                percentBasicEnemy = 70;
                percentTankEnemy = 100 - percentBasicEnemy;
                break;
            case Step.Step7:
                delayEnemy = 1.5f;
                percentBasicEnemy = 60;
                percentTankEnemy = 100 - percentBasicEnemy;
                break;
            case Step.Step8:
                delayEnemy = 1f;
                percentBasicEnemy = 50;
                percentTankEnemy = 100 - percentBasicEnemy;
                break;
            case Step.Step9:
                delayEnemy = 1f;
                percentBasicEnemy = 50;
                percentTankEnemy = 100 - percentBasicEnemy;
                break;
            case Step.Step10:
                delayEnemy = 1f;
                percentBasicEnemy = 50;
                percentTankEnemy = 100 - percentBasicEnemy;
                break;
            default:
                break;
        }
    }

    void CreateEnemy()
    {
        int x;
        float debug = UnityEngine.Random.value;
        if (debug < percentBasicEnemy/100) x = 0;
        else x = 1;
        for (int j = 0; j < levelManger.playerObject.Length; j++)
        {
            for(int y = 0; y < enemyCuant; y++)
            {
                int i = UnityEngine.Random.Range(0, levelManger.spawnDick.Count);
                Vector2 pos = new Vector2(UnityEngine.Random.Range(levelManger.spawnDick[i].GetComponent<BoxCollider2D>().bounds.min.x, levelManger.spawnDick[i].GetComponent<BoxCollider2D>().bounds.max.x), UnityEngine.Random.Range(levelManger.spawnDick[i].GetComponent<BoxCollider2D>().bounds.min.y, levelManger.spawnDick[i].GetComponent<BoxCollider2D>().bounds.max.y));
                enemies.Add(Instantiate(enemy[x].prefabPath, pos, Quaternion.identity));
            }           
        }
    }
}
