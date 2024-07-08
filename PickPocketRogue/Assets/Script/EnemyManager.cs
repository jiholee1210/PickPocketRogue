using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemy;
    public Enemy.EnemyType enemyType;
    // Start is called before the first frame update
    void Start()
    {
        enemy = Enemy.SetEnemy(enemyType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(Player player) {
        player.SetHp(player.GetHp() - enemy.GetDmg());
    }
}
