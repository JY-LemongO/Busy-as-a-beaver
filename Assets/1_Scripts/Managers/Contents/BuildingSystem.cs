using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : SingletonBase<BuildingSystem>
{
    #region Events
    public event Action<BeaverHouse> OnBeaverHouseBuilt;
    public event Action<BeaverHouse> OnBeaverHouseDestroyed;
    public event Action<bool> OnPVChanged;
    public event Action OnExitPreviewMode;
    #endregion

    private Dictionary<BHSpawnPoint, BeaverHouse> _beaverHouseDict = new();
    public bool IsPVMode { get; private set; } = false;

    StatusType statusType;

    private int _buildableBHCount;
    private int _currentBHCount;

    private const string BEAVER_HOUSE_PREFAB_PATH = "Prefabs/Building/House";
    private const string PV_BEAVER_HOUSE_PREFAB_PATH = "Prefabs/Building/PV_BeaverHouse";

    //public void Build(BHSpawnPoint spawnPoint)
    //{
    //    BeaverHouse beaverHouse = HouseManager.Instance.currentHouse;
    //    beaverHouse.InitData();
    //    beaverHouse.gameObject.SetActive(true);
    //    HouseManager.Instance.AddHouse(beaverHouse);
    //}

    private bool _isPV;

    public bool isPV
    {
        get => _isPV;
        set
        {
            if (_isPV != value)
            {
                _isPV = value;
                OnPVChanged?.Invoke(_isPV);
            }
        }
    }
    public void EnterBHPreviewMode()
    {
        isPV = !isPV;
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
