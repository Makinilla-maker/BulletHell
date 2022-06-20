using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int live;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject player;
    public float speed = 100;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        live = 3;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(live < 1)
        {
            Destroy(this.gameObject);
            levelManager.enemies.Remove(this.gameObject);
        }
    }
    void FixedUpdate()
    {
        Vector2 dist = player.transform.position - gameObject.transform.position;
        rb.MovePosition(rb.position + dist.normalized * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("S");
        if (other.transform.tag == "Bullet")
        {
            live--;
        }
    }
}
