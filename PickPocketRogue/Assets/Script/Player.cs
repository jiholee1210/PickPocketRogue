using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private float maxHp;
    private float currentHp;

    private float attackDmg;
    private float defense;

    private float pickRatio;

    public Player() {

    }

    public Player(float _maxHp, float _attackDmg, float _defense, float _pickRatio) {
        this.maxHp = _maxHp;
        this.currentHp = _maxHp;
        this.attackDmg = _attackDmg;
        this.defense = _defense;
        this.pickRatio = _pickRatio;
    }

    public void SetHp(float hp) {
        this.currentHp = hp;
    }

    public void SetDmg(float dmg) {
        this.attackDmg = dmg;
    }

    public void SetDef(float def) {
        this.defense = def;
    }

    public void SetPickRatio(float pickRatio) {
        this.pickRatio = pickRatio;
    }

    public float GetHp() {
        return currentHp;
    }

    public float GetDmg() {
        return attackDmg;
    }

    public float GetDef() {
        return defense;
    }

    public float GetPickRatio() {
        return pickRatio;
    }
}
