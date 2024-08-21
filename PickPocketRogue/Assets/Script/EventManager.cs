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
    private PlayerMovement playerMovement;
    private EnemyMovement enemyMovement;

    public GameObject[] shopItems;

    private bool isAttacking = false;
    private bool isStealing = false;
    private bool canSteal = true;

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
        playerMovement = player.GetComponent<PlayerMovement>();
        enemyMovement = enemy.GetComponent<EnemyMovement>();
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
        Time.timeScale = 0f;
    }

    void HandleEnemyDied(EnemyManager enemyManager) {
        if(enemyManager.enemy.GetEnemyType() != Enemy.EnemyType.Weapon && enemyManager.enemy.GetEnemyType() != Enemy.EnemyType.Merchant) {
            Debug.Log("플레이어 경험치 획득");
            playerManager.GetExpAndLevelUp(15f);
        }
    }

    public void OnClickAttackBtn() {
        Debug.Log("공격 버튼 누름");
        if(!isAttacking) {
            StartCoroutine(HandleAttack());
        }
    }

    private IEnumerator HandleAttack() {
        isAttacking = true;
        canSteal = false;
        playerManager.light.intensity = 1;
        yield return StartCoroutine(playerMovement.GoToEnemy());
        float playerCrit = Random.Range(0, 100) < playerManager.player.GetCritRatio() ? 2f: 1f;
        float playerDmg = playerManager.player.GetDmg() * playerCrit;
        float playerDef = playerManager.player.GetDef();
        float playerHp = playerManager.player.GetHp();

        float enemyDmg = enemyManager.enemy.GetDmg();
        float enemyDef = enemyManager.enemy.GetDef();
        float enemyHp = enemyManager.enemy.GetHp();

        float eDmg = playerDef > enemyDmg ? 0f : enemyDmg - playerDef;
        float pDmg = enemyDef > playerDmg ? 0f : playerDmg - enemyDef;
        if(enemyManager.enemy.GetEnemyType() != Enemy.EnemyType.Merchant) {
            Debug.Log("플레이어 공격 : " + playerDmg);
            enemyManager.enemy.SetHp(enemyHp - pDmg);
            enemyManager.UpdateHp();
            yield return StartCoroutine(playerMovement.BackToPos());
            if(enemyManager.enemy.GetHp() > 0) {
                yield return new WaitForSeconds(0.3f);
                yield return StartCoroutine(enemyMovement.GoToPlayer());
                playerManager.player.SetHp(playerHp - eDmg);
                playerManager.playerTextManager.SetPlayerStatText(playerManager);
                playerManager.UpdateHp();
                yield return StartCoroutine(enemyMovement.BackToPos());
                if(playerManager.player.GetHp() < 0) {
                    playerManager.Die();
                }
            } else {
                if(enemyManager.enemy.GetDropRatio() > 80f) {
                    enemyManager.DropWeapon();
                }
                yield return StartCoroutine(PlayerPass());
            }
        } else {
            Debug.Log("상인을 공격해선 안돼.");
        }
        isAttacking = false;
    }

    public void OnClickStealBtn() {
        Debug.Log("훔치기 버튼 클릭");
        if(!isStealing && canSteal) {
            StartCoroutine(PlayerSteal());
        } else {
            Debug.Log("들켜버렸다..");
        }
    }

    private IEnumerator PlayerSteal() {
        isStealing = true;
        yield return StartCoroutine(playerMovement.TrySteal());
        float canPick = 0f;
        bool stealWeapon = false;
        switch(enemyManager.enemy.GetEnemyType()) {
            case(Enemy.EnemyType.Human):
                stealWeapon = Random.Range(0, 2) == 0 ? true : false;
                if(stealWeapon) {
                    canPick = playerManager.pickRate[enemyManager.enemy.GetWeapon().GetWeaponRarity()];
                } else {
                    canPick = playerManager.pickRate[enemyManager.enemy.GetArmor().GetArmorRarity()];
                }
                break;
            case(Enemy.EnemyType.Weapon):
                stealWeapon = true;
                canPick = playerManager.pickRate[enemyManager.enemy.GetWeapon().GetWeaponRarity()];
                break;
            case(Enemy.EnemyType.Armor):
                canPick = playerManager.pickRate[enemyManager.enemy.GetArmor().GetArmorRarity()];
                break;
        }
        float random = Random.Range(0f, 100f);
        Debug.Log(random);
        if(random < canPick) {
            Time.timeScale = 0f;
            if(stealWeapon) {
                popupManager.ShowPopup(enemyManager.enemy.GetWeapon());
            } else {
                popupManager.ShowPopup(enemyManager.enemy.GetArmor());
            }
             // 아머와 무기 구분해야함.
            yield return StartCoroutine(PlayerPass());
        } else {
            playerManager.light.intensity = 1;
            yield return StartCoroutine(enemyMovement.FailSteal());
            yield return StartCoroutine(playerMovement.BackToPos());
            Debug.Log("훔치기 실패...");
            canSteal = false;
        }
        isStealing = false;
    }

    private IEnumerator PlayerPass() {
        playerManager.light.intensity = 0.2f;
        yield return StartCoroutine(playerMovement.ClearStageOrSteal());
        canSteal = true;
        enemyManager.Die();
    }

    public void OnClickShopBtn() {
        Debug.Log("상점 오픈");
        popupManager.ShopPopup(enemyManager.weapons);
        Time.timeScale = 0f;
    }

    public void OnClickPassBtn() {
        Debug.Log("상인 지나가기");
        shopButton.SetActive(false);
        passButton.SetActive(false);
        StartCoroutine(PlayerPass());
    }


}
