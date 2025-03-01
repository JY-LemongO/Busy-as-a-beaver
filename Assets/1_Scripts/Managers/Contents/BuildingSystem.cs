using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : SingletonBase<BuildingSystem>
{
    

    // BH == BeaverHouse
    private int _buildableBHCount;

    private const string BEAVER_HOUSE_PREFAB_PATH = "Prefabs/Building/BeaverHouse_Temp";

    public void BuildBeaverHouse(Vector3 position)
    {
        GameObject go = ResourceManager.Instance.Instantiate(BEAVER_HOUSE_PREFAB_PATH);
        go.transform.position = position;

        BeaverManager.Instance.SpawnBeaver(position);
    }

    public bool IsBuildable()
    {
        return false;
    }

    public void SetStageBuildableBHCount(int value)
        => _buildableBHCount = value;

    protected override void InitChild()
    {
        
    }
}
