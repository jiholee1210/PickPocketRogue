using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Player player;
    public PlayerInventory playerInventory;
    public PlayerTextManager playerTextManager;
    
    void Awake() {
        player = new Player(10.0f, 25.0f, 20.0f, 1.0f);
        playerInventory = new PlayerInventory();
    }

    void Start()
    {
        playerTextManager = GetComponent<PlayerTextManager>();
        playerTextManager.SetPlayerStatText(this);
        playerTextManager.SetPlayerWeaponText(this);
    }


    // EventManager에서 기능을 대체 중
    public void Attack(Enemy enemy) { 
        Debug.Log("플레이어 공격");
        enemy.SetHp(enemy.GetHp() - player.GetDmg());
    }

    public void AddWeaponToInventory(Weapon weapon) {
        playerInventory.SetWeapon(weapon);
        playerTextManager.SetPlayerWeaponText(this);
        UpdatePlayerStatsWithWeapon();
    }

    private void UpdatePlayerStatsWithWeapon() {
        player.SetDmg(player.GetDefaultDmg() + playerInventory.GetWeapon().GetWeaponDmg());
        playerTextManager.SetPlayerStatText(this);
        Debug.Log("플레이어 장비 스탯 반영!!" + player.GetDmg() + " 플레이어 무기 스탯 : " + playerInventory.GetWeapon().GetWeaponDmg());
    }

    private void UpdatePlayerStats() {
        if(playerInventory.GetWeapon() != null) {
            player.SetDmg(player.GetDefaultDmg() + playerInventory.GetWeapon().GetWeaponDmg());
        } else {
            player.SetDmg(player.GetDefaultDmg());
        }
        playerTextManager.SetPlayerStatText(this);
    }

    public void GetExpAndLevelUp(float exp) {
        float myExp = player.GetExp() + exp;

        if(myExp >= player.GetMaxExp()) {
            player.SetExp(myExp - player.GetMaxExp());
            player.SetMaxExp(player.GetMaxExp() * 2f);
            player.SetLevel(player.GetLevel() + 1);
            player.SetMaxHp(player.GetMaxHp() + 10f);
            player.SetHp(player.GetHp() + 10f);
            player.SetDefaultDmg(player.GetDefaultDmg() + 5f);
            player.SetDef(player.GetDef() + 2f);
            UpdatePlayerStats();
            Debug.Log("레벨 업!!");
        } else {
            player.SetExp(myExp);
            UpdatePlayerStats();
            Debug.Log("Max 경험치 : " + player.GetMaxExp() + "현재 경험치 : " + player.GetExp());
        }
    }

    public void Die() {

    }
}
