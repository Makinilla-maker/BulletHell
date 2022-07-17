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

    public LevelManager levelManager;

    public float delayEnemy;
    [SerializeField] private float timeBetween;

    public float percentBasicEnemy;
    public float percentTankEnemy;

    public int enemyCuant = 2;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        timeBetween = delayEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        timeBetween += Time.deltaTime;
        if (timeBetween > delayEnemy && levelManager.step == Step.Step1 && !levelManager.playerObject.GetComponent<CharacterController2D>().isShopping)
        {
            CreateEnemy();
            timeBetween = 0;
        }
        StateMachine();
    }

    void StateMachine()
    {
        switch(levelManager.step)
        {
            //case 0:
            //    break;
            //case Step.Step1:
            //    delayEnemy = 10;
            //    percentBasicEnemy = 100;
            //    percentTankEnemy = 100 - percentBasicEnemy;
            //    break;
            //case Step.Step2:
            //    delayEnemy = ;
            //    percentBasicEnemy = 100;
            //    percentTankEnemy = 100 - percentBasicEnemy;
            //    break;
            //case Step.Step3:
            //    delayEnemy = 3.5f;
            //    percentBasicEnemy = 100;
            //    percentTankEnemy = 100 - percentBasicEnemy;
            //    break;
            //default:
            //    break;
        }
    }

    void CreateEnemy()
    {
        int x;
        float debug = UnityEngine.Random.value;
        if (debug < percentBasicEnemy/100) x = 0;
        else x = 1;
        
        for(int y = 0; y < enemyCuant; y++)
        {
            int i = UnityEngine.Random.Range(0, levelManager.spawners.Length);
            float a1 = UnityEngine.Random.Range(levelManager.spawners[i].GetComponent<BoxCollider2D>().bounds.min.x, levelManager.spawners[i].GetComponent<BoxCollider2D>().bounds.max.x);
            float a2 = UnityEngine.Random.Range(levelManager.spawners[i].GetComponent<BoxCollider2D>().bounds.min.y, levelManager.spawners[i].GetComponent<BoxCollider2D>().bounds.max.y);
            Vector3 pos = new Vector3(a1, a2,-0.2f);
            enemies.Add(Instantiate(enemy[x].prefabPath, pos, Quaternion.identity));
        }           
        
    }
}
