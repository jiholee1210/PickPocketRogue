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

    void OnEnable(){
        EnemyManager.OnEnemySpawned += UpdateEnemyReference;
        EnemyManager.OnEnemyDiedWithDrop += HandleEnemyDiedWithDrop;
    }

    void OnDisable() {
        EnemyManager.OnEnemySpawned -= UpdateEnemyReference;
        EnemyManager.OnEnemyDiedWithDrop -= HandleEnemyDiedWithDrop;
    }

    void Start() {
        enemy = GameObject.FindWithTag("Enemy");
        popupManager = FindObjectOfType<PopupManager>();
    }

    void UpdateEnemyReference(EnemyManager enemyManager) {
        Debug.Log("적 생성 이벤트 받음");
        enemy = enemyManager.gameObject;
    }

    void HandleEnemyDiedWithDrop(Weapon weapon) {
        popupManager.ShowPopup(weapon);
    }

    public void OnClick() {
        Debug.Log("버튼 누름");
        player.GetComponent<PlayerManager>().Attack(enemy.GetComponent<EnemyManager>().enemy);
    }
}
