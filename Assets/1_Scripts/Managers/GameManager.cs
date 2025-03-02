using System;
using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

/// <summary>
/// 접근방법 : GameManager.Instance.변수명
/// 필요한 데이터는 var에 정리해주세요!
/// 
/// 
/// 저장되는 데이터(체력, 이동속도, 재화 등등)은 statusData에 저장됩니다!
/// 접근방법
/// statusData[StatusType.HP].statusValue -= 10; //타입을 key로 접근하시고, statusValue를 수정해주시면 됩니다!
/// StatusManager.Instance.SetDircy(); //이 함수를 호출하면 세이브됩니다! (아직 게임 강제종료 세이브는 구현 전입니다..!)
/// </summary>
/// 
    

public class GameManager : MonoSingleton<GameManager>
{
    //var
    public int coin => statusData[StatusType.Wood].statusValue;
    public int diamond => statusData[StatusType.Diamond].statusValue;

    //move
    private float MoveSpeed => statusData[StatusType.MoveSpeed].statusValue;
    private bool isPassiveSpeedOpen => statusData[StatusType.Passive_QuickFeet].statusValue > 0;
    private float passiveSpeed => isPassiveSpeedOpen ? passiveData["Passive_005"].incriseValueDic[statusData[StatusType.Passive_QuickFeet].statusValue] * 0.01f : 0;
    private float upgradeSpeed => upgradeData["Upgrade_001"].incriseValue * statusData[StatusType.Upgrade_Speed].statusValue * 0.01f;
    public float fixMoveSpeed => MoveSpeed * (passiveSpeed + upgradeSpeed + 1);


    private bool isInitialize = false;

    //scriptable Object
    [SerializeField] public Settings_UI Settings;

    //GameObject
    [SerializeField] public Canvas_SubUI SubUI;


    //Data List
    [SerializedDictionary("SubUI", "SO")]
    public SerializedDictionary<SubUIType, ScriptableObjectData> DataSO = new SerializedDictionary<SubUIType, ScriptableObjectData>();

    //Data
    [SerializedDictionary("model", "data")]
    public SerializedDictionary<string, UpgradeData> upgradeData = new SerializedDictionary<string, UpgradeData>();

    [SerializedDictionary("StatusType", "data")]
    public SerializedDictionary<StatusType, StatusData> statusData =new SerializedDictionary<StatusType, StatusData>();

    [SerializedDictionary("model", "data")]
    public SerializedDictionary<string, PassiveData> passiveData = new SerializedDictionary<string, PassiveData>();

    [SerializedDictionary("model", "data")]
    public SerializedDictionary<string, ItemData> itemData = new SerializedDictionary<string, ItemData>();

    [SerializedDictionary("model", "data")]
    public SerializedDictionary<string, EnemyData> enemyData = new SerializedDictionary<string, EnemyData>();

    [SerializedDictionary("model", "data")]
    public SerializedDictionary<string, StageData> stageData = new SerializedDictionary<string, StageData>();


    private void OnEnable() {
        if(!isInitialize)
        {
            foreach(var data in DataSO.Values)
            {
                data.SetDictionaryData();
            }

            isInitialize = true;
        }

        Debug.Log($"{GetStageData(4).model}");

        //test
        // MessageManager.Instance.ViewMessage(MessageType.Enemy, enemyData["Enemy_001"]);
    }
    
    #region public Method
    public int GetValue(ValueTypes type)
    {   
        if(!isInitialize) return 0;

        int result = 0;
        switch(type)
        {
            case ValueTypes.Coin: result = coin; break;
            case ValueTypes.Diamond: result = diamond; break;
            
            default: break;
        }
        return result;
    }

    public void SetValue(StatusType type, int value)
    {
        statusData[type].statusValue += value;
        StatusManager.Instance.SetDirty();
    }

    public void OpenPopup(PopupType type)
    {
        SubUI.popup_Wraps[type].OpenPopup(type);;
    }

    public StageData GetStageData(int stage)
    {
        return stageData[$"stage_{stage:D3}"];
    }
    #endregion
}
