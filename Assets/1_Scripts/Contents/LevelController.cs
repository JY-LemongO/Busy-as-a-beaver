using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levelPresetList;

    private Level _currentLevel;
    private int _currentLevelValue;
    private const int LEVEL_PHASE = 5;    

    private void Awake()
    {
        SetLevel(1);
        StageManager.Instance.OnStageClear += SetLevel;
    }

    public void SetLevel(int level)
    {
        if (_currentLevel != null)
            PoolManager.Instance.Return(_currentLevel.gameObject);

        PoolManager.Instance.Get(_levelPresetList[level - 1]);
    }
}
