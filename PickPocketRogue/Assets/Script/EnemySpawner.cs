using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// SpawnManager에서 Human 클래스와 Enemy 클래스 스폰을 통합시킴. 따라서 사용은 하지 않고 참고용
public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    public GameObject enemyPrefab;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void SpawnEnemy() {
        Instantiate(enemyPrefab, new Vector3(5, -2, 0), Quaternion.identity);
    }
}
