using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTOPlayer : MonoBehaviour
{
    public Transform target = null;
    public float speed;
    bool isPicked;

    private void Update()
    {
        if(target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPicked)
        {
            target = collision.gameObject.GetComponentInParent<Transform>();
            isPicked = true;
        }
    }
}
