using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : SingletonBase<BuildingSystem>
{
    #region Events
    public event Action<BeaverHouse> OnBeaverHouseBuilt;
    public event Action<BeaverHouse> OnBeaverHouseDestroyed;
    #endregion

    private Dictionary<BHSpawnPoint, BeaverHouse> _beaverHouseDict = new();

    // BH == BeaverHouse
    private int _buildableBHCount;
    private int _currentBHCount;

    private const string BEAVER_HOUSE_PREFAB_PATH = "Prefabs/Building/BeaverHouse_Temp";
    private const string PV_BEAVER_HOUSE_PREFAB_PATH = "Prefabs/Building/PV_BeaverHouse_Temp";

    public void BuildBeaverHouse(BHSpawnPoint spawnPoint)
    {
        if (_beaverHouseDict.ContainsKey(spawnPoint) && _beaverHouseDict[spawnPoint] != null)
        {
            Debug.LogError($"[BuildingSystem] 현재 스폰포인트에 이미 비버집이 건설 되어 있습니다.");
            return;
        }
        Vector3 spawnPosition = spawnPoint.transform.position;
        GameObject go = ResourceManager.Instance.Instantiate(BEAVER_HOUSE_PREFAB_PATH);
        go.transform.position = spawnPosition;

        BeaverHouse beaverHouse = go.GetComponent<BeaverHouse>();
        _beaverHouseDict[spawnPoint] = beaverHouse;
        _currentBHCount++;

        BeaverManager.Instance.SpawnBeaver(spawnPosition);
        OnBeaverHouseBuilt?.Invoke(beaverHouse);
    }

    public void DestroyBeaverHouse(BHSpawnPoint spawnPoint)
    {
        if (!_beaverHouseDict.ContainsKey(spawnPoint) || _beaverHouseDict[spawnPoint] == null)
        {
            Debug.LogError($"[BuildingSystem] 현재 스폰포인트에 비버집이 건설 되어있지 않습니다.");
            return;
        }
        PoolManager.Instance.Return(_beaverHouseDict[spawnPoint].gameObject);
        OnBeaverHouseDestroyed?.Invoke(_beaverHouseDict[spawnPoint]);
        _beaverHouseDict[spawnPoint] = null;

        _currentBHCount--;        
    }

    public void EnterPreviewBH()
    {
        foreach (var spawnPoint in _beaverHouseDict.Keys)
        {
            if (_beaverHouseDict[spawnPoint] != null)
                continue;

            GameObject go = ResourceManager.Instance.Instantiate(PV_BEAVER_HOUSE_PREFAB_PATH);
            go.transform.position = spawnPoint.transform.position;
        }
    }

    public void ExitPreviewBH()
    {

    }

    public void RegistBHSpawnPoint(BHSpawnPoint spawnPoint)
        => _beaverHouseDict.Add(spawnPoint, null);

    public bool IsBuildable()
    {
        if (_buildableBHCount == _currentBHCount)
            return false;

        return true;
    }

    public void SetStageBuildableBHCount(int value)
        => _buildableBHCount = value;

    protected override void InitChild()
    {

    }

    public override void Dispose()
    {
        _beaverHouseDict.Clear();
        base.Dispose();
    }
}
