using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PassiveItem_Base : MonoBehaviour
{
    public Image passiveIcon;
    public TMP_Text passiveNameText;
    public TMP_Text passiveLevelText;
    public TMP_Text passiveCostText;

    public PassiveData passiveData;

    bool isMaxLevel => GameManager.Instance.statusData[passiveData.statusType].statusValue <= passiveData.maxLevel;
    bool isConsumable => GameManager.Instance.wood - passiveData.cost >= 0;
    bool isUpgradeable => isMaxLevel && isConsumable;

    #region Life Cycle
    private void OnEnable() {
    }
    #endregion
    
    #region Button Function
    public void OnClick_PassiveBtn()
    {
        if(isUpgradeable)
        {
            GameManager.Instance.statusData[passiveData.statusType].statusValue += 1;
            GameManager.Instance.statusData[StatusType.Wood].statusValue -= passiveData.cost;
            Initialize();
            StatusManager.Instance.SetDirty();
        }
        else
        {   
            MessageManager.Instance.ViewMessage(MessageType.NOMAL, $"업그레이드 실패"); //나중에 뭐때문에 실패했는지 알려주기
        }
    }
    #endregion

    public void Initialize()
    {
        passiveIcon.sprite = GameManager.Instance.Settings.icon_Passive_dict[passiveData.model];
        passiveNameText.text = passiveData.passiveName;
        passiveCostText.text = passiveData.cost.ToString();
        passiveLevelText.text = $"Lv.{GameManager.Instance.statusData[passiveData.statusType].statusValue.ToString()}";
    }

}
