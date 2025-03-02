using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;

/// <summary>
/// 계정 전체의 데이터를 관리합니다
/// ex) 현재 업그레이드 정보, 갖고있는 재화, 스테이지 등등
/// 
/// 스텟의 저장도 여기서 관리합니다.
/// </summary>
public class StatusManager : MonoSingleton<StatusManager>
{
    [SerializeField] private bool isDirty = false;
    public void SetDircy() => isDirty = true;


    private void Update() {
        if(isDirty)
        {   
            isDirty = false;
            SaveData();
        }
    }

    private void SaveData()
    {   
        string filePath = "Assets/1_Scripts/Data/DB_Status";
        StreamWriter sw = new StreamWriter(filePath+".csv");

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Clear();

        //keys
        string keys = GameManager.Instance.DataSO[SubUIType.Status].CSV.text.Split('\n')[0].Trim();
        stringBuilder.AppendLine(keys);

        //values 
        foreach(var data in GameManager.Instance.statusData.Values)
        {
            string values = string.Empty;
            values += $"{data.model},{data.index},{data.statusName},{data.type},{data.statusValue},{data.valueType},null";
            stringBuilder.AppendLine(values);
        }

        string trimString = stringBuilder.ToString().Trim();

        sw.WriteLine(trimString);

        sw.Flush();
        sw.Close();

    }

}
