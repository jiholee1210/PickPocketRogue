using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTextManger : MonoBehaviour
{
    public TMP_Text enemyAtk;
    public TMP_Text enemyDef;
    public Image atkType;
    public Image defType;

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

    public void SetEnemyStatText(EnemyManager enemyManager) {
        enemyAtk.text = enemyManager.enemy.GetDmg().ToString();
        enemyDef.text = enemyManager.enemy.GetDef().ToString();

        atkType.sprite = enemyManager.enemy.GetWeapon() != null ? enemyManager.enemy.GetWeapon().GetTypeSprite() : Resources.Load<Sprite>("Sprites/none");
        defType.sprite = enemyManager.enemy.GetArmor() != null ? enemyManager.enemy.GetArmor().GetTypeSprite() : Resources.Load<Sprite>("Sprites/none");
    }

}
