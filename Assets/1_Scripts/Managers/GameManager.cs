using System;
using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 접근방법 : GameManager.Instance.변수명
/// 필요한 데이터는 var에 정리해주세요!
/// 
/// 
public class GameManager : MonoSingleton<GameManager>
{
    //scriptable Object
    [SerializeField] public Settings_UI Settings;

    //GameObject
    [SerializeField] public Canvas_SubUI SubUI;

    public BeaverHouse currentHouse;

    private void Update() {
        if(SceneManager.GetActiveScene().name == "MainScene" && GameObject.Find("Canvas_SubUI").GetComponent<Canvas_SubUI>() != null)
            SubUI = GameObject.Find("Canvas_SubUI").GetComponent<Canvas_SubUI>();
    }

    public int GetCurrentStage()
    {
        return 1;
    }
    #region public Method

    public void OpenPopup(PopupType type)
    {
        SubUI.popup_Wraps[type].OpenPopup(type);;
    }

    #endregion
}
