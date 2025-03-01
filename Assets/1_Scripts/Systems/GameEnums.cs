using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public enum ValueTypes
{
    NONE = 0,
    Wood = 1,
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
    Status = 1,
    Upgrade = 2, 
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
    
}

public enum StatusType
{
    NONE = 0,
    HP = 1,
    AttackSpeed = 2,
    Income = 3,
    MoveSpeed = 4,
}