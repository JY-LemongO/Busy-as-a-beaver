using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Top_Base : MonoBehaviour
{
    public ValueTypes valueType;
    public Image iconImg;
    public TMP_Text valueText;

    #region Life Cycle
    private void OnEnable() {
        Initialize();
    }

    private void Update() {
        SetValue();
    }
    #endregion

    #region public Function
    
    #endregion

    #region private Function
    private void Initialize()
    {   
        //아이콘 지정
        SetIcon();
        SetValue();
        
    }

    //#region GJY
    //private void OnValueChanged(int value)
    //{
    //    valueText
    //}
    //#endregion


    private void SetIcon()
    {   
        iconImg.sprite = GameManager.Instance.Settings.icon_ValueSprite[valueType];
    }

    private void SetValue()
    {
        valueText.text = GameManager.Instance.GetValue(valueType).ToString(); //추후에 바꿔야함. 어디에 연결시켜야됨.
    }
    #endregion
}
