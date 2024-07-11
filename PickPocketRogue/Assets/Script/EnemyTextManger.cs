using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTextManger : MonoBehaviour
{
    private Text text;
    private EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Canvas/Enemy Hp").GetComponent<Text>();
        enemyManager = GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Enemy Hp = " + enemyManager.enemy.GetHp();   
    }
}
