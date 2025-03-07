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
    public void SetDirty() => isDirty = true;


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
        string keys = DataManager.Instance.DataSO[SubUIType.ConstructStatus].CSV.text.Split('\n')[0].Trim();
        stringBuilder.AppendLine(keys);

        //values 
        foreach(var data in DataManager.Instance.statusData.Values)
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

    public void Reset()
    {
        foreach(var item in DataManager.Instance.statusData.Values)
        {
            switch (item.type)
            {
                case StatusType.NONE:
                case StatusType.HP:
                    {
                        DataManager.Instance.statusData[item.type].statusValue = 100;
                    }
                    break;
                case StatusType.AttackSpeed:
                    {
                        DataManager.Instance.statusData[item.type].statusValue = 5;
                    }
                    break;
                case StatusType.Income:
                    {
                        DataManager.Instance.statusData[item.type].statusValue = 100;
                    }
                    break;
                case StatusType.MoveSpeed:
                    {
                        DataManager.Instance.statusData[item.type].statusValue = 4;
                    }
                    break;

                //
                case StatusType.Wood:
                case StatusType.Diamond:
                case StatusType.Passive_Sharp:
                case StatusType.Passive_Sedulity:
                case StatusType.Passive_HardTeeth:
                case StatusType.Passive_SeasonalBird:
                case StatusType.Passive_QuickFeet:
                case StatusType.Passive_GoldenSpoon:
                case StatusType.Upgrade_BeaverHP:
                case StatusType.Upgrade_Income:
                case StatusType.Upgrade_Power:
                case StatusType.Upgrade_Speed:
                case StatusType.Upgrade_TreeRegen:
                case StatusType.Item_Apple:
                case StatusType.Item_Banana:
                case StatusType.Item_Peach:
                    {
                        DataManager.Instance.statusData[item.type].statusValue = 0;
                    }   
                    break;
                default:
                    break;
            }

            StatusManager.Instance.SetDirty();
        }
    }

}
