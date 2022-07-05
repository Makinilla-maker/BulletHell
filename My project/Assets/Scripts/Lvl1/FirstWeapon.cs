using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstWeapon : MonoBehaviour
{
    public Transform spawn;
    public GameObject enemy;
    public GameObject canvas;
    bool a;
    CharacterController2D characterController;
    

    private void Update()
    {
        if (a && Input.GetMouseButtonDown(0))
        {
            characterController.state = PlayerState.NORMAL;
            Destroy(canvas);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("adasdasdasdasdasdad");
            Instantiate(enemy, spawn.position, Quaternion.identity);
            characterController = GameObject.Find("LevelManager").GetComponent<LevelManager>().playerObject.GetComponent<CharacterController2D>();
            characterController.state = PlayerState.CANTMOVE;
            canvas.SetActive(true);
            a = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
