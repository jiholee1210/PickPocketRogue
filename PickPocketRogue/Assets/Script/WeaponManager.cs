using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Sprite[] weaponSprites;
    // Start is called before the first frame update
    void Awake()
    {
        weaponSprites = Resources.LoadAll<Sprite>("Weapon/bronze-weapons");
        if(weaponSprites.Length == 0) {
            Debug.LogError("스프라이트를 못찾음");
        } else {
            Debug.Log("성공적으로 스프라이트 로드" + weaponSprites.Length);
        }
    }

    // Update is called once per frame
    public Weapon CreateWeapon(int weaponId) {

        if (weaponId < 0 || weaponId >= weaponSprites.Length)
        {
            Debug.LogWarning("Invalid weaponId: " + weaponId);
            return null;
        }
        Sprite weaponSprite = weaponSprites[weaponId];
        if (weaponSprite != null) {
            return Weapon.SetWeapon(weaponId, weaponSprite);
        } else {
            Debug.LogWarning("스프라이트가 존재하지 않음 : " + weaponId);
            return null;
        }
    }
}
