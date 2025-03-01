using System;
using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class StatusData
{
    public string model;
    public int index;
    public string statusName;
    public StatusType type;
    public int statusValue;
    public IncriseType valueType;
}

[CreateAssetMenu(fileName = "DB_Status", menuName = "DB/Status", order = -1 )]
public class DB_Status : ScriptableObjectData
{
    public override void SetDictionaryData()
    {
        string[] textLine = CSV.text.Split('\n');

        string[] Keys = textLine[0].Split(',');

        for(int i = 1; i < textLine.Length; i++)
        {
            string[] values = textLine[i].Split(',');

            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            for(int j = 0; j < values.Length; j ++)
            {
                keyValues.Add(Keys[j], values[j]);
            }  

            if(!keyValues.ContainsKey("index")) continue;

            //
            StatusData newData = new StatusData();
            newData.model = keyValues[nameof(newData.model)];
            newData.index = int.Parse(keyValues[nameof(newData.index)]);
            newData.statusName = keyValues[nameof(newData.statusName)];
            newData.type = Enum.Parse<StatusType>(keyValues[nameof(newData.type)]);
            newData.statusValue = int.Parse(keyValues[nameof(newData.statusValue)]);
            newData.valueType = Enum.Parse<IncriseType>(keyValues[nameof(newData.valueType)]);
            

            GameManager.Instance.statusData.Add(newData.model, newData);
        }
    }
}
