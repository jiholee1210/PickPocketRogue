using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLoader : MonoBehaviour
{
    public static ItemLoader Instance;

    private Dictionary<int, Weapon> weapons;
    private Dictionary<int, Armor> armors;
    private Dictionary<int, MainAcc> mainAccs;
    private Dictionary<int, SubAcc> subAccs;

    private Sprite[] weaponSprite;
    private Sprite[] armorSprite;
    private Sprite[] mainAccSprite;
    private Sprite[] subAccSprite;

    private void Awake() {
        if(Instance == null) {
            Instance = this;            
        } else {
            Destroy(Instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        weaponSprite = Resources.LoadAll<Sprite>("Weapon/bronze-weapons");
        armorSprite = Resources.LoadAll<Sprite>("Weapon/gold-weapons");
        mainAccSprite = Resources.LoadAll<Sprite>("Weapon/iron-weapons");
        subAccSprite = Resources.LoadAll<Sprite>("Weapon/steel-weapons");
        
        LoadItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadItems() {
        weapons = new Dictionary<int, Weapon>();
        armors = new Dictionary<int, Armor>();
        mainAccs = new Dictionary<int, MainAcc>();
        subAccs = new Dictionary<int, SubAcc>();

        weapons.Add(0, Weapon.SetWeapon(0, weaponSprite[0]));
        weapons.Add(1, Weapon.SetWeapon(1, weaponSprite[1]));
        weapons.Add(2, Weapon.SetWeapon(2, weaponSprite[2]));
        weapons.Add(3, Weapon.SetWeapon(3, weaponSprite[3]));
        weapons.Add(4, Weapon.SetWeapon(4, weaponSprite[4]));

        armors.Add(0, Armor.SetArmor(0, armorSprite[0]));

        mainAccs.Add(0, MainAcc.SetAcc(0, mainAccSprite[0]));
        mainAccs.Add(1, MainAcc.SetAcc(1, mainAccSprite[1]));
        mainAccs.Add(2, MainAcc.SetAcc(2, mainAccSprite[2]));
        mainAccs.Add(3, MainAcc.SetAcc(3, mainAccSprite[3]));

        subAccs.Add(0, SubAcc.SetAcc(0, subAccSprite[0]));
        subAccs.Add(1, SubAcc.SetAcc(1, subAccSprite[1]));
        subAccs.Add(2, SubAcc.SetAcc(2, subAccSprite[2]));
        subAccs.Add(3, SubAcc.SetAcc(3, subAccSprite[3]));
    }

    public Weapon GetWeapon(int id) {
        if(weapons.TryGetValue(id, out Weapon weapon)) {
            return weapon;
        }
        return null;
    }

    public Armor GetArmor(int id) {
        if (armors.TryGetValue(id, out Armor armor)) {
            return armor;
        }
        return null;
    }

    public MainAcc GetMainAcc(int id) {
        if(mainAccs.TryGetValue(id, out MainAcc mainAcc)) {
            return mainAcc;
        }
        return null;
    }

    public SubAcc GetSubAcc(int id) {
        if(subAccs.TryGetValue(id, out SubAcc subAcc)) {
            return subAcc;
        }
        return null;
    }
}
