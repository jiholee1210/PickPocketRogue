using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public Button playerAtkBtn;
    public GameObject player;
    [SerializeField] private GameObject enemy;
    private PopupManager popupManager;
    private EnemyManager enemyManager;
    private PlayerManager playerManager;

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
    }

    void HandleEnemyDiedWithDrop(Weapon weapon) {
        popupManager.ShowPopup(weapon);
    }

    void HandleEnemyDied(EnemyManager enemyManager) {
        if(enemyManager.enemy.GetEnemyType() != Enemy.EnemyType.Human) {
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

        enemyManager.enemy.SetHp(enemyHp - pDmg);
        enemyManager.enemyTextManger.SetEnemyStatText(enemyManager);
        if(enemyManager.enemy.GetHp() > 0) {
            playerManager.player.SetHp(playerHp - eDmg);
            playerManager.playerTextManager.SetPlayerStatText(playerManager);
            if(playerManager.player.GetHp() < 0) {
                playerManager.Die();
            }
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
}
