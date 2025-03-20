using System;
using UnityEngine;
using UnityEngine.UI;

public class BeaverHouse : MonoBehaviour, ITouchable
{
    public Action<BeaverHouse> OnHouseClick;
    public Action<BeaverHouse> OnDataChanged;

    public GameObject[] beaver;
    public StatusType statusType => Enum.Parse<StatusType>(gameObject.name);

    private bool isActive = true;

    [Header("Data")]
    public HouseData houseData;
    private string Key => $"House_{(DataManager.Instance.statusData[statusType].statusValue) + 1:D3}";

    private void OnEnable()
    {
        InitData();
    }

    public void InitData()
    {
        if (IsHouseDataAvailable())
        {
            houseData = DataManager.Instance.houseData[Key];
        }
        else
        {
            houseData = new HouseData();
        }

        UpdateHouseActivity();
        SetBeaver();
    }

    private bool IsHouseDataAvailable()
    {
        return DataManager.Instance.houseData.ContainsKey(Key);
    }

    private void UpdateHouseActivity()
    {
        isActive = DataManager.Instance.statusData[statusType].statusValue != 0;
        gameObject.SetActive(isActive);
    }

    public int CurrentHouseLv
    {
        get => DataManager.Instance.statusData[statusType].statusValue;
        set
        {
            DataManager.Instance.statusData[statusType].statusValue = value;
            SetBeaver();
            OnDataChanged?.Invoke(this);
            StatusManager.Instance.SetDirty();
        }
    }

    public void Interact()
    {
        OnHouseClick?.Invoke(this);
    }

    public void SetBeaver()
    {
        for (int i = 0; i < CurrentHouseLv - 1; i++)
        {
            ActivateBeaver(i);
        }
    }

    private void ActivateBeaver(int index)
    {
        if (!beaver[index].activeSelf)
        {
            beaver[index].SetActive(true);
        }
    }
}
