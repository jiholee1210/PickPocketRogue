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

    void OnEnable(){
        EnemyManager.OnEnemySpawned += UpdateEnemyReference;
    }

    void OnDisable() {
        EnemyManager.OnEnemySpawned -= UpdateEnemyReference;
    }

    void Start() {
        enemy = GameObject.FindWithTag("Enemy");
    }

    void UpdateEnemyReference(EnemyManager enemyManager) {
        Debug.Log("적 생성 이벤트 받음");
        enemy = enemyManager.gameObject;
    }

    public void OnClick() {
        Debug.Log("버튼 누름");
        player.GetComponent<PlayerManager>().Attack(enemy.GetComponent<EnemyManager>().enemy);
    }
}
