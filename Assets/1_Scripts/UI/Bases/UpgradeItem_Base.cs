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

    public UpgradeData upgradeData;

    bool isConsumable => GameManager.Instance.wood - upgradeData.upgradeCost >= 0;
    
    //
    public void OnClick_Upgarde()
    {
        if(isConsumable)
        {
            GameManager.Instance.statusData[upgradeData.statusType].statusValue += 1;
            GameManager.Instance.statusData[StatusType.Wood].statusValue -= upgradeData.upgradeCost;
            MessageManager.Instance.ViewMessage(MessageType.NOMAL, "success");
            Initialize();
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

    }
    public void Initialize()
    {
        // upgradeIcon.sprite = GameManager.Instance.Settings.icon_Upgrade_dict[upgradeData.model];
        upgradeName.text = upgradeData.upgradeName;

        string upgradeValue = $"{upgradeData.incriseValue}{GetUpgradeUnit(upgradeData.incriseType)}";
        upgradeDescription.text = string.Format(upgradeData.upgradeDescription, upgradeValue);
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
