using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Player player;
    public PlayerInventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        player = new Player(10.0f, 5.0f, 5.0f, 1.0f);
        playerInventory = new PlayerInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(Enemy enemy) {
        Debug.Log("플레이어 공격");
        enemy.SetHp(enemy.GetHp() - player.GetDmg());
    }

    public void AddWeaponToInventory(Weapon weapon) {
        playerInventory.SetWeapon(weapon);
        UpdatePlayerStats();
    }

    private void UpdatePlayerStats() {
        player.SetDmg(player.GetDmg() + playerInventory.GetWeapon().GetWeaponDmg());
        Debug.Log("플레이어 장비 스탯 반영!!" + player.GetDmg() + " 플레이어 무기 스탯 : " + playerInventory.GetWeapon().GetWeaponDmg());
    }
}
