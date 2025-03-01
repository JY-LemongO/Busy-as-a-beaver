using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class Canvas_SubUI : MonoBehaviour
{
    public SerializedDictionary<SubUIType, SubUI_Base> subUI_Wraps = new SerializedDictionary<SubUIType, SubUI_Base>();

    private void OnEnable() {
        
    }

    public void CloseAllSubUI()
    {
        foreach(var item in subUI_Wraps.Values)
        {
            item.CloseUI(item.type);
        }
    }

    public void OpenUI(SubUIType type)
    {   
        CloseAllSubUI();
        subUI_Wraps[type].OpenUI(type);
    }
}
