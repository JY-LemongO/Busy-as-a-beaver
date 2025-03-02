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

    #region Life Cycle
    private void OnEnable() {
    }
    #endregion
    
    #region Button Function
    public void OnClick_PassiveBtn()
    {
        if(true)// 나중에 조건 수정
        {
            GameManager.Instance.statusData[passiveData.statusType].statusValue += 1;
            GameManager.Instance.statusData[StatusType.Wood].statusValue -= passiveData.cost;
            Initialize();
            StatusManager.Instance.SetDirty();
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
