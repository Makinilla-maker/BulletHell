using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject[] allweapons;
    public GameObject selectedWeapon;
    public GameObject[] allUI;

    public GameObject[] damage;
    public GameObject[] attackSpeed;
    public GameObject[] reloadTime;

    public void StartShop()
    {
        FindObjectOfType<LevelManager>().playerObject.GetComponent<CharacterController2D>().state = PlayerState.CANTMOVE;
        for (int i = 0; i < allUI.Length; i++)
        {
            allUI[i].SetActive(true);
        }
        selectedWeapon = allweapons[0];
        UpdateStats();
    }
    public void UpdateStats()
    {
        int damageInFive = (int)selectedWeapon.GetComponent<WeaponsGeneral>().weapon.dmg / 5;
        for (int i = 0; i < damageInFive; i++)
        {
            damage[i].SetActive(true);
        }

        int asInFive = (int)selectedWeapon.GetComponent<WeaponsGeneral>().weapon.attackSpeed / 5;
        Debug.Log(asInFive);
        for (int i = 0; i < asInFive; i++)
        {
            attackSpeed[i].SetActive(true);
        }

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
        FindObjectOfType<LevelManager>().playerObject.GetComponent<CharacterController2D>().state = PlayerState.NORMAL;
    }
    public void AddDmg()
    {
        selectedWeapon.GetComponent<WeaponsGeneral>().weapon.dmg += 5;
        Debug.Log(selectedWeapon.GetComponent<WeaponsGeneral>().weapon.dmg);
        UpdateStats();
    }
}
