using System.Collections.Generic;
using UnityEngine;

public class Dam : MonoBehaviour
{
    [SerializeField] List<GameObject> _damProgressList;

    public int NeedLogCount { get; private set; }
    private int _currentLogCount;

    public void SetupDam(int logCount)
    {
        foreach (var logProgress in _damProgressList)
            logProgress.SetActive(false);
        NeedLogCount = logCount;
        _currentLogCount = 0;
    }

    public void BuildDam()
    {
        _currentLogCount++;

        int step = Mathf.FloorToInt(5 * (_currentLogCount - 1) / (NeedLogCount - 1)) + 1;
        if (step <= _damProgressList.Count && !_damProgressList[step - 1].activeSelf)
            _damProgressList[step - 1].SetActive(true);

        if (_currentLogCount == NeedLogCount)
        {
            // To Do - Stage Clear            
            DamManager.Instance.BuildDamComplete();
        }
    }
}
