using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject parent;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "XP")
        {
            parent.GetComponent<CharacterController2D>().character.xp += 15;
            StartCoroutine(ParticleEffectXP(collision));
        }
    }
    public IEnumerator ParticleEffectXP(Collider2D collision)
    {
        //Effects starts
        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(collision.gameObject);
    }
}
