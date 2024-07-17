using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private float maxExp;
    private float currentExp;
    private int level;
    private float maxHp;
    private float currentHp;

    private float defaultDmg;
    private float attackDmg;
    private float defense;

    private float pickRatio;

    public Player() {

    }

    public Player(float _maxHp, float _defaultDmg, float _defense, float _pickRatio) {
        this.level = 1;
        this.maxExp = 50f;
        this.currentExp = 0f;
        this.maxHp = _maxHp;
        this.currentHp = _maxHp;
        this.defaultDmg = _defaultDmg;
        this.attackDmg = _defaultDmg;
        this.defense = _defense;
        this.pickRatio = _pickRatio;
    }

    public void SetLevel(int level) {
        this.level = level;
    }
    public void SetMaxExp(float maxExp) {
        this.maxExp = maxExp;
    }
    public void SetExp(float currentExp) {
        this.currentExp = currentExp;
    }
    public void SetMaxHp(float maxHp) {
        this.maxHp = maxHp;
    }
    
    public void SetHp(float hp) {
        this.currentHp = hp;
    }

    public void SetDefaultDmg(float defaultDmg) {
        this.defaultDmg = defaultDmg;
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

    public int GetLevel() {
        return level;
    }

    public float GetMaxExp() {
        return maxExp;
    }

    public float GetExp() {
        return currentExp;
    }
    public float GetMaxHp() {
        return maxHp;
    }

    public float GetHp() {
        return currentHp;
    }

    public float GetDefaultDmg() {
        return defaultDmg;
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
