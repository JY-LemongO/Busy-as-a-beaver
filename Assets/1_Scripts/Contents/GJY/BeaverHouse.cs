using System;
using UnityEngine;
using UnityEngine.UI;

public class BeaverHouse : MonoBehaviour, ITouchable
{
    public Action<BeaverHouse> OnHouseClick;
    public Action<BeaverHouse> OnDataChanged;

    public GameObject[] beaver;
    public StatusType statusType;
    public GameObject preview;

    private bool isActive = true;

    [Header("Data")]
    public HouseData houseData;
    private string Key;

    private void OnEnable()
    {
        InitData();
        HouseManager.Instance.AddHouse(this);

        BuildingSystem.Instance.OnPVChanged += HandlePVChanged;
    }

    public void InitData()
    {
        Key = $"House_{(DataManager.Instance.statusData[statusType].statusValue) + 1:D3}";
        Debug.Log(statusType);

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

    public void UpdateHouseActivity()
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
    private void HandlePVChanged(bool newValue)
    {
        AlreadyBuild(newValue);
    }

    public void Interact()
    {
        OnHouseClick?.Invoke(this);
    }

    public void SetBeaver()
    {
        for (int i = 0; i < CurrentHouseLv; i++)
        {
            ActivateBeaver(i);
        }
    }

    private void ActivateBeaver(int index)
    {
        if (!beaver[index].activeSelf)
        {
            beaver[index].SetActive(true);
            beaver[index].GetComponent<Player>().house = this;
        }
    }

    private void AlreadyBuild(bool newValue)
    {
        if (preview == null)
            return;
        if (newValue && CurrentHouseLv == 0)
        {
            preview.SetActive(true);
        }
        else
        {
            preview.SetActive(false);
        }
    }

    public void Build()
    {
        CurrentHouseLv++;
        preview.SetActive(false);
        DataManager.Instance.statusData[StatusType.Wood].statusValue -= 1000;
        InitData();
    }
}
