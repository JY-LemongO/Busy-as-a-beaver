using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SubUI_Upgrade : SubUI_Base
{
    public ScrollRect scrollView;

    public List<UpgradeItem_Base> upgradeItem = new List<UpgradeItem_Base>();

    private void OnEnable() 
    {
        Initialize();
    }

    public override void Initialize() //Upgrade_{}
    {
        scrollView.normalizedPosition = new Vector2(0f, 1f);

        for(int i = 0; i < upgradeItem.Count; i++)
        {
            upgradeItem[i].Initialize(GameManager.Instance.upgradeData[$"Upgrade_{i+1:D3}"]);
        }
    }
}
