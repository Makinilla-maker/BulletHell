using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum TypePowerUp
{
    ATTACKSPEED,
    TWOSHOOT,
    THREESHOOT,
    FOURSHOOT,
    PIERCING,
    DAMAGE,
}
[System.Serializable]
public class PowerUp
{
    public string name;
    public string description;
    PowerUp parent;
    public bool isPicked;
    public TypePowerUp type;
}
