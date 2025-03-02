using System;

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
        }
    }
    private int _stage;

    public void StageClear()
        => Stage++;

    protected override void InitChild()
    {
        
    }
}
