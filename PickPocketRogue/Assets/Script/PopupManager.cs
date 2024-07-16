using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject popupWindow;
    public Text weaponName;
    public Text weaponDetail;
    public Button yesBtn;
    public Button noBtn;
    public Weapon newWeapon;

    // Start is called before the first frame update
    void Start()
    {
        popupWindow.SetActive(false);    
    }

    public void ShowPopup(Weapon weapon) {
        newWeapon = weapon;
        
        weaponName.text = weapon.GetWeaponName().ToString();
        weaponDetail.text = "공격력 : " + weapon.GetWeaponDmg() + 
                            "\n타입 \t: " + weapon.GetWeaponType() + 
                            "\n레어도 : " + weapon.GetWeaponRarity();
        popupWindow.SetActive(true);
    }

    public void OnYesButtonClicked() {
        PlayerManager playerManager = FindObjectOfType<PlayerManager>();
        playerManager.AddWeaponToInventory(newWeapon);
        popupWindow.SetActive(false);
    }

    public void OnNoButtonClicked() {
        popupWindow.SetActive(false);
    }
}
