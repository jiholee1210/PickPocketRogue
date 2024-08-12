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
    public Slider hpBar;
    
    void Awake() {
        player = new Player(50.0f, 12.0f, 4.0f, 1.0f);
        playerTextManager = GetComponent<PlayerTextManager>();
        playerInventory = new PlayerInventory();
        UpdateHp();
    }

    void Start()
    {
        playerTextManager.SetPlayerStatText(this);
        playerTextManager.SetPlayerWeapon(this);
        playerTextManager.SetPlayerArmor(this);
    }
    // EventManager에서 기능을 대체 중
    public void Attack(Enemy enemy) { 
        Debug.Log("플레이어 공격");
        enemy.SetHp(enemy.GetHp() - player.GetDmg());
    }

    public void AddWeaponToInventory(Weapon weapon) {
        playerInventory.SetWeapon(weapon);
        UpdatePlayerStatsWithWeapon(weapon);
    }

    public void AddWeaponToInventory(Armor armor) {
        playerInventory.SetArmor(armor);
        UpdatePlayerStatsWithWeapon(armor);
    }

    private void UpdatePlayerStatsWithWeapon(Weapon weapon) {
        player.SetDmg(player.GetDefaultDmg() + weapon.GetWeaponDmg());
        playerTextManager.SetPlayerStatText(this);
        playerTextManager.SetPlayerWeapon(this);
        Debug.Log("플레이어 장비 스탯 반영!!" + player.GetDmg() + " 플레이어 무기 스탯 : " + weapon.GetWeaponDmg());
    }

    private void UpdatePlayerStatsWithWeapon(Armor armor) {
        player.SetDef(player.GetDefaultDef() + armor.GetArmorDef());
        playerTextManager.SetPlayerStatText(this);
        playerTextManager.SetPlayerArmor(this);
        Debug.Log("플레이어 장비 스탯 반영!!" + player.GetDef() + " 플레이어 방어구 스탯 : " + armor.GetArmorDef());
    }

    private void UpdatePlayerStats() {
        if(playerInventory.GetWeapon() != null) {
            player.SetDmg(player.GetDefaultDmg() + playerInventory.GetWeapon().GetWeaponDmg());
        } else {
            player.SetDmg(player.GetDefaultDmg());
        }

        if(playerInventory.GetArmor() != null) {
            player.SetDef(player.GetDefaultDef() + playerInventory.GetArmor().GetArmorDef());
        } else {
            player.SetDef(player.GetDefaultDef());
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
            player.SetDefaultDef(player.GetDefaultDef() + 2f);
            UpdateHp();
            UpdatePlayerStats();
            Debug.Log("레벨 업!!");
        } else {
            player.SetExp(myExp);
            UpdatePlayerStats();
            Debug.Log("Max 경험치 : " + player.GetMaxExp() + "현재 경험치 : " + player.GetExp());
        }
    }

    public void UpdateHp() {
        hpBar.maxValue = player.GetMaxHp();
        hpBar.value = player.GetHp();
        playerTextManager.SetPlayerHpText(this);
    }

    public void Die() {

    }
}
