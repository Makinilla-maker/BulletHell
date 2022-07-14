using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public Character character;
    public WeaponsGeneral[] weapons;

    public SaveData (Character player)
    {
        character = player;
        //weapons = saveData.weapons;
    }
}
