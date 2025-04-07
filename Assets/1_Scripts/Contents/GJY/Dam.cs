using System;
using System.Collections.Generic;
using UnityEngine;

public class Dam : MonoBehaviour
{
    public event Action DamChanged;

    [SerializeField] List<GameObject> _damProgressList;
    [SerializeField] private int _needLogCount;
    public GameObject moveToDamPosition;

    public StatusType statusType;
    public int NeedLogCount { get; private set; }

    public int CurrentLogCount
    {
        get => DataManager.Instance.statusData[statusType].statusValue;
        set
        {
            int clampedValue = Mathf.Clamp(value, 0, NeedLogCount);
            DataManager.Instance.statusData[statusType].statusValue = clampedValue;
            DamChanged?.Invoke();
            
            StatusManager.Instance.SetDirty();
        }
    }

    private void OnEnable()
    {
        if (DamManager.Instance.Dam == null)
        {
            DamManager.Instance.SetDam(this);
        }
    }

    public void SetupDam(int logCount)
    {
        NeedLogCount = logCount;
        CurrentLogCount = DataManager.Instance.statusData[statusType].statusValue;

        foreach (var logProgress in _damProgressList)
            logProgress.SetActive(false);
    }

    public void BuildDam()
    {
        CurrentLogCount++;

        int activeCount = (CurrentLogCount / (NeedLogCount / _damProgressList.Count)) - 1;

        if (activeCount == -1)
            return;
        if (!_damProgressList[activeCount].activeSelf)
        {
            _damProgressList[activeCount].SetActive(true);
        }

        if (CurrentLogCount == NeedLogCount)
        {
            // To Do - Stage Clear            
            DamManager.Instance.BuildDamComplete();
        }
    }

    public void ResetDam()
    {
        foreach (var logProgress in _damProgressList)
            logProgress.SetActive(false);

        Debug.Log("리셋 댐");
    }
}
