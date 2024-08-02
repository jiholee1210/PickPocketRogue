using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text stageText;
    public Text roundText;
    public int stage;
    public int round;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    void OnEnable() {
        EnemyManager.OnEnemyDied += StageAndRoundUp;
    }

    void OnDisable() {
        EnemyManager.OnEnemyDied -= StageAndRoundUp;
    }
    // Start is called before the first frame update
    void Start()
    {
        stage = 1;
        round = 1;
        SetStageAndRoundText();
    }

    void StageAndRoundUp(EnemyManager enemyManager) {
        Debug.Log("라운드 증가" + round);
        round++;
        if(round > 10) {
            Debug.Log("스테이지 증가");
            round = 1;
            stage++;
        }
        SetStageAndRoundText();
    }

    void SetStageAndRoundText() {
        stageText.text = "Stage " + stage;
        roundText.text = "Round " + round;
    }
}
