using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Character
{
    public GameObject prefab;

    public string name;
    public int life;
    public Weapon weapon;
    public float xp;
    public int level;

    public void Initialize(string n, int l, float x, int lvl)
    {
        name = n;
        life = l;
        xp = x;
        level = lvl;
    }
}
