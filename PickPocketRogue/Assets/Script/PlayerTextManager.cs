using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTextManager : MonoBehaviour
{
    public Text playerHpText;
    public Text playerWeaponText;
    private PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHpText.text = "Player Hp : " + playerManager.player.GetHp();
        if(playerManager.playerInventory.GetWeapon() != null) { 
            playerWeaponText.text = "Player Weapon : " + playerManager.playerInventory.GetWeapon().GetWeaponName();
        } else {
            playerWeaponText.text = "Player Weapon : 없음";
        }
    }
}
