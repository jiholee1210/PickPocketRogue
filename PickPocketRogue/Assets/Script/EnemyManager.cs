using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static event Action<EnemyManager> OnEnemySpawned;
    public static event Action<Weapon> OnEnemyDiedWithDrop;
    public static event Action<EnemyManager> OnEnemyDied;

    public Enemy enemy;
    public EnemyTextManger enemyTextManger;
    public WeaponManager weaponManager;

    public Weapon[] weapons = new Weapon[3];
    // Start is called before the first frame update
    void Awake() {
        weaponManager = GetComponent<WeaponManager>();
        enemyTextManger = GetComponent<EnemyTextManger>();
        
    }
    void Start()
    {
        if(GameManager.Instance.round == 8 && GameManager.Instance.stage % 2 == 0) {
            enemy = Enemy.SetEnemy(Enemy.EnemyType.Merchant);
            for(int i = 0; i < weapons.Length; i++) {
                int weaponId = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Weapon.WeaponName)).Length);
                weapons[i] = weaponManager.CreateWeapon(weaponId);
            }
        } else if(GameManager.Instance.round != 1) {
            Enemy.EnemyType randomType = (Enemy.EnemyType)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Enemy.EnemyType)).Length - 3);
            enemy = Enemy.SetEnemy(randomType);
            int weaponId = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Weapon.WeaponName)).Length);
            enemy.SetWeapon(weaponManager.CreateWeapon(weaponId));
        } else {
            enemy = Enemy.SetEnemy(Enemy.EnemyType.Human);
            int weaponId = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Weapon.WeaponName)).Length);
            Debug.Log(weaponId);
            enemy.SetWeapon(weaponManager.CreateWeapon(weaponId));
            enemy.SetDmg(enemy.GetWeapon().GetWeaponDmg());
            enemy.SetAtkType(enemy.GetWeapon().GetWeaponTypeCode());
        }

        enemyTextManger.SetEnemyStatText(this);
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
        OnEnemyDied?.Invoke(this);     
        SpawnManager.Instance.SpawnObject();
    }

    private void DropWeapon() {
        OnEnemyDiedWithDrop?.Invoke(enemy.GetWeapon());
    }
}
