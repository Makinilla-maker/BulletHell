using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Weapon
{
    public string name;
    public float attackSpeed;
    public float dmg;
    public AudioClip shootNoise;

    public void Initialize(string n, float a, float d, AudioClip s)
    {
        name = n;
        attackSpeed = a;
        dmg = d;
        shootNoise = s;
    }
}
