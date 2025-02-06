using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject winPanelObj;
    public GameObject losePanelObj;
    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void ShowGameOverPanel(bool _win)
    {
        winPanelObj.SetActive(_win);
        losePanelObj.SetActive(!_win);
    }
}
