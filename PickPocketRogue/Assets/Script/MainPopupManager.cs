using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPopupManager : MonoBehaviour
{
    public GameObject savePopup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNewGame() {
        savePopup.SetActive(true);
    }

    public void OnClickBack() {
        savePopup.SetActive(false);
    }
}
