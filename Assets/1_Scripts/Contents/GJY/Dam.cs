using System.Collections.Generic;
using UnityEngine;

public class Dam : MonoBehaviour
{
    [SerializeField] List<GameObject> _damProgressList;
    [SerializeField] private int _needLogCount;
    public GameObject moveToDamPosition;

    public int NeedLogCount { get; private set; }
    private int _currentLogCount;

    private void Awake()
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
        _currentLogCount = 0;
    }

    public void BuildDam()
    {
        _currentLogCount++;

        //int step = Mathf.FloorToInt(5 * (_currentLogCount - 1) / (NeedLogCount - 1)) + 1;
        //if (step <= _damProgressList.Count && !_damProgressList[step - 1].activeSelf)
        //    _damProgressList[step - 1].SetActive(true);

        if (_currentLogCount == NeedLogCount)
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
