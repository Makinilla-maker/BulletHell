using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sturion : MonoBehaviour
{
    public string name;
    public int life;
    public float attackSpeed;
    public float canfire;
    public float dmg;
    // Start is called before the first frame update
    void Start()
    {
        name = "Sturion";
        life = 3;
        attackSpeed = .5f;
        canfire = .5f;
        dmg = 5;
    }
}
