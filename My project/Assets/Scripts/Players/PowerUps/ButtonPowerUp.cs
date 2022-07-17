using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonPowerUp : MonoBehaviour, IPointerEnterHandler
{
    public PowerUp powerUp;
    public CharacterController2D player;
    public GameObject canvas;
    public TMP_Text text;

    private void Start()
    {
        player = GameObject.Find("LevelManager").GetComponent<LevelManager>().playerObject.GetComponent<CharacterController2D>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.text = powerUp.description;
    }

    public void UsePowerUp()
    {
        switch(powerUp.type)
        {
            case TypePowerUp.ATTACKSPEED:
                player.character.weapon.attackSpeed += (player.character.weapon.attackSpeed * 0.2f);
                break;
            case TypePowerUp.DAMAGE:
                player.character.weapon.dmg += (player.character.weapon.dmg * 0.5f);
                break;
            case TypePowerUp.TWOSHOOT:
                break;
            case TypePowerUp.THREESHOOT:
                break;
            case TypePowerUp.FOURSHOOT:
                break;
            case TypePowerUp.PIERCING:
                player.isPiercing = true;
                break;
            default:
                break;
        }
        powerUp.isPicked = true;
        canvas.SetActive(false);
        player.state = PlayerState.NORMAL;
        player.isShopping = false;
    }
}
