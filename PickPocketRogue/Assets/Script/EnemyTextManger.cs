using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTextManger : MonoBehaviour
{
    [SerializeField] private Text enemyText;

    // Start is called before the first frame update
    void Awake() {
        enemyText = GameObject.Find("Base Screen/Enemy Hp").GetComponent<Text>();
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
