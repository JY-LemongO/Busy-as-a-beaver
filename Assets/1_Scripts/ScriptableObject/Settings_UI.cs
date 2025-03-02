using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;


[CreateAssetMenu(fileName ="Settings_UI", menuName = "ScriptableObject/UI", order = -1), Serializable]
public class Settings_UI : ScriptableObject
{      
    public ScriptableObjectType type;

    //Dictionary
    [SerializedDictionary("ValueTypes", "Sprite")]
    public SerializedDictionary<ValueTypes, Sprite> icon_ValueSprite = new SerializedDictionary<ValueTypes, Sprite>();

    [SerializedDictionary("ValueTypes", "Sprite")]
    public SerializedDictionary<SubUIType, Sprite> icon_Button_Bottom_Sprite = new SerializedDictionary<SubUIType, Sprite>();

    [SerializedDictionary("ValueTypes", "Sprite")]
    public SerializedDictionary<string, Sprite> icon_Upgrade_dict = new SerializedDictionary<string, Sprite>();
    
    [SerializedDictionary("ValueTypes", "Sprite")]
    public SerializedDictionary<string, Sprite> icon_Passive_dict = new SerializedDictionary<string, Sprite>();
}
