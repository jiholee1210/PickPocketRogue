using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor
{
    private int armorId;
    private string armorName;
    private Sprite armorSprite;
    private int armorRarity;
    private float armorDef;
    private string armorType;
    private int armorTypeCode;
    private Sprite armorTypeSprite;

    public Armor() {

    }

    public Armor(int _armorId, string _armorName, Sprite _armorSprite, int _armorRarity, float _armorDef, int _armorTypeCode, Sprite sprite) {
        this.armorId = _armorId;
        this.armorName = _armorName;
        this.armorSprite = _armorSprite;
        this.armorRarity = _armorRarity;
        this.armorDef = _armorDef;
        this.armorTypeCode = _armorTypeCode;
        switch (_armorTypeCode) {
            case 1:
                this.armorType = "물리방어";
                break;
            case 2:
                this.armorType = "관통방어";
                break;
            case 3:
                this.armorType = "마법저항";
                break;
        }
        this.armorTypeSprite = sprite;
    }

    public static Armor SetArmor(int armorId, Sprite armorSprite) {
        Armor armor = null;

        switch(armorId) {
            case 0:
                armor = new Armor(0, "armor", armorSprite, 2, 3f, 1, Resources.Load<Sprite>("Sprites/hit type"));
                break;
        }

        return armor;
    }

    public string GetArmorName() {
        return armorName;
    }
    public int GetArmorRarity() {
        return armorRarity;
    }
    public float GetArmorDef() {
        return armorDef;
    }
    public int GetArmorTypeCode() {
        return armorTypeCode;
    }
    public string GetArmorType() {
        return armorType;
    }
    public Sprite GetSprite() {
        return armorSprite;
    }

    public Sprite GetTypeSprite() {
        return armorTypeSprite;
    }
}
