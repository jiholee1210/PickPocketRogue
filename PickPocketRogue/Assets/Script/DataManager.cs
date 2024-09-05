using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData {
    public int stage = 1;
    public int round = 1;

    public int weapon = -1;
    public int armor = -1;
    public int mainAcc = -1;
    public int subAcc = -1;

    public int level;
    public float exp;
    public float maxExp;
    public float curHp;
    public float hp; 
    public float dmg;
    public float def;
    public float crit;
    public int pickLv;
}

public class PlayerData {
    public float hp = 50f;
    public float dmg = 5f;
    public float def = 1f;
    public float crit = 5f;
    public int pickLv = 0;
    public int statPt = 0;

    public bool[] haveWeapon = {false};
    public bool[] haveArmor = {false};
    public bool[] haveMainAcc = {false};
    public bool[] haveSubAcc = {false};
}

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;

    string path;
    string filename = "save";
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else if (Instance != this) {
            Destroy(Instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        path = Application.persistentDataPath + "/";
    }

    public SaveData saveData = new SaveData();
    public PlayerData playerData = new PlayerData();
    // Start is called before the first frame update
    void Start()
    {
        if(!File.Exists(path + "playerData")) {
            NewPlayerData();
        } else {
            LoadPlayerData();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewPlayerData() {
        string data = JsonUtility.ToJson(playerData);
        File.WriteAllText(path + "playerData", data);
        Debug.Log("새 플레이어 세이브 생성 / " + data);
    }

    public void LoadPlayerData() {
        string data = File.ReadAllText(path + "playerData");
        playerData = JsonUtility.FromJson<PlayerData>(data);
        Debug.Log("플레이어 세이브 로드 / " + data);
    }

    public void SaveData() {
        string data = JsonUtility.ToJson(saveData);
        File.WriteAllText(path + filename, data);
        Debug.Log("새 게임 세이브 생성 / " + data);
    }

    public void LoadData() {
        string data = File.ReadAllText(path + filename);
        saveData = JsonUtility.FromJson<SaveData>(data);
        Debug.Log("게임 세이브 로드 / " + data);
    }
}
