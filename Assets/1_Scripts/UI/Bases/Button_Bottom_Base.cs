using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Button_Bottom_Base : MonoBehaviour
{
    public SubUIType subUIType;
    public Image iconImg;

    private void OnEnable() {
        Initialize();
    }


    #region public Function
    public void OnClick_Button()
    {   
        GameManager.Instance.SubUI.CloseAllSubUI();
        GameManager.Instance.SubUI.subUI_Wraps[subUIType].OpenUI(subUIType);
    }

    #endregion

    #region private Function
    private void Initialize()
    {   
        // Debug.Log($"{subUIType}");
        // iconImg.sprite = GameManager.Instance.Settings.icon_Button_Bottom_Sprite[subUIType];
    }

    #endregion
}
