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
}
