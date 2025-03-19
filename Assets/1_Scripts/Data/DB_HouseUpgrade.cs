using System;
using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.Purchasing.MiniJSON;

[Serializable]
public class HouseData
{
    public string model;
    public int index;
    public int beaver;
    public int cost;
}

[CreateAssetMenu(fileName = "DB_HouseUpgrade", menuName = "DB_HouseUpgrade", order = -1)]
public class DB_HouseUpgrade : ScriptableObjectData
{
    public override void SetDictionaryData()
    {
        string[] textLine = CSV.text.Split('\n');

        string[] Keys = textLine[0].Split(',');

        for (int i = 1; i < textLine.Length; i++)
        {
            string[] values = textLine[i].Split(',');

            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            for (int j = 0; j < values.Length; j++)
            {
                keyValues.Add(Keys[j], values[j]);
            }

            HouseData newData = new HouseData();

            newData.model = keyValues[nameof(newData.model)];
            newData.index = int.Parse(keyValues[nameof(newData.index)]);
            newData.beaver = int.Parse(keyValues[nameof(newData.beaver)]);
            newData.cost = int.Parse(keyValues[nameof(newData.cost)]);

            DataManager.Instance.houseData.Add(newData.model, newData);
        }
    }
}

