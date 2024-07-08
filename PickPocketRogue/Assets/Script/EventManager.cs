using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public Button playerAtkBtn;
    public GameObject player;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {
        Debug.Log("버튼 누름");
        player.GetComponent<PlayerManager>().Attack(enemy.GetComponent<EnemyManager>().enemy);
    }
}
