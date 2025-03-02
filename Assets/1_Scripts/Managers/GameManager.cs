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



    private void OnEnable() {
        if(!isInitialize)
        {
            foreach(var data in DataSO.Values)
            {
                data.SetDictionaryData();
            }

            isInitialize = true;
        }


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
    #endregion
}
