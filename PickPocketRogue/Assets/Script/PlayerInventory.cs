using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    private Weapon weapon = null;
    private Armor armor;



    public void SetWeapon(Weapon weapon) {
        this.weapon = weapon;
        Debug.Log("플레이어 무기 장착 : " + weapon.GetWeaponName());
    }

    public void SetArmor(Armor armor) {
        this.armor = armor;
    }

    public Weapon GetWeapon() {
        return weapon;
    }

    public Armor GetArmor() {
        return armor;
    }
}
