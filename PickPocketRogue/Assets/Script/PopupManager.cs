using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject weaponPopupWindow;
    public GameObject ShopPopupWindow;
    public Text weaponName;
    public Text weaponDetail;

    public Text[] weaponNames;
    public Text[] weaponDetails;

    public Weapon newWeapon;
    public Weapon[] weaponList;
    
    private PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        weaponPopupWindow.SetActive(false);    
        playerManager = FindObjectOfType<PlayerManager>();
    }

    void Update() {
        
    }
    public void ShowPopup(Weapon weapon) {
        newWeapon = weapon;
        
        weaponName.text = weapon.GetWeaponName().ToString();
        weaponDetail.text = "공격력 : " + weapon.GetWeaponDmg() + 
                            "\n타입 \t: " + weapon.GetWeaponType() + 
                            "\n레어도 : " + weapon.GetWeaponRarity();
        weaponPopupWindow.SetActive(true);
    }

    public void ShopPopup(Weapon[] weapon) {
        weaponList = weapon;

        for (int i = 0; i < weapon.Length; i++) {
            weaponNames[i].text = weapon[i].GetWeaponName().ToString();
            weaponDetails[i].text = "공격력 : " + weapon[i].GetWeaponDmg() + 
                                "\n타입 \t: " + weapon[i].GetWeaponType() + 
                                "\n레어도 : " + weapon[i].GetWeaponRarity();
        }
        ShopPopupWindow.SetActive(true);
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
