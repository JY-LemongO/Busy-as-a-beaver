using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BeaverHouse_Base : MonoBehaviour
{
    [SerializeField] HouseManager houseManager;
    [SerializeField] Button button;
    [SerializeField] Image closeImage;
    [SerializeField] TextMeshProUGUI houseLv;
    [SerializeField] TextMeshProUGUI cost;

    public BeaverHouse beaverHouse => houseManager.currentHouse;

    //int LV => DataManager.Instance.statusData[StatusType.House_Index].statusValue;

    bool isConsumable => DataManager.Instance.coin - beaverHouse.houseData.cost >= 0;

    string currentHouseName = "";

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    public void OnClick_Upgarde()
    {
        currentHouseName = beaverHouse.name;

        if (isConsumable)
        {
            StatusType statusType = Enum.Parse<StatusType>(currentHouseName);
            DataManager.Instance.statusData[StatusType.Wood].statusValue -= beaverHouse.houseData.cost;
            beaverHouse.CurrentHouseLv++;

            MessageManager.Instance.ViewMessage(MessageType.NOMAL, "success");
            Refresh();
            StatusManager.Instance.SetDirty();
        }
        else
        {
            MessageManager.Instance.ViewMessage(MessageType.NOMAL, $"자원이 부족합니다.");
        }
    }

    public void Initialize(HouseData _houseData)
    {
        beaverHouse.houseData = _houseData;

        if (beaverHouse.CurrentHouseLv == 6)
        {
            button.interactable = false;
            closeImage.gameObject.SetActive(true);
            houseLv.text = ($"Lv. MAX");

            cost.text = "MAX";
            return;
        }
        else
        {
            button.interactable = true;
            closeImage.gameObject.SetActive(false);
        }
        
        houseLv.text = ($"Lv.{beaverHouse.houseData.index.ToString()}");

        cost.text = beaverHouse.houseData.cost.ToString();
    }

    public void Refresh()
    {
        if (beaverHouse.CurrentHouseLv == 6)
        {
            button.interactable = false;
            closeImage.gameObject.SetActive(true);
            houseLv.text = ($"Lv. MAX");

            cost.text = "MAX";
            return;
        }
        else
        {
            button.interactable = true;
            closeImage.gameObject.SetActive(false);
        }

        houseLv.text = ($"Lv.{beaverHouse.houseData.index.ToString()}");

        cost.text = beaverHouse.houseData.cost.ToString();
    }

}
