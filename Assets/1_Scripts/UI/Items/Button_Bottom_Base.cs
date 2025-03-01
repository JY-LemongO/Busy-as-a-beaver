using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Button_Bottom_Base : MonoBehaviour
{
    public SubUIType type;
    public Image iconImg;

    private void OnEnable() {
        Initialize();
    }


    #region public Function
    public void OnClick_Button()
    {   
        GameManager.Instance.SubUI.CloseAllSubUI();
        GameManager.Instance.SubUI.subUI_Wraps[type].OpenUI(type);
    }

    #endregion

    #region private Function
    private void Initialize()
    {   
        iconImg.sprite = GameManager.Instance.Settings.icon_Button_Bottom_Sprite[type];
    }

    #endregion
}
