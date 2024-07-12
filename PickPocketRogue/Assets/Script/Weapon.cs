using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon
{
    public enum WeaponName {
        Stick,
        Sword,
        Bow,
        Shield,
        Staff,
    }

    private WeaponName weaponName;
    private int weaponRarity;
    private float weaponDmg;
    private int weaponType; // 1이 타격, 2가 관통, 3이 마법
    private bool canGet;

    public Weapon() {

    }

    public Weapon(WeaponName _weaponName, int _weaponRarity, float _weaponDmg, int _weaponType, bool _canGet) {
        this.weaponName = _weaponName;
        this.weaponRarity = _weaponRarity;
        this.weaponDmg = _weaponDmg;
        this.weaponType = _weaponType;
        this.canGet = _canGet;
    }

    public static Weapon SetWeapon(WeaponName weaponName) {
        Weapon weapon = null;

        switch(weaponName) {
            case WeaponName.Stick:
                weapon = new Weapon(WeaponName.Stick, 0, 1f, 1, false);
                break;
            case WeaponName.Bow:
                weapon = new Weapon(WeaponName.Bow, 0, 3f, 2, false);
                break;
            case WeaponName.Staff:
                weapon = new Weapon(WeaponName.Staff, 0, 2f, 3, false);
                break;
            case WeaponName.Sword:
                weapon = new Weapon(WeaponName.Sword, 0, 4f, 2, false);
                break;
            case WeaponName.Shield:
                weapon = new Weapon(WeaponName.Shield, 0, 3f, 1, false);
                break;
        }

        return weapon;
    }

    public WeaponName GetWeaponName() {
        return weaponName;
    }
    public int GetWeaponRarity() {
        return weaponRarity;
    }
    public float GetWeaponDmg() {
        return weaponDmg;
    }
    public float GetWeaponType() {
        return weaponType;
    }
    public bool GetCanGet() {
        return canGet;
    }
    public void SetCanGet(bool canGet) {
        this.canGet = canGet;
    }
}
