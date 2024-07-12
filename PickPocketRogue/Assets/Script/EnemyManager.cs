using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static event Action<EnemyManager> OnEnemySpawned;
    public static event Action<Weapon> OnEnemyDiedWithDrop;
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        Enemy.EnemyType randomType = (Enemy.EnemyType)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Enemy.EnemyType)).Length);
        enemy = Enemy.SetEnemy(randomType);
        OnEnemySpawned?.Invoke(this);
        Debug.Log("적 생성" + enemy.GetEnemyType() + enemy.GetDropRatio());
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.GetHp() <= 0.0f) {
            if(enemy.GetDropRatio() >= 50.0f) {
                Debug.Log("플레이어 아이템 획득");
                DropWeapon();
            }
            Die();
        }
    }

    public void Attack(Player player) {
        player.SetHp(player.GetHp() - enemy.GetDmg());
    }

    public void Die() {
        Destroy(gameObject);
        EnemySpawner.Instance.SpawnEnemy();
    }

    private void DropWeapon() {
        Weapon.WeaponName randomWeaponName = (Weapon.WeaponName)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Weapon.WeaponName)).Length);
        Weapon droppedWeapon = Weapon.SetWeapon(randomWeaponName);
        OnEnemyDiedWithDrop?.Invoke(droppedWeapon);
    }
}
