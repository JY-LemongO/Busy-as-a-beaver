using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class Canvas_SubUI : MonoBehaviour
{
    public SerializedDictionary<SubUIType, SubUI_Base> subUI_Wraps = new SerializedDictionary<SubUIType, SubUI_Base>();

    public SerializedDictionary<PopupType, Popup_Base> popup_Wraps = new SerializedDictionary<PopupType, Popup_Base>();
    private void OnEnable() {
        
    }

    public void CloseAllSubUI()
    {
        foreach(var item in subUI_Wraps.Values)
        {
            item.CloseUI(item.type);
        }
    }
    
    public void ClosePopup()
    {
        foreach(var item in popup_Wraps.Values)
        {
            item.ClosePopup(item.type);
        }
    }

    public void OpenUI(SubUIType type)
    {   
        CloseAllSubUI();
        subUI_Wraps[type].OpenUI(type);
    }

    public void OpenPopup(PopupType type)
    {
        ClosePopup();
        popup_Wraps[type].OpenPopup(type);
    }
}
