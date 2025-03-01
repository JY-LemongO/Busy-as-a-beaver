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
        //아이콘 초기화
        switch(buttonType)
        {
            case Button_Bottom_Types.Status: //정보창
                {
                    
                }
                break;

            case Button_Bottom_Types.Upgrade: //업그레이드
                {

                }
                break;

            default:
                break;
        }
    }

    #endregion
}
