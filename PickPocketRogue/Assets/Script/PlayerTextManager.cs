using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTextManager : MonoBehaviour
{
    public TMP_Text playerStat;
    public TMP_Text playerHp;
    public Image playerWeapon;
    public Image playerArmor;
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
        float armorDef = playerManager.playerInventory.GetArmor() != null ? playerManager.playerInventory.GetArmor().GetArmorDef() : 0;

        playerStat.text = "레벨 : " + playerManager.player.GetLevel() +
                            "\n경험치 : " + playerManager.player.GetExp() + " / " + playerManager.player.GetMaxExp() +
                            "\n공격력 : " + playerManager.player.GetDefaultDmg() + " + " + weaponDmg +
                            "\n방어력 : " + playerManager.player.GetDefaultDef() + " + " + armorDef;
    }

    public void SetPlayerHpText(PlayerManager playerManager) {
        playerHp.text = playerManager.player.GetHp() + " / " + playerManager.player.GetMaxHp();
    }

    public void SetPlayerWeapon(PlayerManager playerManager) {
        Sprite sprite = playerManager.playerInventory.GetWeapon() != null ? playerManager.playerInventory.GetWeapon().GetSprite(): Resources.Load<Sprite>("Sprites/None");

        playerWeapon.sprite = sprite;
    }

    public void SetPlayerArmor(PlayerManager playerManager) {
        Sprite sprite = playerManager.playerInventory.GetArmor() != null ? playerManager.playerInventory.GetArmor().GetSprite(): Resources.Load<Sprite>("Sprites/None");

        playerArmor.sprite = sprite;
    }
}
