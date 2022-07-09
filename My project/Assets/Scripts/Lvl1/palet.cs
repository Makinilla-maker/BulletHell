using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palet : MonoBehaviour
{
    public int life = 3;
    private void Update()
    {
        if(life < 1)    Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Bullet")
        {
            life--;
            Destroy(collision.gameObject);
        }
    }
}
