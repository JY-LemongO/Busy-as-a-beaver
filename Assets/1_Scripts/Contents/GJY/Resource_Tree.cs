using System;
using System.Collections;
using UnityEngine;

public class Resource_Tree : MonoBehaviour
{
    [SerializeField] private float _logTime;

    public event Action OnTreeDestroyed;
    public event Action<float> OnLogging;

    public bool IsDestroyed { get; private set; }
    public bool IsTargeted {  get; private set; }

    private GJY_TestBeaver _workedBeaver;

    public void Setup()
    {
        IsDestroyed = false;
    }

    public void SetBeaver(GJY_TestBeaver player)
    {
        IsTargeted = true;
        _workedBeaver = player;
    } 

    public void LogTree()
    {
        // To Do - Logging        
        StartCoroutine(Co_Logging());
    }    

    private void DestroyTree()
    {        
        TreeManager.Instance.DestroyTree(this, _workedBeaver);
        OnTreeDestroyed?.Invoke();
        OnTreeDestroyed = null;
        IsTargeted = false;
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
}
