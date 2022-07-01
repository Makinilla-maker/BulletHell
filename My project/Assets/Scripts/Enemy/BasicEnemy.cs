using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] private float live;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject player;
    public GameObject exp;
    public float speed = 85;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        live = enemyManager.enemy[(int)EnemyType.BASIC].lives;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(live < 1)
        {
            PhotonNetwork.Instantiate(exp.name, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            enemyManager.enemies.Remove(this.gameObject);
        }
    }
    void FixedUpdate()
    {
        Vector2 dist = player.transform.position - gameObject.transform.position;
        rb.MovePosition(rb.position + dist.normalized * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Bullet")
        {
            live -= other.GetComponent<Bullet>().parent.GetComponent<CharacterController2D>().character.dmg;
        }
    }
}
