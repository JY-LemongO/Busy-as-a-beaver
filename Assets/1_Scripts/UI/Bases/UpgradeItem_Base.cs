using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItem_Base : MonoBehaviour
{
    public Image upgradeIcon;
    public TMP_Text upgradeName;
    public TMP_Text upgradeDescription;
    public TMP_Text upgradeCost;

    public UpgradeData upgradeData;

    bool isConsumable => DataManager.Instance.coin - (upgradeData.upgradeCost * 10 + upgradeData.upgradeCost * DataManager.Instance.statusData[upgradeData.statusType].statusValue) / 10 >= 0;
    
    //
    public void OnClick_Upgarde()
    {
        if(isConsumable)
        {
            DataManager.Instance.statusData[upgradeData.statusType].statusValue += 1;
            DataManager.Instance.statusData[StatusType.Wood].statusValue -= (upgradeData.upgradeCost * 10 + upgradeData.upgradeCost * DataManager.Instance.statusData[upgradeData.statusType].statusValue) / 10;
            MessageManager.Instance.ViewMessage(MessageType.NOMAL, "success");
            Refresh();
            StatusManager.Instance.SetDirty();
        }
        else
        {
            MessageManager.Instance.ViewMessage(MessageType.NOMAL, $"자원이 부족합니다.");
        }
    }

    public void Initialize(UpgradeData _upgradeData)
    {      
        upgradeData = _upgradeData;

        // upgradeIcon.sprite = GameManager.Instance.Settings.icon_Upgrade_dict[upgradeData.model];
        upgradeName.text = upgradeData.upgradeName;

        string upgradeValue = $"{upgradeData.incriseValue}{GetUpgradeUnit(upgradeData.incriseType)}";
        upgradeDescription.text = string.Format(upgradeData.upgradeDescription, upgradeValue);

        upgradeCost.text = ((int)(upgradeData.upgradeCost * 10 + upgradeData.upgradeCost * DataManager.Instance.statusData[upgradeData.statusType].statusValue) / 10).ToString();

    }
    public void Refresh()
    {
        // upgradeIcon.sprite = GameManager.Instance.Settings.icon_Upgrade_dict[upgradeData.model];
        upgradeName.text = upgradeData.upgradeName;

        string upgradeValue = $"{upgradeData.incriseValue}{GetUpgradeUnit(upgradeData.incriseType)}";
        upgradeDescription.text = string.Format(upgradeData.upgradeDescription, upgradeValue);
        upgradeCost.text = ((int)(upgradeData.upgradeCost * 10 + upgradeData.upgradeCost * DataManager.Instance.statusData[upgradeData.statusType].statusValue) / 10).ToString();
    }

    private string GetUpgradeUnit(IncriseType type)
    {
        string result = string.Empty;
        switch(type)
        {
            case IncriseType.PERCENT:
                {
                    result = "%";
                }
                break;

            default:
                break;
        }

        return result;
    }
}
