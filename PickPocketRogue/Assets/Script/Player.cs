using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private float maxExp;
    private float currentExp;
    private int level;
    private float defaultHp;
    private float maxHp;
    private float currentHp;

    private float defaultDmg;
    private float attackDmg;
    private float critRatio;
    private float defaultDef;
    private float defense;

    private int pickLevel;

    public Player() {

    }

    public Player(float _defaultHp, float _defaultDmg, float _defaultDef, int _pickLevel, float _critRatio) {
        this.level = 1;
        this.maxExp = 50f;
        this.currentExp = 0f;
        this.defaultHp = _defaultHp;
        this.maxHp = _defaultHp;
        this.currentHp = _defaultHp;
        this.defaultDmg = _defaultDmg;
        this.attackDmg = _defaultDmg;
        this.defaultDef = _defaultDef;
        this.defense = _defaultDef;
        this.pickLevel = _pickLevel;
        this.critRatio = _critRatio;
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
    
    public void SetDefaultHp(float defaultHp) {
        this.defaultHp = defaultHp;
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

    public void SetDefaultDef(float defaultDef) {
        this.defaultDef = defaultDef;
    }

    public void SetDef(float def) {
        this.defense = def;
    }

    public void SetPickRatio(int pickLevel) {
        this.pickLevel = pickLevel;
    }

    public void SetCritRatio(float critRatio) {
        this.critRatio = critRatio;
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
    public float GetDefaultHp() {
        return defaultHp;
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

    public float GetDefaultDef() {
        return defaultDef;
    }

    public float GetDef() {
        return defense;
    }

    public int GetPickLevel() {
        return pickLevel;
    }

    public float GetCritRatio() {
        return critRatio;
    }
}
