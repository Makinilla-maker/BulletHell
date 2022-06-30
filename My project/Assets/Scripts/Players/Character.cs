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
    public float xp;
    public int level;

    public void Initialize(string n, int l, float d, float a, float x, int lvl)
    {
        name = n;
        life = l;
        dmg = d;
        attackSpeed = a;
        xp = x;
        level = lvl;
    }
}
