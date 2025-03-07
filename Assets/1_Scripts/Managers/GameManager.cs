using System;
using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    //scriptable Object
    [SerializeField] public Settings_UI Settings;

    //GameObject
    [SerializeField] public Canvas_SubUI SubUI;

    private void Update() {
        if(LoadingSceneManager.GetNowSceneName() == "MainScene" && GameObject.Find("Canvas_SubUI").GetComponent<Canvas_SubUI>() != null)
            SubUI = GameObject.Find("Canvas_SubUI").GetComponent<Canvas_SubUI>();
    }
    public int GetCurrentStage()
    {
        //TODO 임시값 1임
        return 1;
    }
    #region public Method

    public void OpenPopup(PopupType type)
    {
        SubUI.popup_Wraps[type].OpenPopup(type);;
    }

    #endregion
}
