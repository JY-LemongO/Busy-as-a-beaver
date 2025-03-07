using System;
using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.Purchasing.MiniJSON;

[Serializable]
public class PassiveData
{
    public string model;
    public int index;
    public string passiveName;
    public string description;
    public StatusType statusType;
    public string incriseValue;
    public IncriseType incriseType;
    public int cost;
    public int maxLevel;

    public Dictionary<int, int> incriseValueDic;
}


[CreateAssetMenu(fileName = "DB_Passive", menuName = "DB/Passive", order = -1)]
public class DB_Passive : ScriptableObjectData
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
            PassiveData newData = new PassiveData();
            newData.model = keyValues[nameof(newData.model)];
            newData.index = int.Parse(keyValues[nameof(newData.index)]);
            newData.passiveName = keyValues[nameof(newData.passiveName)];
            newData.description = keyValues[nameof(newData.description)];
            newData.statusType = Enum.Parse<StatusType>(keyValues[nameof(newData.statusType)]);
            newData.incriseValue = keyValues[nameof(newData.incriseValue)];
            newData.incriseType = Enum.Parse<IncriseType>(keyValues[nameof(newData.incriseType)]);
            newData.cost = int.Parse(keyValues[nameof(newData.cost)]);
            newData.maxLevel = int.Parse(keyValues[nameof(newData.maxLevel)]);

            Dictionary<int,int> temp = new Dictionary<int, int>();
            string[] t = newData.incriseValue.Split('/');
            for(int j = 0; j<t.Length; j++)
            {
                temp.Add(j + 1, int.Parse(t[j]));
            }
            newData.incriseValueDic = temp;            

            DataManager.Instance.passiveData.Add(newData.model, newData);
        }
    }
}
