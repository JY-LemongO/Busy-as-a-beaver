using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

#region Pool
public class Pool
{
    public GameObject OriginPrefab { get; private set; }

    private IObjectPool<GameObject> _pool;

    public Pool(GameObject originPrefab)
    {
        OriginPrefab = originPrefab;
        _pool = new ObjectPool<GameObject>(OnCreate, OnGet, OnRelease);
    }

    public GameObject Pop()
        => _pool.Get();

    public void Push(GameObject go)
        => _pool.Release(go);

    public void Dispose()
        => _pool.Clear();    

    #region PoolArgs
    private GameObject OnCreate()
    {
        GameObject go = UnityEngine.Object.Instantiate(OriginPrefab);
        go.name = OriginPrefab.name;
        return go;
    }

    private void OnGet(GameObject go)
        => go.SetActive(true);    

    private void OnRelease(GameObject go)
        => go.SetActive(false);
    #endregion
}
#endregion

public class PoolManager : SingletonBase<PoolManager>
{
    private Dictionary<string, Pool> _poolDict = new();

    public GameObject Get(GameObject prefab)
    {
        if (!_poolDict.ContainsKey(prefab.name))
            CreatePool(prefab);

        return _poolDict[prefab.name].Pop();
    }

    public void Return(GameObject go)
    {
        if (!_poolDict.ContainsKey(go.name))
        {
            Debug.LogError($"[PoolManager] Key - {go.name} 가 존재하지 않습니다.");
            return;
        }

        _poolDict[go.name].Push(go);
    }

    private void CreatePool(GameObject prefab)
        => _poolDict.Add(prefab.name, new(prefab));

    protected override void InitChild()
    {
        
    }

    public override void Dispose()
    {
        foreach (var pool in _poolDict.Values)
            pool.Dispose();
        _poolDict.Clear();
        base.Dispose();
    }
}
