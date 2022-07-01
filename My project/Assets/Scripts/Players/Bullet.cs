using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int type;

    public GameObject parent;

    private Vector2 screenBounds;
    public float lifeTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(type == 0)
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime < 0)
            {
                Destroy(this.gameObject);
            }
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
            Destroy(gameObject);
    }
}
