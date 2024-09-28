using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAcc
{
    private int accId;
    private string accName;
    private Sprite accSprite;
    private int accRarity;
    private int pickLevel;

    public MainAcc() {

    }

    public MainAcc(int _accId, string _accName, Sprite _accSprite, int _accRarity, int _pickLevel) {
        this.accId = _accId;
        this.accName = _accName;
        this.accSprite = _accSprite;
        this.accRarity = _accRarity;
        this.pickLevel = _pickLevel;
    }

    public static MainAcc SetAcc(int accId, Sprite accSprite) {
        MainAcc acc = null;

        switch(accId) {
            case 0:
                acc = new MainAcc(0, "ring1", accSprite, 1, 1);
                break;
            case 1:
                acc = new MainAcc(1, "ring2", accSprite, 1, 1);
                break;
            case 2:
                acc = new MainAcc(2, "ring3", accSprite, 1, 1);
                break;
            case 3:
                acc = new MainAcc(3, "ring4", accSprite, 1, 1);
                break;
        }

        return acc;
    }

    public void SetAccId(int _accId) {
        this.accId = _accId;
    }

    public void SetAccName(string _accName) {
        this.accName = _accName;
    }

    public void SetSprite(Sprite _accSprite) {
        this.accSprite = _accSprite;
    }

    public void SetAccRarity(int _accRarity) {
        this.accRarity = _accRarity;
    }

    public void SetPickLevel(int _pickLevel) {
        this.pickLevel = _pickLevel;
    }

    public int GetAccId() {
        return accId;
    }

    public string GetAccName() {
        return accName;
    }

    public Sprite GetSprite() {
        return accSprite;
    }

    public int GetAccRarity() {
        return accRarity;
    }

    public int GetPickLevel() {
        return pickLevel;
    }
}
