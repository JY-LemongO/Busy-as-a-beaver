using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubUI_BeaverHouseInfo : SubUI_Base
{
    [Header("Model")]
    private BeaverHouse CurrentHouse;

    [Header("View")]
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Image closeImage;
    [SerializeField] private TextMeshProUGUI houseLevelText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Image[] beaverImages;

    private bool IsUpgradeAffordable => DataManager.Instance.coin >= CurrentHouse.houseData.cost;

    private void OnEnable()
    {
        CurrentHouse.OnDataChanged += Initialize;
    }

    private void OnDisable()
    {
        CurrentHouse.OnDataChanged -= Initialize;
    }

    public void OnClick_Upgrade()
    {
        if (IsUpgradeAffordable)
        {
            PerformUpgrade();
            Initialize(CurrentHouse);
        }
        else
        {
            MessageManager.Instance.ViewMessage(MessageType.NOMAL, "자원이 부족합니다.");
        }
    }

    private void PerformUpgrade()
    {
        var statusType = Enum.Parse<StatusType>(CurrentHouse.gameObject.name);
        DataManager.Instance.statusData[StatusType.Wood].statusValue -= CurrentHouse.houseData.cost;
        Debug.Log(DataManager.Instance.statusData[StatusType.Wood].statusValue);
        DataManager.Instance.statusData[CurrentHouse.statusType].statusValue++;

        MessageManager.Instance.ViewMessage(MessageType.NOMAL, "Succes!");
        CurrentHouse.InitData();
        StatusManager.Instance.SetDirty();
    }

    public void Initialize(BeaverHouse beaverHouse)
    {
        SetHouseInfo(beaverHouse);
        UpdateBeaverImages(beaverHouse);

        if (beaverHouse.CurrentHouseLv == 6)
        {
            DisableUpgradeButton();
        }
        else
        {
            EnableUpgradeButton();
        }
    }

    private void UpdateBeaverImages(BeaverHouse beaverHouse)
    {
        for (int i = 0; i < beaverImages.Length; i++)
        {
            if (i < beaverHouse.CurrentHouseLv)
            {
                beaverImages[i].gameObject.SetActive(true);
            }
            else
            {
                beaverImages[i].gameObject.SetActive(false);
            }
        }
    }

    private void SetHouseInfo(BeaverHouse beaverHouse)
    {
        houseLevelText.text = beaverHouse.CurrentHouseLv == 6 ? "Lv. MAX" : $"Lv.{beaverHouse.CurrentHouseLv}";
        costText.text = beaverHouse.CurrentHouseLv == 6 ? "MAX" : beaverHouse.houseData.cost.ToString();
    }

    private void DisableUpgradeButton()
    {
        upgradeButton.interactable = false;
        closeImage.gameObject.SetActive(true);
    }

    private void EnableUpgradeButton()
    {
        upgradeButton.interactable = true;
        closeImage.gameObject.SetActive(false);
    }

    public void Click(BeaverHouse beaverHouse)
    {
        gameObject.SetActive(true);
        Initialize(CurrentHouse);
    }

    public void GetCurrentHouse(BeaverHouse beaverHouse)
    {
        CurrentHouse = beaverHouse;
    }
}
