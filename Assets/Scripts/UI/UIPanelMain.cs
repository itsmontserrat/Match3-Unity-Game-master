using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelMain : MonoBehaviour, IMenu
{
    [SerializeField] private Button btnTimer;

    [SerializeField] private Button btnMoves;
    [SerializeField] private Button btnMode;

    private UIMainManager m_mngr;

    private void Awake()
    {
        btnMoves.onClick.AddListener(OnClickMoves);
        btnTimer.onClick.AddListener(OnClickTimer);
        btnMode.onClick.AddListener(OnClickMode);
    }

    private void OnDestroy()
    {
        if (btnMoves) btnMoves.onClick.RemoveAllListeners();
        if (btnTimer) btnTimer.onClick.RemoveAllListeners();
        if (btnMode) btnMode.onClick.RemoveAllListeners();
    }

    public void Setup(UIMainManager mngr)
    {
        m_mngr = mngr;
    }

    private void OnClickTimer()
    {
        m_mngr.LoadLevelTimer();
    }

    private void OnClickMoves()
    {
        m_mngr.LoadLevelMoves();
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
    public void OnClickMode()
    {
        m_mngr.LoadLevelMode();
        if(btnMode.gameObject.GetComponentInChildren<Text>().text == "NORMAL")
        {
            btnMode.gameObject.GetComponentInChildren<Text>().text = "FISH";
        }
        else if(btnMode.gameObject.GetComponentInChildren<Text>().text == "FISH")
        {
            btnMode.gameObject.GetComponentInChildren<Text>().text = "NORMAL";
        }
    }
}
