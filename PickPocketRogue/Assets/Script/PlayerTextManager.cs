using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTextManager : MonoBehaviour
{
    public Text playerHpText;
    public Text playerWeaponText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlayerStatText(PlayerManager playerManager) {
        float weaponDmg = playerManager.playerInventory.GetWeapon() != null ? playerManager.playerInventory.GetWeapon().GetWeaponDmg() : 0;

        playerHpText.text = "Lv : " + playerManager.player.GetLevel() +
                            "\nExp : " + playerManager.player.GetExp() +
                            "\nHp : " + playerManager.player.GetHp() + " / " + playerManager.player.GetMaxHp() +
                            "\nDmg : " + playerManager.player.GetDefaultDmg() + " + " + weaponDmg +
                            "\nDef : " + playerManager.player.GetDef();
        
    }

    public void SetPlayerWeaponText(PlayerManager playerManager) {
        if(playerManager.playerInventory.GetWeapon() != null) { 
            playerWeaponText.text = "Player Weapon : " + playerManager.playerInventory.GetWeapon().GetWeaponName();
        } else {
            playerWeaponText.text = "Player Weapon : 없음";
        }
    }
}
