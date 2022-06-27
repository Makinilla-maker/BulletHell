using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Character
{
    public string name;
    public int life;
    public float attackSpeed;
    public float dmg;

    public void Initialize(string n, int l, float d, float a)
    {
        name = n;
        life = l;
        dmg = d;
        attackSpeed = a;
    }
}
