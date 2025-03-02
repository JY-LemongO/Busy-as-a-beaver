using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : SingletonBase<ResourceManager>
{
    private Dictionary<string, UnityEngine.Object> _resourcesDict = new();

    public T Load<T>(string key) where T : UnityEngine.Object
    {
        if (!_resourcesDict.ContainsKey(key))
            _resourcesDict[key] = Resources.Load(key);

        return _resourcesDict[key] as T;
    }

    /// <summary>
    /// Resources.Load를 사용한 GameObject 생성입니다. pooling = true가 기본값이기 때문에 해당 함수 사용시 자동 Pooling 적용됩니다.
    /// key - Resources 폴더 내 프리팹이 위치한 경로
    /// </summary>    
    public GameObject Instantiate(string key, Transform parent = null, bool isPooling = true)
    {
        GameObject prefab = Load<GameObject>(key);
        if(prefab == null)
        {
            Debug.LogError($"[ResourceManager] {key} 에 해당하는 프리팹이 없습니다.");
            return null;
        }

        GameObject go = null;

        if (isPooling)
        {
            go = PoolManager.Instance.Get(prefab);
            go.transform.SetParent(parent);
            return go;
        }            

        go = UnityEngine.Object.Instantiate(prefab, parent);
        go.name = prefab.name;

        return go;
    }

    protected override void InitChild()
    {

    }

    public override void Dispose()
    {
        _resourcesDict.Clear();
        base.Dispose();
    }
}
