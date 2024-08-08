using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject weaponPopupWindow;
    public GameObject ShopPopupWindow;
    public GameObject StatPopupWindow;
    public Text weaponName;
    public Text weaponDetail;

    public Text[] weaponNames;
    public Text[] weaponDetails;

    public Weapon newWeapon;
    public Weapon[] weaponList;

    public Image dropWeapon;
    public Image[] shopWeapon;

    public Text playerStat;
    public Image playerWeapon;
    private bool isOpen = false;

    private PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        weaponPopupWindow.SetActive(false);    
        playerManager = FindObjectOfType<PlayerManager>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Tab)) {
            if(isOpen) {
                StatPopupWindow.SetActive(false);
                isOpen = false;
            } else {
                StatPopup();
                isOpen = true;
            }
        }
    }
    public void ShowPopup(Weapon weapon) {
        newWeapon = weapon;
        
        dropWeapon.sprite = weapon.GetSprite();
        weaponName.text = weapon.GetWeaponName().ToString();
        weaponDetail.text = "공격력 : " + weapon.GetWeaponDmg() + 
                            "\n타입 \t: " + weapon.GetWeaponType() + 
                            "\n레어도 : " + weapon.GetWeaponRarity();
        weaponPopupWindow.SetActive(true);
    }

    public void ShopPopup(Weapon[] weapon) {
        weaponList = weapon;

        for (int i = 0; i < weapon.Length; i++) {
            shopWeapon[i].sprite = weapon[i].GetSprite();
            weaponNames[i].text = weapon[i].GetWeaponName().ToString();
            weaponDetails[i].text = "공격력 : " + weapon[i].GetWeaponDmg() + 
                                "\n타입 \t: " + weapon[i].GetWeaponType() + 
                                "\n레어도 : " + weapon[i].GetWeaponRarity();
        }
        ShopPopupWindow.SetActive(true);
    }

    public void StatPopup() {
        Player player = playerManager.player;
        float weaponDmg = 0;
        if(playerManager.playerInventory.GetWeapon() != null) {
            playerWeapon.sprite = playerManager.playerInventory.GetWeapon().GetSprite();
            weaponDmg = playerManager.playerInventory.GetWeapon().GetWeaponDmg();
        } else {
            playerWeapon.sprite = Resources.Load<Sprite>("Sprites/None");
            weaponDmg = 0;
        }
        playerStat.text = "Lv : " + player.GetLevel() + 
                            "\nExp : " + player.GetExp() + " / " + player.GetMaxExp() +
                            "\nHp : " + player.GetHp() + " / " + player.GetMaxHp() +
                            "\nDmg : " + player.GetDefaultDmg() + " + " + weaponDmg +
                            "\nDef : " + player.GetDef();

        StatPopupWindow.SetActive(true);
    }
    
    public void OnYesButtonClicked() {
        playerManager.AddWeaponToInventory(newWeapon);
        weaponPopupWindow.SetActive(false);
    }

    public void OnNoButtonClicked() {
        weaponPopupWindow.SetActive(false);
    }

    public void OnClickBuyButton(Button clickedButton) {
        //playerManager.AddWeaponToInventory(newWeapon);
        Debug.Log("buy버튼 클릭");
        GameObject parentObject = clickedButton.transform.parent.gameObject;
        int index = parentObject.transform.GetSiblingIndex();
        Debug.Log((index + 1) + "번째 아이템 구매");
        playerManager.AddWeaponToInventory(weaponList[index]);
        parentObject.SetActive(false);
    }

    public void OnClickExitButton() {
        ShopPopupWindow.SetActive(false);
    }
}
