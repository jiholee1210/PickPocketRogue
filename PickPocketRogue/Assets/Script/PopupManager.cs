using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject weaponPopupWindow;
    public GameObject ShopPopupWindow;

    public TMP_Text weaponName;
    public TMP_Text weaponDetail;

    public TMP_Text[] weaponNames;
    public TMP_Text[] weaponDetails;

    public Weapon newWeapon;
    public Weapon[] weaponList;

    public Armor newArmor;

    public Image dropWeapon;
    public Image[] shopWeapon;

    private PlayerManager playerManager;
    private int getId = 0;
    // Start is called before the first frame update
    void Start()
    {
        weaponPopupWindow.SetActive(false);    
        playerManager = FindObjectOfType<PlayerManager>();
    }

    public void ShowPopup(Weapon weapon) {
        newWeapon = weapon;
        getId = 1;
        ChangeWeaponText(dropWeapon, weaponName, weaponDetail, weapon);
        weaponPopupWindow.SetActive(true);
    }

    public void ShowPopup(Armor armor) {
        newArmor = armor;
        getId = 2;
        ChangeWeaponText(dropWeapon, weaponName, weaponDetail, armor);
        weaponPopupWindow.SetActive(true);
    }

    public void ShopPopup(Weapon[] weapon) {
        weaponList = weapon;

        for (int i = 0; i < weapon.Length; i++) {
            ChangeWeaponText(shopWeapon[i], weaponNames[i], weaponDetails[i], weapon[i]);
        }
        ShopPopupWindow.SetActive(true);
    }

    private void ChangeWeaponText(Image image, TMP_Text name, TMP_Text detail, Weapon weapon) {
        image.sprite = weapon.GetSprite();
        name.text = weapon.GetWeaponName().ToString();
        detail.text = "공격력 : " + weapon.GetWeaponDmg() + 
                            "\n타입   : " + weapon.GetWeaponType() + 
                            "\n레어도 : " + weapon.GetWeaponRarity();
    }
    
    private void ChangeWeaponText(Image image, TMP_Text name, TMP_Text detail, Armor armor) {
        image.sprite = armor.GetSprite();
        name.text = armor.GetArmorName().ToString();
        detail.text = "방어력 : " + armor.GetArmorDef() + 
                            "\n타입   : " + armor.GetArmorType() + 
                            "\n레어도 : " + armor.GetArmorRarity();
    }
    
    public void OnYesButtonClicked() {
        if(getId == 1) {
            playerManager.AddWeaponToInventory(newWeapon);
        } else {
            playerManager.AddWeaponToInventory(newArmor);
        }
        weaponPopupWindow.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnNoButtonClicked() {
        weaponPopupWindow.SetActive(false);
        Time.timeScale = 1;
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
        Time.timeScale = 1;
    }
}
