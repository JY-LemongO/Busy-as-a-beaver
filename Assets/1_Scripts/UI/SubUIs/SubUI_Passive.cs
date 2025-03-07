using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubUI_Passive : SubUI_Base
{   
    public Transform group;
    public List<PassiveItem_Base> itemList = new List<PassiveItem_Base>();

    #region Life Cycle
    private void OnEnable() {
        Initialize();
    }
    #endregion

    public override void Initialize()
    {
        base.Initialize();

        for(int i = 0; i < itemList.Count; i++)
        {
            itemList[i].passiveData = DataManager.Instance.passiveData[$"Passive_{i+1:D3}"];
            itemList[i].Initialize();
        }
    }
}
