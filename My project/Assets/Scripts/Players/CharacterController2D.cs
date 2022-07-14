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
[System.Serializable]
public class CharacterController2D : MonoBehaviour
{
    public LevelManager levelManager;
    public Rigidbody2D rb;
    public Camera cam;
    public AudioSource audioSource;
    public AudioClip clipStep;

    Vector2 movement;
    
    public GameObject bulletPrefab;
    public GameObject bulletParent;

    public float bulletForce = 5f;
    public float moveSpeed = 5f;
    public float canfire;
    public float inmortalCount = 3;
    public float whileshooting = 1;

    public Character character;
    

    public bool firstTime;
    public bool isMoving;
    public PlayerState state;
    public int level;

    public CharacterController2D (CharacterController2D player)
    {
        cam = player.cam;
        audioSource = player.audioSource;
        clipStep = player.clipStep;
        movement = player.movement;
        canfire = player.canfire;
        inmortalCount = player.inmortalCount;
        bulletForce = player.bulletForce;
        bulletParent = player.bulletParent;
        bulletPrefab = player.bulletPrefab;

    }
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        character = levelManager.player;
        canfire = .5f;
        DontDestroyOnLoad(gameObject);
        state = PlayerState.NORMAL;
        if (levelManager.level == Level.LVL0 && levelManager.step == Step.ALLEY) firstTime = true;
        audioSource = gameObject.GetComponent<AudioSource>();
        level = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("Base");
            levelManager.level = Level.BASE;
            firstTime = false;
        }
        if (state != PlayerState.CANTMOVE)
        {
            Movement();
            if(levelManager.level != Level.BASE && !firstTime && state != PlayerState.RELOADING)
            {
                CheckLevel();
                Attack();
            }
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
            audioSource.Stop();
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
            inmortalCount = 1;
        }
    }
    void CheckLevel()
    {
        float xpReferencia;
        xpReferencia = (float)(character.level/0.009);
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

        if (movement != Vector2.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
    void Attack()
    {
        if (Input.GetButton("Fire1") && Time.time > canfire)
        {
            audioSource.clip = character.weapon.shootNoise;
            audioSource.Play();
            state = PlayerState.ISSHOOTING;
            canfire = Time.time + (1/character.weapon.attackSpeed);
            Vector2 direction;
            direction = cam.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity, bulletParent.transform);
            bullet.GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletForce);
            bullet.GetComponent<Bullet>().parent = this.gameObject;
            whileshooting = 1;
        }
        if (state == PlayerState.ISSHOOTING)
        {
            whileshooting -= Time.deltaTime;
            if (whileshooting < 0) state = PlayerState.NORMAL;
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
        if(isMoving)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = clipStep;
                audioSource.Play();
            }                
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Play_base")
        {
            levelManager.SceneChanger(level);
        }
        if (collision.transform.tag == "Shop_base")
        {
            state = PlayerState.CANTMOVE;
        }
        if (collision.transform.tag == "Weapons")
        {
            levelManager.NewWeapon(collision.gameObject,this.gameObject);
            if(levelManager.level != Level.LVL0)    
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
