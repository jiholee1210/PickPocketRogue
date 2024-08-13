using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTextManger : MonoBehaviour
{
    public TMP_Text enemyHp;
    public TMP_Text enemyAtk;
    public TMP_Text enemyDef;
    // Start is called before the first frame update
    void Awake() {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void SetEnemyHpText(EnemyManager enemyManager) {
        enemyHp.text = enemyManager.enemy.GetHp() + " / " + enemyManager.enemy.GetMaxHp();
    }

    public void SetEnemyStatText(EnemyManager enemyManager) {
        enemyAtk.text = enemyManager.enemy.GetDmg().ToString();
        enemyDef.text = enemyManager.enemy.GetDef().ToString();
    }
}
