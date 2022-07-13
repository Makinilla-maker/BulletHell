using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public LevelManager levelManager;
    public CharacterController2D character;
    public GameObject[] allweapons;
    public GameObject selectedWeapon;
    public GameObject[] allUI;

    public GameObject[] damage;
    public int goldCostDmg;
    public GameObject[] attackSpeed;
    public int goldCostAS;
    public GameObject[] reloadTime;
    public int goldCostRT;

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        character = levelManager.playerObject.GetComponent<CharacterController2D>();
    }

    public void StartShop()
    {
        for (int i = 0; i < allUI.Length; i++)
        {
            allUI[i].SetActive(true);
        }
        selectedWeapon = allweapons[0];
        UpdateStats();
    }
    public void UpdateStats()
    {
        ///////////////////////////////Damage///////////////////////////////
        int damageInFive = (int)selectedWeapon.GetComponent<WeaponsGeneral>().weapon.dmg / 5;
        for (int i = 0; i < damage.Length; i++)
        {
            Debug.Log("ocultar" + i);
            damage[i].SetActive(false);
        }
        for (int i = 0; i < damageInFive; i++)
        {
            Debug.Log("enseñar" + i);
            damage[i].SetActive(true);
        }

        ///////////////////////////////AttackSpeed///////////////////////////////
        int asInFive = (int)selectedWeapon.GetComponent<WeaponsGeneral>().weapon.attackSpeed / 1;
        for (int i = 0; i < attackSpeed.Length; i++)
        {
            attackSpeed[i].SetActive(false);
        }
        for (int i = 0; i < asInFive; i++)
        {
            attackSpeed[i].SetActive(true);
        }

        ///////////////////////////////ReloadTime///////////////////////////////
        //int reloadInFive = (int)selectedWeapon.GetComponent<WeaponsGeneral>().weapon.rea / 5;
        //for (int i = 0; i < asInFive; i++)
        //{
        //    attackSpeed[i].SetActive(true);
        //}
    }
    public void ExitShop(GameObject bckButton)
    {
        bckButton.SetActive(false);
        for (int i = 0; i < allUI.Length; i++)
        {
            allUI[i].SetActive(false);
        }
        for (int i = 0; i < damage.Length; i++)
        {
            damage[i].SetActive(false);
        }
        for (int i = 0; i < attackSpeed.Length; i++)
        {
            attackSpeed[i].SetActive(false);
        }
        character.state = PlayerState.NORMAL;
    }
    public void AddDmg()
    {
        if(character.money >= goldCostDmg)
        {
            character.money -= goldCostDmg;
            selectedWeapon.GetComponent<WeaponsGeneral>().weapon.dmg += 5;
        }
        UpdateStats();
    }
    public void SetNewWeapon(string name)
    {
        for(int i = 0; i < allweapons.Length;i++)
        {
            if (allweapons[i].GetComponent<WeaponsGeneral>().name == name)
            { 
                selectedWeapon = allweapons[i];
            }
        }
        UpdateStats();
    }
}
