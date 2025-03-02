using System;
using UnityEngine;

public class StageManager : SingletonBase<StageManager>
{
    public event Action<int> OnStageClear;
    public int Stage
    {
        get => _stage;
        private set
        {
            _stage = value;
            OnStageClear?.Invoke(value);
            Debug.Log("스테이지 증가");
        }
    }
    private int _stage;

    public void StageClear()
        => Stage++;

    protected override void InitChild()
    {
        _stage = 1;
    }
}
