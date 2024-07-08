using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    [SerializeField] private float maxHp;
    [SerializeField] private float currentHp;

    [SerializeField] private float attackDmg;
    [SerializeField] private int attackType;
    [SerializeField] private float defense;
    [SerializeField] private int defenseType;

    [SerializeField] private float pickRatio;

    public Player() {

    }

    public Player(float _maxHp, float _attackDmg, int _attackType, float _defense, int _defenseType, float _pickRatio) {
        this.maxHp = _maxHp;
        this.currentHp = _maxHp;
        this.attackDmg = _attackDmg;
        this.attackType = _attackType;
        this.defense = _defense;
        this.defenseType = _defenseType;
        this.pickRatio = _pickRatio;
    }

    public void SetHp(float hp) {
        this.currentHp = hp;
    }

    public void SetDmg(float dmg) {
        this.attackDmg = dmg;
    }

    public void SetAtkType(int atkType) {
        this.attackType = atkType;
    }

    public void SetDef(float def) {
        this.defense = def;
    }

    public void SetDefType(int defType) {
        this.defenseType = defType;
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

    public int GetAttackType() {
        return attackType;
    }

    public float GetDef() {
        return defense;
    }

    public int GetDefType() {
        return defenseType;
    }

    public float GetPickRatio() {
        return pickRatio;
    }
}
