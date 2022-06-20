using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class LevelManager : MonoBehaviour
{
    [SerializeField] private float timer = 0;
    public float delayEnemy;
    [SerializeField] private float timeBetween = 0;


    //Enemies
    public GameObject enemy;
    public List<GameObject> enemies = new List<GameObject>();
    public Vector3 place;

    //Players
    public Players[] players;
    public GameObject[] playerObject;
    [SerializeField] private List<GameObject> spawnDick = new List<GameObject>();

    private void Awake()
    {
        playerObject = new GameObject[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].name != "")
                playerObject[i] = Instantiate(players[i].prefab);
        }

        GameObject[] a = new GameObject[4];
        a = GameObject.FindGameObjectsWithTag("Spawnpoint");
        for(int i = 0; i <= 3; i++)
        {
            Debug.Log(i);
            spawnDick.Add(a[i]);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timeBetween += Time.deltaTime;
        if(timeBetween > delayEnemy)
        {
            CreateEnemy();
            timeBetween = 0;
        }
    }
    void CreateEnemy()
    {
        for (int j = 0; j < playerObject.Length; j++)
        {
            //int i = UnityEngine.Random.Range(0, 2);
            //Debug.Log(i);
            //if (i == 0) place.x = (float)(playerObject[j].transform.position.x - 0.5 * Screen.width);
            //else place.x = (float)(playerObject[j].transform.position.x + 0.5 * Screen.width);

            //int x = UnityEngine.Random.Range(0, 2);
            //Debug.Log(x);
            //if (x == 0) place.y = (float)(playerObject[j].transform.position.y - 0.5 * Screen.height);
            //else place.y = (float)(playerObject[j].transform.position.y + 0.5 * Screen.height);
            //place.z = 0;

            //place = Camera.main.ScreenToWorldPoint(place);


            //enemies.Add(Instantiate(enemy,new Vector3(place.x - playerObject[j].transform.position.x, place.y - playerObject[j].transform.position.y, 0),Quaternion.identity));

            int i = UnityEngine.Random.Range(0, 3);
            Vector2 pos = new Vector2(UnityEngine.Random.Range(spawnDick[i].GetComponent<BoxCollider2D>().bounds.min.x, spawnDick[i].GetComponent<BoxCollider2D>().bounds.max.x), UnityEngine.Random.Range(spawnDick[i].GetComponent<BoxCollider2D>().bounds.min.y, spawnDick[i].GetComponent<BoxCollider2D>().bounds.max.y));
            enemies.Add(Instantiate(enemy, pos, Quaternion.identity));

        }
    }
}
