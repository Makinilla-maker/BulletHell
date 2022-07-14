using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Character
{
    public GameObject prefab;

    public string name;
    public int life;
    public Weapon weapon;
    public float xp;
    public int level;
    public int money;
    public int weaponsUnlocked;


    //public void Initialize(string n, int l, float x, int lvl,int m,int w)
    //{
    //    name = n;
    //    life = l;
    //    xp = x;
    //    level = lvl;
    //    money = m;
    //    weaponsUnlocked = w;
    //}
}
