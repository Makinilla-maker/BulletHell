using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialoge[] dialogue;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            FindObjectOfType<DialogeSystem>().StartDialogue(dialogue, collision.gameObject);
        }
    }
}
