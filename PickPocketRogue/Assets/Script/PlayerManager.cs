using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Player player;
    public PlayerInventory playerInventory;
    public PlayerTextManager playerTextManager;
    public Slider hpBar;
    public Light2D light;
    
    public float[] pickRate = new float[5];
    
    void Awake() {
        playerTextManager = GetComponent<PlayerTextManager>();
        playerInventory = new PlayerInventory();
    }

    void Start()
    {
        LoadData();
        UpdateHp();
        UpdatePickRate();
    }
    // EventManager에서 기능을 대체 중
    public void Attack(Enemy enemy) { 
        Debug.Log("플레이어 공격");
        enemy.SetHp(enemy.GetHp() - player.GetDmg());
    }

    public void AddWeaponToInventory(Weapon weapon) {
        Debug.Log("무기 추가");
        UpdatePlayerStatsWithWeapon(weapon);
        
    }

    public void AddArmorToInventory(Armor armor) {
        UpdatePlayerStatsWithArmor(armor);
    }

    public void AddMainAccToInventory(MainAcc mainAcc) {
        UpdatePlayerStatsWithMainAcc(mainAcc);
    }

    public void AddSubAccToInventory(SubAcc subAcc) {
        UpdatePlayerStatsWithSubAcc(subAcc);
    }

    private void UpdatePlayerStatsWithWeapon(Weapon weapon) {
        if(weapon != null) {
            playerInventory.SetWeapon(weapon);
            player.SetDmg(player.GetDefaultDmg() + weapon.GetWeaponDmg());
            Debug.Log("플레이어 장비 스탯 반영!!" + player.GetDmg() + " 플레이어 무기 스탯 : " + weapon.GetWeaponDmg());
        }
        playerTextManager.SetPlayerStatText(this);
        playerTextManager.SetPlayerWeapon(this);
    }

    private void UpdatePlayerStatsWithArmor(Armor armor) {
        if(armor != null) {
            playerInventory.SetArmor(armor);
            player.SetDef(player.GetDefaultDef() + armor.GetArmorDef());
            player.SetMaxHp(player.GetDefaultHp() + armor.GetHp());
            if(player.GetHp() + armor.GetHp() >= player.GetMaxHp()) {
                player.SetHp(player.GetMaxHp());
            } else {
                player.SetHp(player.GetHp() + armor.GetHp());
            }
            Debug.Log("플레이어 장비 스탯 반영!!" + player.GetDef() + " 플레이어 방어구 스탯 : " + armor.GetArmorDef());
        }
        playerTextManager.SetPlayerStatText(this);
        playerTextManager.SetPlayerArmor(this);
    }

    private void UpdatePlayerStatsWithMainAcc(MainAcc mainAcc) {
        if(mainAcc != null) {
            playerInventory.SetMainAcc(mainAcc);
            player.SetPickLevel(player.GetPickLevel() + mainAcc.GetPickLevel());
            Debug.Log("플레이어 장비 스탯 반영!!" + mainAcc.GetAccName());
            UpdatePickRate();
        }
        playerTextManager.SetPlayerStatText(this);
        playerTextManager.SetPlayerMainAcc(this);
    }

    private void UpdatePlayerStatsWithSubAcc(SubAcc subAcc) {
        if(subAcc != null) {
            playerInventory.SetSubAcc(subAcc);
            player.SetPickLevel(player.GetPickLevel() + subAcc.GetPickLevel());
            Debug.Log("플레이어 장비 스탯 반영!!" + subAcc.GetAccName());
            UpdatePickRate();
        }
        playerTextManager.SetPlayerStatText(this);
        playerTextManager.SetPlayerSubAcc(this);    
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

    public void UpdatePickRate() {
        float[] rateArr = new float[5];
        switch(player.GetPickLevel()) {
            case 1:
                rateArr = new float[] {60f, 40f, 10f, 1f, 0.1f};
                break;
            case 2:
                rateArr = new float[] {75f, 50f, 18f, 3f, 0.5f};
                break;
            case 3:
                rateArr = new float[] {90f, 60f, 30f, 7f, 1.5f};
                break;
            case 4:
                rateArr = new float[] {100f, 75f, 45f, 12f, 5f};
                break;
            case 5:
                rateArr = new float[] {100f, 90f, 65f, 25f, 10f};
                break;
            case 6:
                rateArr = new float[] {100f, 100f, 80f, 45f, 20f};
                break;
        }
        pickRate = rateArr;
    }

    public void Die() {

    }

    public void LoadData() {
        DataManager.Instance.LoadData();
        SaveData loadData = DataManager.Instance.saveData;

        player = new Player(loadData.hp, 
                            loadData.dmg, 
                            loadData.def, 
                            loadData.pickLv,
                            loadData.crit);

        player.SetLevel(loadData.level);
        player.SetHp(loadData.curHp);
        player.SetExp(loadData.exp);
        player.SetMaxExp(loadData.maxExp);

        AddWeaponToInventory(ItemLoader.Instance.GetWeapon(loadData.weapon));
        AddArmorToInventory(ItemLoader.Instance.GetArmor(loadData.armor));
        AddMainAccToInventory(ItemLoader.Instance.GetMainAcc(loadData.mainAcc));
        AddSubAccToInventory(ItemLoader.Instance.GetSubAcc(loadData.subAcc));
    }

}
