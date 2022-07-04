using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController2D : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    
    public GameObject bulletPrefab;
    public GameObject bulletParent;

    public float bulletForce = 5f;
    public float moveSpeed = 5f;

    public Character character;
    public int money;

    public float canfire;

    public LevelManager levelManager;
    public bool firstTime;
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        character = levelManager.player;
        bulletParent = GameObject.Find("Trash");
        canfire = .5f;
        DontDestroyOnLoad(gameObject);
        if (levelManager.level == Level.LVL1 && levelManager.step == Step.ALLEY) firstTime = true;
    }

    void Update()
    {
        if(levelManager.step != Step.CANTMOVE)
        {
            Movement();
            if(levelManager.level != Level.BASE && !firstTime)
            {
                //CheckLevel();
                Attack();
            }
        }
    }
    void CheckLevel()
    {
        float xpReferencia;
        xpReferencia = (float)((6/5 * Mathf.Pow(character.level, 3)) - (15 * Mathf.Pow(character.level,2)) + (100 * character.level) - 140);
        Debug.Log(character.level);
        Debug.Log(xpReferencia);
        if (character.xp > xpReferencia)
        {
            character.xp = 0;
            character.level++;
        }
    }
    void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void Attack()
    {
        if (Input.GetButton("Fire1") && Time.time > canfire)
        {
            canfire = Time.time + character.weapon.attackSpeed;
            Vector2 direction;
            direction = cam.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity, bulletParent.transform);
            bullet.GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletForce);
            bullet.GetComponent<Bullet>().parent = this.gameObject;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 direction;
            direction = cam.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity, bulletParent.transform);
            bullet.GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletForce);
            bullet.GetComponent<Bullet>().parent = this.gameObject;
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Play_base")
        {
           // levelManager.NoSePorqueTengoQueHacerEsto();
        }
        if(collision.transform.tag == "Weapons")
        {
            levelManager.NewWeapon(collision.gameObject,this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
