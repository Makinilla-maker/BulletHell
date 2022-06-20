using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int type;

    public GameObject parent;

    private Vector2 screenBounds;

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
            if (gameObject.transform.position.x > screenBounds.x * 1.5 || gameObject.transform.position.y > screenBounds.y * 1.5 || gameObject.transform.position.x < (Camera.main.transform.position.x - screenBounds.x) * 1.5 || gameObject.transform.position.y < (Camera.main.transform.position.y - screenBounds.y) * 1.5)
            {
                Destroy(this.gameObject);
            }
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.tag);
        Debug.Log("Trigger enter");
        if (collision.transform.tag == "Enemy")
            Destroy(gameObject);
    }
}
