using System;
using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

[Serializable]
public class UpgradeData
{
    public string model;
    public int index;
    public string upgradeName;
    public string upgradeDescription;
    public int incriseValue;
    public IncriseType incriseType;
    public int cost;
}

[CreateAssetMenu(fileName = "DB_Upgrade", menuName = "DB/Upgrade", order = -1)]
public class DB_Upgrade : ScriptableObjectData
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
            
            //
            UpgradeData newData = new UpgradeData();
            newData.model = keyValues[nameof(newData.model)];
            newData.index = int.Parse(keyValues[nameof(newData.index)]);
            newData.upgradeName = keyValues[nameof(newData.upgradeName)];
            newData.upgradeDescription = keyValues[nameof(newData.upgradeDescription)];
            newData.incriseValue = int.Parse(keyValues[nameof(newData.incriseValue)]);
            newData.incriseType = Enum.Parse<IncriseType>(keyValues[nameof(newData.incriseType)]);
            // Debug.Log(nameof(newData.upgradeCost));
            newData.cost = int.Parse(keyValues[nameof(newData.cost)]);
            

            GameManager.Instance.upgradeData.Add(newData.model, newData);
        }
    }
}
