using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionableCharacters : MonoBehaviour
{

    public string name;
    public int life;
    public float damage;
    public float attackspeed;

    public Character character;
    private void Start()
    {
        character.Initialize(name, life, damage, attackspeed);
    }
}
