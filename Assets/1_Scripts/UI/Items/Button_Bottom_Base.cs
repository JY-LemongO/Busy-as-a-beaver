using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Button_Bottom_Base : MonoBehaviour
{
    public Button_Bottom_Types buttonType;
    public Image iconImg;

    private void OnEnable() {
        Initialize();
    }


    #region public Function
    public void OnClick_Button()
    {   
        switch(buttonType)
        {
            case Button_Bottom_Types.Status:
                {

                }
                break;
            
            case Button_Bottom_Types.Upgrade:
                {

                }
                break;
            
            default:
                break;
        }
    }

    #endregion

    #region private Function
    private void Initialize()
    {   
        iconImg.sprite = GameManager.Instance.Settings.icon_Button_Bottom_Sprite[buttonType];
    }

    #endregion
}
