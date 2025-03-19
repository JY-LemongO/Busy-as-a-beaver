using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubUI_BeaverHouseInfo : SubUI_Base
{
    [Header("Model")]
    [SerializeField] BeaverHouse beaverHouse;
    [Header("View")]
    [SerializeField] Image[] BeaverImg;

    public BeaverHouse_Base upgradeHouse;


    public override void Initialize()
    {
        beaverHouse = upgradeHouse.beaverHouse;

        var houseKey = $"House_{beaverHouse.CurrentHouseLv:D3}";

        Debug.Log(houseKey);
        if (!DataManager.Instance.houseData.ContainsKey(houseKey))
        {
            Debug.LogError($"House data for {houseKey} is missing in houseData.");
            return;
        }

        upgradeHouse.Initialize(DataManager.Instance.houseData[houseKey]);
    }

    public void Click()
    {
        Initialize();
        gameObject.SetActive(true);
    }
}
