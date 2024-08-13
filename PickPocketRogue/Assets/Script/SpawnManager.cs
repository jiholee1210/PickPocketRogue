using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    public GameObject enemyPrefab;
    private GameManager gameManager;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    void Start() {
        gameManager = GetComponent<GameManager>();
        //SpawnObject();
    }
    
    public void SpawnObject() {
        Instantiate(enemyPrefab, new Vector3(6, 0, 0), Quaternion.identity);
    }
}
