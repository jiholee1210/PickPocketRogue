using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public static event Action<EnemyManager> OnEnemySpawned;
    public static event Action<(Weapon, Armor)> OnEnemyDiedWithDrop;
    public static event Action<EnemyManager> OnEnemyDied;

    public Enemy enemy;
    public WeaponManager weaponManager;
    public SpriteRenderer spriteRenderer;
    public EnemyTextManger enemyTextManger;

    public Weapon[] weapons = new Weapon[3];
    public Slider hpBar;
    public GameObject icon;
    // Start is called before the first frame update
    void Awake() {
        weaponManager = GetComponent<WeaponManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyTextManger = GetComponent<EnemyTextManger>();
    }
    void Start()
    {
        /*if(GameManager.Instance.round == 8 && GameManager.Instance.stage % 2 == 0) {
            enemy = Enemy.SetEnemy(Enemy.EnemyType.Merchant);
            hpBar.gameObject.SetActive(false);
            for(int i = 0; i < weapons.Length; i++) {
                int weaponId = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Weapon.WeaponName)).Length);
                weapons[i] = weaponManager.CreateWeapon(weaponId);
            }
        } else {
            Enemy.EnemyType randomType = (Enemy.EnemyType)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Enemy.EnemyType)).Length - 1);
            int weaponId = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Weapon.WeaponName)).Length);
            int armorId = 0;
            enemy = Enemy.SetEnemy(randomType);
            UpdateHp();
            hpBar.gameObject.SetActive(true);
            switch(randomType) {
                case Enemy.EnemyType.Weapon:
                    enemy.SetWeapon(weaponManager.CreateWeapon(weaponId));
                    spriteRenderer.sprite = enemy.GetWeapon().GetSprite();
                    enemy.SetDmg(enemy.GetWeapon().GetWeaponDmg());
                    enemy.SetAtkType(enemy.GetWeapon().GetWeaponTypeCode());
                    break;
                case Enemy.EnemyType.Armor:
                    enemy.SetArmor(weaponManager.CreateArmor(armorId));
                    spriteRenderer.sprite = enemy.GetArmor().GetSprite();
                    enemy.SetDef(enemy.GetArmor().GetArmorDef());
                    enemy.SetDefType(enemy.GetArmor().GetArmorTypeCode());
                    break;
                case Enemy.EnemyType.Human:
                    spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/human");
                    enemy.SetWeapon(weaponManager.CreateWeapon(weaponId));
                    enemy.SetDmg(enemy.GetWeapon().GetWeaponDmg());
                    enemy.SetAtkType(enemy.GetWeapon().GetWeaponTypeCode());
                    enemy.SetArmor(weaponManager.CreateArmor(armorId));
                    enemy.SetDef(enemy.GetArmor().GetArmorDef());
                    enemy.SetDefType(enemy.GetArmor().GetArmorTypeCode());
                    break;
            }
        }*/

        Enemy.EnemyType randomType = (Enemy.EnemyType)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Enemy.EnemyType)).Length - 1);
        int weaponId = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Weapon.WeaponName)).Length);
        int armorId = 0;
        enemy = Enemy.SetEnemy(randomType);
        switch(randomType) {
            case Enemy.EnemyType.Weapon:
                enemy.SetWeapon(weaponManager.CreateWeapon(weaponId));
                spriteRenderer.sprite = enemy.GetWeapon().GetSprite();
                enemy.SetDmg(enemy.GetWeapon().GetWeaponDmg());
                enemy.SetAtkType(enemy.GetWeapon().GetWeaponTypeCode());
                break;
            case Enemy.EnemyType.Armor:
                enemy.SetArmor(weaponManager.CreateArmor(armorId));
                spriteRenderer.sprite = enemy.GetArmor().GetSprite();
                enemy.SetDef(enemy.GetArmor().GetArmorDef());
                enemy.SetDefType(enemy.GetArmor().GetArmorTypeCode());
                break;
            case Enemy.EnemyType.Human:
                spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/enemy1");
                enemy.SetWeapon(weaponManager.CreateWeapon(weaponId));
                enemy.SetDmg(enemy.GetWeapon().GetWeaponDmg());
                enemy.SetAtkType(enemy.GetWeapon().GetWeaponTypeCode());
                enemy.SetArmor(weaponManager.CreateArmor(armorId));
                enemy.SetDef(enemy.GetArmor().GetArmorDef());
                enemy.SetDefType(enemy.GetArmor().GetArmorTypeCode());
                break;
        }
        UpdateHp();
        enemyTextManger.SetEnemyStatText(this);
        icon.SetActive(true);
        hpBar.gameObject.SetActive(true);
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
        //Destroy(gameObject);
        OnEnemyDied?.Invoke(this);     
        //SpawnManager.Instance.SpawnObject();
        if(GameManager.Instance.round == 8 && GameManager.Instance.stage % 2 == 0) {
            enemy = Enemy.SetEnemy(Enemy.EnemyType.Merchant);
            hpBar.gameObject.SetActive(false);
            icon.SetActive(false);
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/merchant");
            for(int i = 0; i < weapons.Length; i++) {
                int weaponId = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Weapon.WeaponName)).Length);
                weapons[i] = weaponManager.CreateWeapon(weaponId);
            }
        } else {
            Enemy.EnemyType randomType = (Enemy.EnemyType)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Enemy.EnemyType)).Length - 1);
            int weaponId = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Weapon.WeaponName)).Length);
            int armorId = 0;
            enemy = Enemy.SetEnemy(randomType);
            switch(randomType) {
                case Enemy.EnemyType.Weapon:
                    enemy.SetWeapon(weaponManager.CreateWeapon(weaponId));
                    spriteRenderer.sprite = enemy.GetWeapon().GetSprite();
                    enemy.SetDmg(enemy.GetWeapon().GetWeaponDmg());
                    enemy.SetAtkType(enemy.GetWeapon().GetWeaponTypeCode());
                    break;
                case Enemy.EnemyType.Armor:
                    enemy.SetArmor(weaponManager.CreateArmor(armorId));
                    spriteRenderer.sprite = enemy.GetArmor().GetSprite();
                    enemy.SetDef(enemy.GetArmor().GetArmorDef());
                    enemy.SetDefType(enemy.GetArmor().GetArmorTypeCode());
                    break;
                case Enemy.EnemyType.Human:
                    spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/enemy1");
                    enemy.SetWeapon(weaponManager.CreateWeapon(weaponId));
                    enemy.SetDmg(enemy.GetWeapon().GetWeaponDmg());
                    enemy.SetAtkType(enemy.GetWeapon().GetWeaponTypeCode());
                    enemy.SetArmor(weaponManager.CreateArmor(armorId));
                    enemy.SetDef(enemy.GetArmor().GetArmorDef());
                    enemy.SetDefType(enemy.GetArmor().GetArmorTypeCode());
                    break;
            }
            UpdateHp();
            enemyTextManger.SetEnemyStatText(this);
            icon.SetActive(true);
            hpBar.gameObject.SetActive(true);
        }
        OnEnemySpawned?.Invoke(this);
        Debug.Log("적 생성" + enemy.GetEnemyType() + enemy.GetDropRatio());
    }

    private void DropWeapon() {
        if(enemy.GetWeapon() == null) {
            OnEnemyDiedWithDrop?.Invoke((null, enemy.GetArmor()));
        } else
        OnEnemyDiedWithDrop?.Invoke((enemy.GetWeapon(), null));
    }

    public void UpdateHp() {
        hpBar.maxValue = enemy.GetMaxHp();
        hpBar.value = enemy.GetHp();
        enemyTextManger.SetEnemyHpText(this);
    }
}
