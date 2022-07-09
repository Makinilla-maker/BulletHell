using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsGeneral : MonoBehaviour
{

    public string name;
    public float attackSpeed;
    public float damage;
    public AudioClip shootShoot;

    public Weapon weapon;
    private void Start()
    {
        weapon.Initialize(name, attackSpeed, damage, shootShoot);
    }
}
