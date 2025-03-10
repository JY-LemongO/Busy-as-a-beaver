using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : SingletonBase<BuildingSystem>
{
    #region Events
    public event Action<BeaverHouse> OnBeaverHouseBuilt;
    public event Action<BeaverHouse> OnBeaverHouseDestroyed;
    public event Action OnExitPreviewMode;
    #endregion

    private Dictionary<BHSpawnPoint, BeaverHouse> _beaverHouseDict = new();
    public bool IsPVMode { get; private set; } = false;

    private int _buildableBHCount;
    private int _currentBHCount;

    private const string BEAVER_HOUSE_PREFAB_PATH = "Prefabs/Building/BeaverHouse";
    private const string PV_BEAVER_HOUSE_PREFAB_PATH = "Prefabs/Building/PV_BeaverHouse";    

    public void BuildBeaverHouse(BHSpawnPoint spawnPoint)
    {
        if (_beaverHouseDict.ContainsKey(spawnPoint) && _beaverHouseDict[spawnPoint] != null)
        {
            Debug.LogError($"[BuildingSystem] 현재 스폰포인트에 이미 비버집이 건설 되어 있습니다.");
            return;
        }
        Vector3 spawnPosition = spawnPoint.transform.position;
        BeaverHouse beaverHouse = Util.SpawnGameObjectAndSetPosition<BeaverHouse>(BEAVER_HOUSE_PREFAB_PATH, spawnPosition, parent: spawnPoint.transform);

        _beaverHouseDict[spawnPoint] = beaverHouse;
        _currentBHCount++;

        BeaverManager.Instance.SpawnBeaver(spawnPosition, beaverHouse);
        OnBeaverHouseBuilt?.Invoke(beaverHouse);

        ExitPreviewBH();
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

    public void EnterBHPreviewMode()
    {
        if (IsPVMode)
            return;

        IsPVMode = true;
        foreach (var spawnPoint in _beaverHouseDict.Keys)
        {
            if (_beaverHouseDict[spawnPoint] != null)
                continue;

            PV_BeaverHouse pvBeaverHouse = Util.SpawnGameObjectAndSetPosition<PV_BeaverHouse>(PV_BEAVER_HOUSE_PREFAB_PATH, spawnPoint.transform.position);
            pvBeaverHouse.Setup(spawnPoint);
        }
    }

    public void ExitPreviewBH()
    {
        IsPVMode = false;
        OnExitPreviewMode?.Invoke();
    }

    public void RegistBHSpawnPoint(BHSpawnPoint spawnPoint)
        => _beaverHouseDict.Add(spawnPoint, null);

    public bool IsBuildable()
    {
        if (_buildableBHCount == _currentBHCount)
            return false;

        // 재화가 부족해도 false

        return true;
    }

    public void SetStageBuildableBHCount(int value)
        => _buildableBHCount = value;

    protected override void InitChild()
    {

    }

    public override void Dispose()
    {
        OnBeaverHouseBuilt = null;
        OnBeaverHouseDestroyed = null;
        OnExitPreviewMode = null;
        _beaverHouseDict.Clear();
        base.Dispose();
    }
}
