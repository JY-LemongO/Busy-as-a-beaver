using System;
using System.Collections;
using UnityEngine;

public class Resource_Tree : MonoBehaviour
{   
    // float baseLogTime = 5f;
    [SerializeField] private float _logTime => GameManager.Instance.AttackSpeed;

    public event Action OnTreeDestroyed;
    public event Action<float> OnLogging;

    public bool IsDestroyed { get; private set; }
    public bool IsTargeted {  get; private set; }
    public bool IsLogging { get; private set; }

    private Beaver _workedBeaver;    

    public void Setup()
    {
        // To Do - 나무 스테이터스 넣기
        IsDestroyed = false;
    }

    public void SetBeaver(Beaver player)
    {
        IsTargeted = true;
        _workedBeaver = player;
    } 

    public void LogTree()
    {
        if (IsLogging)
            return;

        // To Do - Logging
        IsLogging = true;
        StartCoroutine(Co_Logging());
    }    

    private void DestroyTree()
    {        
        TreeManager.Instance.DestroyTree(this, _workedBeaver);        
        OnTreeDestroyed?.Invoke();
        OnTreeDestroyed = null;
        IsTargeted = false;
        IsLogging = false;
        IsDestroyed = true;
        _workedBeaver = null;        
    }

    private IEnumerator Co_Logging()
    {   
        float currentTime = 0f;

        while (currentTime < _logTime)
        {
            currentTime += Time.deltaTime;
            OnLogging?.Invoke(currentTime);
            yield return null;
        }

        DestroyTree();
    }

    public void Dispose()
    {
        OnTreeDestroyed = null;
        IsTargeted = false;
        IsLogging = false;
        IsDestroyed = true;
        _workedBeaver = null;
    }
}
