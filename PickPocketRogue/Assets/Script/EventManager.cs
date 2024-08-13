using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public GameObject shopButton;
    public GameObject passButton;
    public GameObject player;
    [SerializeField] private GameObject enemy;
    private PopupManager popupManager;
    private EnemyManager enemyManager;
    private PlayerManager playerManager;

    public GameObject[] shopItems;

    void OnEnable(){
        EnemyManager.OnEnemySpawned += UpdateEnemyReference;
        EnemyManager.OnEnemyDiedWithDrop += HandleEnemyDiedWithDrop;
        EnemyManager.OnEnemyDied += HandleEnemyDied;
    }

    void OnDisable() {
        EnemyManager.OnEnemySpawned -= UpdateEnemyReference;
        EnemyManager.OnEnemyDiedWithDrop -= HandleEnemyDiedWithDrop;
        EnemyManager.OnEnemyDied -= HandleEnemyDied;
    }

    void Start() {
        enemy = GameObject.FindWithTag("Enemy");
        playerManager = player.GetComponent<PlayerManager>();
        popupManager = FindObjectOfType<PopupManager>();
    }

    void UpdateEnemyReference(EnemyManager _enemyManager) {
        Debug.Log("적 생성 이벤트 받음");
        enemy = _enemyManager.gameObject;
        enemyManager = _enemyManager;
        if(enemyManager.enemy.GetEnemyType() == Enemy.EnemyType.Merchant) {
            shopButton.SetActive(true);
            passButton.SetActive(true);
            for(int i = 0; i < shopItems.Length; i++) {
                shopItems[i].SetActive(true);
            }
        }
    }

    void HandleEnemyDiedWithDrop((Weapon, Armor) drop) {
        if(drop.Item1 != null) {
            popupManager.ShowPopup(drop.Item1);
        } else {
            popupManager.ShowPopup(drop.Item2);
        }
    }

    void HandleEnemyDied(EnemyManager enemyManager) {
        if(enemyManager.enemy.GetEnemyType() != Enemy.EnemyType.Human && enemyManager.enemy.GetEnemyType() != Enemy.EnemyType.Merchant) {
            Debug.Log("플레이어 경험치 획득");
            playerManager.GetExpAndLevelUp(15f);
        }
    }

    public void OnClickAttackBtn() {
        Debug.Log("공격 버튼 누름");
        float playerDmg = playerManager.player.GetDmg();
        float playerDef = playerManager.player.GetDef();
        float playerHp = playerManager.player.GetHp();

        float enemyDmg = enemyManager.enemy.GetDmg();
        float enemyDef = enemyManager.enemy.GetDef();
        float enemyHp = enemyManager.enemy.GetHp();

        float eDmg = playerDef > enemyDmg ? 0f : enemyDmg - playerDef;
        float pDmg = enemyDef > playerDmg ? 0f : playerDmg - enemyDef;
        if(enemyManager.enemy.GetEnemyType() != Enemy.EnemyType.Merchant) {
            enemyManager.enemy.SetHp(enemyHp - pDmg);
            enemyManager.UpdateHp();
            if(enemyManager.enemy.GetHp() > 0) {
                playerManager.player.SetHp(playerHp - eDmg);
                playerManager.playerTextManager.SetPlayerStatText(playerManager);
                playerManager.UpdateHp();
                if(playerManager.player.GetHp() < 0) {
                    playerManager.Die();
                }
            }
        } else {
            Debug.Log("상인을 공격해선 안돼.");
        }
    }

    public void OnClickStealBtn() {
        Debug.Log("훔치기 버튼 클릭");

        if(enemyManager.enemy.GetEnemyType() == Enemy.EnemyType.Human) {
            popupManager.ShowPopup(enemyManager.enemy.GetWeapon());
            enemyManager.Die();
        } else {
            Debug.Log("몬스터는 장비를 들고 다니지 않아요..");
        }
    }

    public void OnClickShopBtn() {
        Debug.Log("상점 오픈");
        popupManager.ShopPopup(enemyManager.weapons);
    }

    public void OnClickPassBtn() {
        Debug.Log("상인 지나가기");
        shopButton.SetActive(false);
        passButton.SetActive(false);
        enemyManager.Die();
    }
}
