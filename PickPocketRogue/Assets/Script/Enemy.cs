using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public enum EnemyType {
        Slime,
        Skeleton,
        Orc,
        Dragon
    }

    [SerializeField] private float maxHp;
    [SerializeField] private float currentHp;

    [SerializeField] private float attackDmg;
    [SerializeField] private int attackType;
    [SerializeField] private float defense;
    [SerializeField] private int defenseType;

    [SerializeField] private EnemyType enemyType;

    public Enemy() {

    }

    public Enemy(float _maxHp, float _attackDmg, int _attackType, float _defense, int _defenseType, EnemyType _enemyType) {
        this.maxHp = _maxHp;
        this.currentHp = _maxHp;
        this.attackDmg = _attackDmg;
        this.attackType = _attackType;
        this.defense = _defense;
        this.defenseType = _defenseType;
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
        }

        return enemy;
    }
}
