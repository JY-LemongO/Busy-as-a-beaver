using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyData
{
    public string model;
    public int index;
    public string enemyName;
    public string description;
    public EnemyType enemyType;
    public int hp;
}


[CreateAssetMenu(fileName = "DB_Enemy", menuName = "DB/Enemy", order = -1)]
public class DB_Enemy : ScriptableObjectData
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
            EnemyData newData = new EnemyData();
            newData.model = keyValues[nameof(newData.model)];
            newData.index = int.Parse(keyValues[nameof(newData.index)]);
            newData.enemyName = keyValues[nameof(newData.enemyName)];
            newData.description = keyValues[nameof(newData.description)];
            newData.enemyType = Enum.Parse<EnemyType>(keyValues[nameof(newData.enemyType)]);
            newData.hp = int.Parse(keyValues[nameof(newData.hp)]);
             

            DataManager.Instance.enemyData.Add(newData.model, newData);
        }
    }
}
