using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    private Weapon weapon = null;
    private Armor armor = null;
    private MainAcc mainAcc = null;
    private SubAcc subAcc = null;

    public void SetWeapon(Weapon weapon) {
        this.weapon = weapon;
        Debug.Log("플레이어 무기 장착 : " + weapon.GetWeaponName());
    }

    public void SetArmor(Armor armor) {
        this.armor = armor;
        Debug.Log("플레이어 방어구 장착 : " + armor.GetArmorName());
    }

    public void SetMainAcc(MainAcc mainAcc) {
        this.mainAcc = mainAcc;
        Debug.Log("플레이어 주 악세사리 장착 : " + mainAcc.GetAccName());
    }

    public void SetSubAcc(SubAcc subAcc) {
        this.subAcc = subAcc;
        Debug.Log("플레이어 보조 악세사리 장착 : " + subAcc.GetAccName());
    }

    public Weapon GetWeapon() {
        return weapon;
    }

    public Armor GetArmor() {
        return armor;
    }

    public MainAcc GetMainAcc() {
        return mainAcc;
    }

    public SubAcc GetSubAcc() {
        return subAcc;
    }
}
