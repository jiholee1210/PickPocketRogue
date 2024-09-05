using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    public int idx = 0;
    private Vector3 curPos;
    public GameObject selectUI;

    private int min = 0;
    private int max = 23;

    private ItemManager itemManager;

    // Start is called before the first frame update
    void Start()
    {
        itemManager = GetComponent<ItemManager>();
        curPos = new Vector3(-600, 400, 0);
        selectUI.transform.localPosition = curPos;
        Debug.Log(idx);
    }

    // Update is called once per frame
    void Update()
    {
        calPos();
    }

    private void calPos() {
        if(Input.GetKeyDown(KeyCode.RightArrow) && idx < 39){
            if(idx == max) {
                UpItem();
                curPos.x = -600;
            } else {
                if(idx % 4 == 3) {
                    curPos.x = -600;
                    curPos.y -= 160;
                } else {
                    curPos.x += 160;
                }
            }
            idx++;
            Debug.Log(idx);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && idx > 0){
            if(idx == min) {
                DownItem();
                curPos.x = -120;
            } else {
                if(idx % 4 == 0) {
                    curPos.x = -120;
                    curPos.y += 160;
                } else {
                    curPos.x -= 160;
                }
            }
            idx--;
            Debug.Log(idx);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) && idx / 4 < 9){
            if(idx >= max - 3 && idx <= max) {
                UpItem();
            } else {
                curPos.y -= 160;
            }
            idx += 4;
            Debug.Log(idx);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && idx / 4 > 0) {
            if(idx >= min && idx <= min + 3) {
                DownItem();
            } else {
                curPos.y += 160;
            }
            idx -= 4;
            Debug.Log(idx);
        }
        selectUI.transform.localPosition = curPos;
    }

    public void resetPos() {
        curPos = new Vector3(-600, 400, 0);
        selectUI.transform.localPosition = curPos;
        idx = 0;
    }

    public void UpItem() {
        foreach(Transform child in itemManager.contentArea) {
            child.localPosition = new Vector3(child.localPosition.x, child.localPosition.y + 160, 0);
        }
        max += 4;
        min += 4;
    }

    public void DownItem() {
        foreach(Transform child in itemManager.contentArea) {
            child.localPosition = new Vector3(child.localPosition.x, child.localPosition.y - 160, 0);
        }
        max -= 4;
        min -= 4;
    }
}
