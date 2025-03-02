using System.Collections;
using UnityEngine;

public class BeaverManager : SingletonBase<BeaverManager>
{
    private const string BEAVER_PREFAB_PATH = "Prefabs/Beaver/Beaver_Temp";

    public void SpawnBeaver(Vector3 position, BeaverHouse house)
    {
        GJY_TestBeaver beaver = Util.SpawnGameObjectAndSetPosition<GJY_TestBeaver>(BEAVER_PREFAB_PATH, position + Vector3.forward, parent: house.transform);
        beaver.SetHouse(house);        
    }

    public void DispawnBeaver()
    {
        
    }

    protected override void InitChild()
    {
        
    }
}
