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
    [SerializedDictionary]
    public SerializedDictionary<Button_Bottom_Types, Sprite> icon_Button_Bottom_Sprite = new SerializedDictionary<Button_Bottom_Types, Sprite>();

}
