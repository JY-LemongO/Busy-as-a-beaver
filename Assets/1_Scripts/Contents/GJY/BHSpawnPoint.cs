using UnityEngine;

public enum BHSpawnType
{
    Normal,
    Main,    
}

public class BHSpawnPoint : MonoBehaviour
{
    [SerializeField] private BHSpawnType spawnerType;

    private void Awake()
    {
        BuildingSystem.Instance.RegistBHSpawnPoint(this);
        if(spawnerType == BHSpawnType.Main)
            BuildingSystem.Instance.BuildBeaverHouse(this);
    }
}
