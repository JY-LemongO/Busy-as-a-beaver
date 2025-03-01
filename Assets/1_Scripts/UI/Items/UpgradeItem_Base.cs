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

    public void OnClick_Upgarde()
    {

    }

    public void Initialize(UpgradeData _upgradeData)
    {      
        upgradeData = _upgradeData;

        upgradeIcon.sprite = GameManager.Instance.Settings.icon_Upgrade_dict[upgradeData.model];
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
