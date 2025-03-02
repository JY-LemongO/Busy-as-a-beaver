using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaverManager : SingletonBase<BeaverManager>
{
    private const string BEAVER_PREFAB_PATH = "Prefabs/Beaver/Beaver";
    private const string BEAVERTEST_PREFAB_PATH = "Prefabs/Beaver/Beaver_Test";

    private List<Beaver> _beaversList = new();

    public void SpawnBeaver(Vector3 position, BeaverHouse house)
    {
        GJY_TestBeaver beaver = Util.SpawnGameObjectAndSetPosition<GJY_TestBeaver>(BEAVERTEST_PREFAB_PATH, position + Vector3.forward, parent: house.transform);
        beaver.SetHouse(house);
        _beaversList.Add(beaver);
    }

    public void DispawnBeaver(Beaver beaver)
        => PoolManager.Instance.Return(beaver.gameObject);    

    protected override void InitChild()
    {
        StageManager.Instance.OnStageClear += OnStageClear;
    }

    private void OnStageClear(int notUsed)
    {
        foreach(var beaver in _beaversList)
        {
            beaver.Dispose();
            DispawnBeaver(beaver);
        }
        _beaversList.Clear();
    }
}
