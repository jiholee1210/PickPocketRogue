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
    public Image[] rarity = new Image[4];
    public Sprite[] raritySprites;
    // Start is called before the first frame update
    void Start()
    {
        raritySprites = Resources.LoadAll<Sprite>("Sprites/Rarity");
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
                            "\n데미지 : " + playerManager.player.GetDefaultDmg() + " + " + weaponDmg +
                            "\n방어력 : " + playerManager.player.GetDefaultDef() + " + " + armorDef +
                            "\n훔치기 : " + playerManager.player.GetPickLevel() + "단계";
                            
    }

    public void SetPlayerHpText(PlayerManager playerManager) {
        playerHp.text = playerManager.player.GetHp() + " / " + playerManager.player.GetMaxHp();
    }

    public void SetPlayerWeapon(PlayerManager playerManager) {
        Sprite sprite;
        if(playerManager.playerInventory.GetWeapon() != null) {
            sprite = playerManager.playerInventory.GetWeapon().GetSprite();
            playerWeapon.sprite = sprite;
            rarity[0].sprite = raritySprites[playerManager.playerInventory.GetWeapon().GetWeaponRarity()];
        } else {
            sprite = Resources.Load<Sprite>("Sprites/None");
            playerWeapon.sprite = sprite;
            rarity[0].sprite = raritySprites[0];
        }
    }

    public void SetPlayerArmor(PlayerManager playerManager) {
        Sprite sprite;
        if(playerManager.playerInventory.GetArmor() != null) {
            sprite = playerManager.playerInventory.GetArmor().GetSprite();
            playerArmor.sprite = sprite;
            rarity[1].sprite = raritySprites[playerManager.playerInventory.GetArmor().GetArmorRarity()];
        } else {
            sprite = Resources.Load<Sprite>("Sprites/None");
            playerArmor.sprite = sprite;
            rarity[0].sprite = raritySprites[0];
        }
    }
}
