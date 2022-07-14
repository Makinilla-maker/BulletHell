using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] private float live;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject player;
    public GameObject exp;
    public float speed = 85;
    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        live = enemyManager.enemy[(int)EnemyType.BASIC].lives;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(live < 1)
        {
            Destroy(this.gameObject);
            enemyManager.enemies.Remove(this.gameObject);
            if(levelManager.level != Level.LVL0)    Instantiate(exp, this.gameObject.transform.position, Quaternion.identity);
        }
    }
    void FixedUpdate()
    {
        if(levelManager.playerObject.GetComponent<CharacterController2D>().state != PlayerState.CANTMOVE && levelManager.playerObject.GetComponent<CharacterController2D>().state != PlayerState.SHOP)
        {
            Vector2 dist = player.transform.position - gameObject.transform.position;
            rb.MovePosition(rb.position + dist.normalized * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Bullet")
        {
            live -= other.GetComponent<Bullet>().parent.GetComponent<CharacterController2D>().character.weapon.dmg;
        }
    }
}
