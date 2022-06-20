using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum EnemyType
{
    BASIC,
    TANK,
    BOSS,
}

[Serializable]
public class Enemy
{
    public string name;
    public GameObject prefabPath;

    public EnemyType type;

    public int lives;
    public int xp;
    public int gold;

}
