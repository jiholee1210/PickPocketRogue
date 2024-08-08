using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public enum EnemyType {
        Slime,
        Skeleton,
        Orc,
        Dragon,
        Human,
        Merchant
    }

    private float maxHp;
    private float currentHp;

    private float attackDmg;
    private int attackType;
    private float defense;
    private int defenseType;
    private float dropRatio;
    private Weapon weapon;
    private EnemyType enemyType;

    public Enemy() {

    }

    public Enemy(float _maxHp, float _attackDmg, int _attackType, float _defense, int _defenseType, EnemyType _enemyType) {
        this.maxHp = _maxHp;
        this.currentHp = _maxHp;
        this.attackDmg = _attackDmg;
        this.attackType = _attackType;
        this.defense = _defense;
        this.defenseType = _defenseType;
        this.dropRatio = Random.Range(0.0f, 100.0f);
        this.enemyType = _enemyType;
    }

    public static Enemy SetEnemy(EnemyType enemyType) {
        Enemy enemy = null;

        switch (enemyType) {
            case EnemyType.Slime:
                enemy = new Enemy(10.0f, 2.0f, 1, 0.0f, 1, EnemyType.Slime);
                break;
            case EnemyType.Skeleton:
                enemy = new Enemy(20.0f, 4.0f, 2, 1.0f, 1, EnemyType.Skeleton);
                break;
            case EnemyType.Orc:
                enemy = new Enemy(50.0f, 10.0f, 1, 5.0f, 3, EnemyType.Orc);
                break;
            case EnemyType.Dragon:
                enemy = new Enemy(100.0f, 20.0f, 3, 10.0f, 2, EnemyType.Dragon);
                break;
            case EnemyType.Human:
                enemy = new Enemy(50.0f, 0f, 0, 2f, 0, EnemyType.Human);
                enemy.SetDropRatio(0f);
                break;
            case EnemyType.Merchant:
                enemy = new Enemy(1f, 0f, 0, 0f, 0, EnemyType.Merchant);
                break;
        }

        return enemy;
    }

    public void SetHp(float hp) {
        this.currentHp = hp;
    }

    public void SetMaxHp(float maxHp) {
        this.maxHp = maxHp;
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

    public void SetWeapon(Weapon weapon) {
        this.weapon = weapon;
    }

    public void SetDropRatio(float dropRatio) {
        this.dropRatio = dropRatio;
    }

    public float GetHp() {
        return currentHp;
    }

    public float GetMaxHp() {
        return maxHp;
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

    public EnemyType GetEnemyType() {
        return enemyType;
    }

    public float GetDropRatio() {
        return dropRatio;
    }

    public Weapon GetWeapon() {
        return weapon;
    }
}
