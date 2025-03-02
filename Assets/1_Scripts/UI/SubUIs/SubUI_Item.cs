using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubUI_Item : SubUI_Base
{
    public List<Item_Base> itemList = new List<Item_Base>();

    private void OnEnable() 
    {
        Initialize();
    }

    public override void Initialize() //Upgrade_{}
    {
        for(int i = 0; i < itemList.Count; i++)
        {
            itemList[i].parent = this.gameObject;
            itemList[i].Initialize(GameManager.Instance.itemData[$"Item_{i+1:D3}"]);
        }
    }
}
