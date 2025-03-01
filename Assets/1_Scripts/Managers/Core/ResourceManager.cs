using System.Collections;
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

    public GameObject Instantiate(string key, Transform parent = null, bool isPooling = true)
    {
        GameObject prefab = Load<GameObject>(key);
        if(prefab == null)
        {
            Debug.LogError($"[ResourceManager] {key} 에 해당하는 프리팹이 없습니다.");
            return null;
        }
        // To Do - Pooling

        GameObject go = UnityEngine.Object.Instantiate(prefab, parent);
        go.name = prefab.name;

        return go;
    }

    protected override void InitChild()
    {

    }
}
