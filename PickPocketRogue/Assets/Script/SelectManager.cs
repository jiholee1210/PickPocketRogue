using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    private Sprite spriteArr;
    private int idx = 0;
    private Vector3 curPos;
    public GameObject selectUI;
    // Start is called before the first frame update
    void Start()
    {
        curPos = new Vector3(-600, 380, 0);
        selectUI.transform.position = curPos;
        Debug.Log(idx);
    }

    // Update is called once per frame
    void Update()
    {
        calPos();
    }

    private void calPos() {
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            idx++;
            if(idx % 4 == 0) {
                curPos.x = -600;
                curPos.y -= 160;
            } else {
                curPos.x += 160;
            }
            Debug.Log(idx);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && idx > 0){
            idx--;
            if(idx % 4 == 3) {
                curPos.x = -120;
                curPos.y += 160;
            } else {
                curPos.x -= 160;
            }
            Debug.Log(idx);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            idx += 4;
            curPos.y -= 160;
            Debug.Log(idx);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && idx / 4 > 0) {
            idx -= 4;
            curPos.y += 160;
            Debug.Log(idx);
        }
        selectUI.transform.position = curPos;
    }
}
