using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public enum ValueTypes
{
    NONE = 0,
    Coin = 1,
    Diamond = 2,
}

[Serializable]
public enum ScriptableObjectType
{
    NONE = 0,
    Setting_UI = 1,
}

[Serializable]
public enum SubUIType
{
    NONE = 0,
    ConstructStatus = 1,
    Upgrade = 2, 
    Passive = 3,
    Settings = 4,
    Enemy = 5,
    Item = 6,
    Stage = 7,
}

public enum IncriseType
{
    NONE = 0,
    PERCENT = 1,
    NOMAL = 2,
}

public enum DataType
{
    NONE = 0,
    DB_Upgrade = 1,
    DB_Status = 2,
    DB_Passive = 3,
    DB_Enemy = 4,
    DB_Item = 5,
    DB_Stage = 6,
    
}

public enum StatusType
{
    NONE = 0,
    HP = 1,
    AttackSpeed = 2,
    Income = 3,
    MoveSpeed = 4,
    Wood = 5,
    Diamond = 6,


    //passive
    Passive_Sharp = 101,
    Passive_Sedulity = 102,
    Passive_HardTeeth = 103,
    Passive_SeasonalBird = 104,
    Passive_QuickFeet = 105,
    Passive_GoldenSpoon = 106,

    //upgrade
    Upgrade_Speed = 201,
    Upgrade_Power = 202,
    Upgrade_Income = 203,
    Upgrade_TreeRegen = 204,
    Upgrade_BeaverHP = 205,

    //item
    Item_Apple = 301,
    Item_Banana = 302,
    Item_Peach = 303,
}

public enum MessageType
{
    NONE = 0,
    NOMAL = 1,
    Enemy = 2,
}

public enum EnemyType
{
    NONE = 0,
    Wolf = 1,
    Monkey = 2,
    Elepent = 3,
    Eagle = 4,
}

public enum ItemType
{
    NONE = 0,
    Apple = 1,
    Banana = 2,
    Peach = 3,
}

public enum PopupType
{
    NONE = 0,
    Clear = 1,
}