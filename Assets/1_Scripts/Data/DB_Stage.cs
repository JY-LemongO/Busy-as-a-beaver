using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StageData
{
    public string model;
    public int index;
    public int maxHouse;
    public float needWood; 
}


[CreateAssetMenu(fileName = "DB_Stage", menuName = "DB/Stage", order = -1 )]
public class DB_Stage : ScriptableObjectData
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
            StageData newData = new StageData();
            newData.model = keyValues[nameof(newData.model)];
            newData.index = int.Parse(keyValues[nameof(newData.index)]);
            newData.maxHouse = int.Parse(keyValues[nameof(newData.maxHouse)]);
            newData.needWood = float.Parse(keyValues[nameof(newData.needWood)]);
            

            DataManager.Instance.stageData.Add(newData.model, newData);
        }
    }
}
