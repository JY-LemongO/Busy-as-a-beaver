using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : SingletonBase<BuildingSystem>
{
    private const string BEAVER_HOUSE_PREFAB_PATH = "Prefabs/Building/BeaverHouse_Temp";

    public void BuildBeaverHouse(Vector3 position)
    {
        GameObject go = ResourceManager.Instance.Instantiate(BEAVER_HOUSE_PREFAB_PATH);
        go.transform.position = position;

        BeaverManager.Instance.SpawnBeaver(position);
    }

    protected override void InitChild()
    {
        
    }
}
