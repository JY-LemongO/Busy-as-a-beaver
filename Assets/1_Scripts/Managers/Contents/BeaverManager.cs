using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaverManager : SingletonBase<BeaverManager>
{
    private const string BEAVER_PREFAB_PATH = "Prefabs/Beaver/Beaver_Temp";

    public void SpawnBeaver(Vector3 position)
    {
        GameObject go = ResourceManager.Instance.Instantiate(BEAVER_PREFAB_PATH);
        go.transform.position = position + Vector3.forward;
    }

    public void DispawnBeaver()
    {
        
    }

    protected override void InitChild()
    {
        
    }
}
