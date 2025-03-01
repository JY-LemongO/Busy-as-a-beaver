using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

/// <summary>
/// 접근방법 : GameManager.Instance.변수명
/// 필요한 데이터는 var에 정리해주세요!
/// </summary>
/// 
    

public class GameManager : MonoSingleton<GameManager>
{   
    //var
    private int wood;
    public int Wood{ get { return wood;} set{ wood = value; }}
    private int diamond;
    public int Diamond { get { return diamond; } set { diamond = value; }}


    //scriptable Object
    [SerializeField] public Settings_UI Settings;

    //GameObject
    [SerializeField] public Canvas_SubUI SubUI;
    
    #region public Method
    public int GetValue(ValueTypes type)
    {
        int result = 0;
        switch(type)
        {
            case ValueTypes.Wood: result = wood; break;
            case ValueTypes.Diamond: result = Diamond; break;
            
            default: break;
        }
        return result;
    }
    #endregion
}
