using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum PlayerState
{
    NONE,
    CANTMOVE,
    NORMAL,
    ISSHOOTING,
    RELOADING,
    HITED,
}
public class CharacterController2D : MonoBehaviour
{
    public LevelManager levelManager;
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    
    public GameObject bulletPrefab;
    public GameObject bulletParent;

    public float bulletForce = 5f;
    public float moveSpeed = 5f;
    public float canfire;
    public float inmortalCount = 3;
    public float whileshooting = 1;

    public Character character;

    public int money;

    public bool firstTime;
    public PlayerState state;

    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        character = levelManager.player;
        bulletParent = GameObject.Find("Trash");
        canfire = .5f;
        DontDestroyOnLoad(gameObject);
        state = PlayerState.NORMAL;
        if (levelManager.level == Level.LVL1 && levelManager.step == Step.ALLEY) firstTime = true;
    }

    void Update()
    {
        if(state != PlayerState.CANTMOVE)
        {
            Movement();
            if(levelManager.level != Level.BASE && !firstTime && state != PlayerState.RELOADING)
            {
                //CheckLevel();
                Attack();
            }
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }
        if(state == PlayerState.HITED)
        {
            InmortalCountDown();
        }
        if(character.life<1)
        {
            //Death
        }
    }
    void InmortalCountDown()
    {
        inmortalCount -= Time.deltaTime;
        if (inmortalCount < 0)
        {
            state = PlayerState.NORMAL;
            inmortalCount = 3;
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
        movement.Normalize();
    }
    void Attack()
    {
        if (Input.GetButton("Fire1") && Time.time > canfire)
        {
            state = PlayerState.ISSHOOTING;
            canfire = Time.time + character.weapon.attackSpeed;
            Vector2 direction;
            direction = cam.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity, bulletParent.transform);
            bullet.GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletForce);
            bullet.GetComponent<Bullet>().parent = this.gameObject;
            whileshooting = 3;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 direction;
            direction = cam.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity, bulletParent.transform);
            bullet.GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletForce);
            bullet.GetComponent<Bullet>().parent = this.gameObject;
        }
        if(state == PlayerState.ISSHOOTING)
        {
            whileshooting -= Time.deltaTime;
            if(whileshooting <0)    state = PlayerState.NORMAL;
        }
    }
    void FixedUpdate()
    {
        if (state != PlayerState.ISSHOOTING)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else if (state == PlayerState.ISSHOOTING)
        {
            rb.MovePosition(rb.position + movement * moveSpeed/2 * Time.fixedDeltaTime);
        }
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
            if(levelManager.level != Level.LVL1)    
                Destroy(collision.gameObject);
        }
        if(collision.transform.tag == "Enemy")
        {
            if(state != PlayerState.HITED)
            {
                character.life--;
                state = PlayerState.HITED;
            }
            
        }
    }
}
