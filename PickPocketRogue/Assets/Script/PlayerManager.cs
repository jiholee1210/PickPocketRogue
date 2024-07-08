using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = new Player(10.0f, 5.0f, 1, 5.0f, 1, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(Enemy enemy) {
        Debug.Log("플레이어 공격");
        enemy.SetHp(enemy.GetHp() - player.GetDmg());
    }

    
}
