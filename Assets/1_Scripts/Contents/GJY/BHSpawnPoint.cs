using System;
using UnityEngine;

public enum BHSpawnType
{
    Main = 1,
    Sub1,
    Sub2,
    Sub3,
}

public class BHSpawnPoint : MonoBehaviour
{
    public BHSpawnType spawnerType;

    private void Awake()
    {
        //BuildingSystem.Instance.RegistBHSpawnPoint(this);
        //if (DataManager.Instance.statusData[(StatusType)(400 + (int)spawnerType)].statusValue > 0)
        //{
        //    BuildingSystem.Instance.Build(this);
        //}
    }
}
