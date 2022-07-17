using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int type;

    public GameObject parent;
    public float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(type == 0)
        {
            if (timer > 5)
            {
                Destroy(this.gameObject);
            }
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy" && !parent.GetComponent<CharacterController2D>().isPiercing)
            Destroy(gameObject);
    }
}
