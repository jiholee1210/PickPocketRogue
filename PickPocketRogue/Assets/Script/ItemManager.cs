using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject item;
    public Transform contentArea;
    
    private Sprite[] weaponSprite;
    private Sprite[] armorSprite;
    private Sprite[] mainAccSprite;
    private Sprite[] subAccSprite;

    public Button[] buttons;
    public int prevIdx = 0;

    public GameObject weaponItem;
    public GameObject armorItem;
    public GameObject mainAccItem;
    public GameObject subAccItem;

    private Weapon weapon;
    private Armor armor;
    private MainAcc mainAcc;
    private SubAcc subAcc;

    public TMP_Text stat;

    private SelectManager selectManager;
    // Start is called before the first frame update
    void Start()
    {
        selectManager = GetComponent<SelectManager>();

        for(int i = 0; i < buttons.Length; i++) {
            int index = i;
            buttons[i].onClick.AddListener(() => OnClickBtn(index));
        }
        buttons[prevIdx].image.sprite = Resources.Load<Sprite>("Sprites/UI/filter select ui");

        weaponSprite = Resources.LoadAll<Sprite>("Weapon/bronze-weapons");
        armorSprite = Resources.LoadAll<Sprite>("Weapon/gold-weapons");
        mainAccSprite = Resources.LoadAll<Sprite>("Weapon/iron-weapons");
        subAccSprite = Resources.LoadAll<Sprite>("Weapon/steel-weapons");

        DisplayItem(weaponSprite);
        UpdateStat();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) {
            SelectItem();
        }
    }

    public void CreateItem() {
    }

    public void OnClickBtn(int index) {
        
        selectManager.resetPos();
        
        if(prevIdx != index) {
            ClearContents();
            buttons[index].image.sprite = Resources.Load<Sprite>("Sprites/UI/filter select ui");
            buttons[prevIdx].image.sprite = Resources.Load<Sprite>("Sprites/UI/filter ui");

            switch(index) {
                case 0:
                    DisplayItem(weaponSprite);
                    break;
                case 1:
                    DisplayItem(armorSprite);
                    break;
                case 2:
                    DisplayItem(mainAccSprite);
                    break;
                case 3:
                    DisplayItem(subAccSprite);
                    break;
            }
            prevIdx = index;
        }

    }

    public void DisplayItem(Sprite[] sprites) {
        Vector3 curPos = new Vector3(-240, 400, 0);

        for(int i = 0; i < 40; i++) {
            GameObject itemUI = Instantiate(item, contentArea);
            itemUI.GetComponent<Image>().sprite = sprites[i];
            if(i % 4 == 3) {
                itemUI.transform.localPosition = curPos;
                curPos.x = -240;
                curPos.y -= 160;
            } else {
                itemUI.transform.localPosition = curPos;
                curPos.x += 160;
            }
        }
    }

    public void ClearContents() {
        foreach(Transform child in contentArea) {
            Destroy(child.gameObject);
        }
    }

    public void SelectItem() {
        int index = selectManager.idx;
        switch(prevIdx) {
            case 0:
                weapon = ItemLoader.Instance.GetWeapon(index);
                weaponItem.GetComponent<Image>().sprite = weapon.GetSprite();
                break;
            case 1:
                armor = ItemLoader.Instance.GetArmor(index);
                armorItem.GetComponent<Image>().sprite = armor.GetSprite();
                break;
            case 2:
                mainAcc = ItemLoader.Instance.GetMainAcc(index);
                mainAccItem.GetComponent<Image>().sprite = mainAcc.GetSprite();
                break;
            case 3:
                subAcc = ItemLoader.Instance.GetSubAcc(index);
                subAccItem.GetComponent<Image>().sprite = subAcc.GetSprite();
                break;
        }
        UpdateStat();
    }

    private void UpdateStat() {
        float hp = armor != null ? armor.GetHp() : 0;
        float dmg = weapon != null ? weapon.GetWeaponDmg() : 0;
        float def = armor != null ? armor.GetArmorDef() : 0;
        float mPick = mainAcc != null ? mainAcc.GetPickLevel() : 0;
        float sPick = subAcc != null ? subAcc.GetPickLevel() : 0;



        stat.text = "HP : " + hp +
                    "\n데미지 : " + dmg +
                    "\n방어력 : " + def +
                    "\n훔치기 : " + (DataManager.Instance.playerData.pickLv + mPick + sPick) + " 단계";
    }

    public void SaveAndStart() {
        DataManager.Instance.saveData.weapon = weapon != null ? weapon.GetID() : -1;
        DataManager.Instance.saveData.armor = armor != null ? armor.GetId() : -1;
        DataManager.Instance.saveData.mainAcc = mainAcc != null ? mainAcc.GetAccId() : -1;
        DataManager.Instance.saveData.subAcc = subAcc != null ? subAcc.GetAccId() : -1;

        DataManager.Instance.saveData.level = 1;
        DataManager.Instance.saveData.exp = 0f;
        DataManager.Instance.saveData.maxExp = 50f;
        DataManager.Instance.saveData.curHp = DataManager.Instance.playerData.hp;
        DataManager.Instance.saveData.hp = DataManager.Instance.playerData.hp;
        DataManager.Instance.saveData.dmg = DataManager.Instance.playerData.dmg;
        DataManager.Instance.saveData.def = DataManager.Instance.playerData.def;
        DataManager.Instance.saveData.crit = DataManager.Instance.playerData.crit;
        DataManager.Instance.saveData.pickLv = DataManager.Instance.playerData.pickLv;

        DataManager.Instance.SaveData();
        Debug.Log(DataManager.Instance.saveData + " / 새 게임 시작");
        SceneManager.LoadScene("SampleScene");
    }

    public void Back() {
        SceneManager.LoadScene("MainScene");
    }
}
