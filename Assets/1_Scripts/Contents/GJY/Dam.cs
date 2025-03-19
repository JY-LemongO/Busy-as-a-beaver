using System;
using System.Collections.Generic;
using UnityEngine;

public class Dam : MonoBehaviour
{
    public event Action DamChanged;

    [SerializeField] List<GameObject> _damProgressList;
    [SerializeField] private int _needLogCount;
    public GameObject moveToDamPosition;

    public int NeedLogCount { get; private set; }

    private int m_CurrentLogCount;

    public int CurrentLogCount
    {
        get => m_CurrentLogCount;
        set
        {
            m_CurrentLogCount = Mathf.Clamp(value, 0, NeedLogCount);
            DamChanged?.Invoke();
            StatusManager.Instance.SetDirty();
        }
    }

    private void OnEnable()
    {
        if (DamManager.Instance.Dam == null)
        {
            DamManager.Instance.SetDam(this);
            SetupDam(100);
        }
    }

    public void SetupDam(int logCount)
    {
        NeedLogCount = logCount;
        CurrentLogCount = 0;

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
