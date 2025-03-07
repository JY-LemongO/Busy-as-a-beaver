using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData
{
    public string model;
    public int index;
    public string itemName;
    public string description;
    public ItemType itemType;
    public int value;
    public IncriseType incriseType;
}


[CreateAssetMenu(fileName = "DB_Item", menuName = "DB/Item", order = -1)]
public class DB_Item : ScriptableObjectData
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
            ItemData newData = new ItemData();
            newData.model = keyValues[nameof(newData.model)];
            newData.index = int.Parse(keyValues[nameof(newData.index)]);
            newData.itemName = keyValues[nameof(newData.itemName)];
            newData.description = keyValues[nameof(newData.description)];
            newData.itemType = Enum.Parse<ItemType>(keyValues[nameof(newData.itemType)]);
            newData.value = int.Parse(keyValues[nameof(newData.value)]);
            newData.incriseType = Enum.Parse<IncriseType>(keyValues[nameof(newData.incriseType)]);

            DataManager.Instance.itemData.Add(newData.model, newData);
        }
    }
}
