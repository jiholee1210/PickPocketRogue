using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTextManger : MonoBehaviour
{
    [SerializeField] private TMP_Text enemyText;

    // Start is called before the first frame update
    void Awake() {
        enemyText = GameObject.Find("Base Screen/Enemy Hp").GetComponent<TMP_Text>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void SetEnemyStatText(EnemyManager enemyManager) {
        enemyText.text = "Hp : " + enemyManager.enemy.GetHp() + " / " + enemyManager.enemy.GetMaxHp() +
                            "\nDmg : " + enemyManager.enemy.GetDmg() +
                            "\nDef : " + enemyManager.enemy.GetDef();
        
    }
}
