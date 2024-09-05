using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    public enum WeaponName {
        Stick,
        Sword,
        Bow,
        Shield,
        Staff,
    }

    private int weaponId;
    private WeaponName weaponName;
    private Sprite weaponSprite;
    private int weaponRarity;
    private float weaponDmg;
    private int weaponTypeCode; // 1이 타격, 2가 관통, 3이 마법
    private string weaponType;
    private Sprite weaponTypeSprite;
    private bool canGet;

    public Weapon() {

    }

    public Weapon(int _weaponId, WeaponName _weaponName, Sprite _weaponSprite, int _weaponRarity, float _weaponDmg, int _weaponTypeCode, bool _canGet, Sprite sprite) {
        this.weaponId = _weaponId;
        this.weaponSprite = _weaponSprite;
        this.weaponName = _weaponName;
        this.weaponRarity = _weaponRarity;
        this.weaponDmg = _weaponDmg;
        this.weaponTypeCode = _weaponTypeCode;
        switch(_weaponTypeCode) {
            case 1:
                this.weaponType = "타격";
                break;
            case 2:
                this.weaponType = "관통";
                break;
            case 3:
                this.weaponType = "마법";
                break;
        }
        this.canGet = _canGet;
        this.weaponTypeSprite = sprite;
    }

    public static Weapon SetWeapon(int weaponId, Sprite weaponSprite) {
        Weapon weapon = null;

        switch(weaponId) {
            case 0:
                weapon = new Weapon(0, WeaponName.Stick, weaponSprite, 0, 1f, 1, false, Resources.Load<Sprite>("Sprites/hit type"));
                break;
            case 1:
                weapon = new Weapon(1, WeaponName.Bow, weaponSprite, 1, 3f, 2, false, Resources.Load<Sprite>("Sprites/pierce type"));
                break;
            case 2:
                weapon = new Weapon(2, WeaponName.Staff, weaponSprite, 3, 2f, 3, false, Resources.Load<Sprite>("Sprites/magic type"));
                break;
            case 3:
                weapon = new Weapon(3, WeaponName.Sword, weaponSprite, 4, 4f, 2, false, Resources.Load<Sprite>("Sprites/pierce type"));
                break;
            case 4:
                weapon = new Weapon(4, WeaponName.Shield, weaponSprite, 2, 3f, 1, false, Resources.Load<Sprite>("Sprites/hit type"));
                break;
        }

        return weapon;
    }
    public int GetID() {
        return weaponId;
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
    public int GetWeaponTypeCode() {
        return weaponTypeCode;
    }
    public string GetWeaponType() {
        return weaponType;
    }
    public bool GetCanGet() {
        return canGet;
    }
    public Sprite GetSprite() {
        return weaponSprite;
    }

    public Sprite GetTypeSprite() {
        return weaponTypeSprite;
    }
    
    public void SetCanGet(bool canGet) {
        this.canGet = canGet;
    }
}
