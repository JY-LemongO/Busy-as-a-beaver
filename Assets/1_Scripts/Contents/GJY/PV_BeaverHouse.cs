using UnityEngine;

public class PV_BeaverHouse : MonoBehaviour, ITouchable
{
    public BHSpawnPoint SpawnPoint { get; private set; }

    private void Awake()
    {
        BuildingSystem.Instance.OnExitPreviewMode += OnExitPVMode;
    }

    public void Setup(BHSpawnPoint spawnPoint)
    {
        SpawnPoint = spawnPoint;
    }
    
    private void OnExitPVMode()
    {
        if (gameObject.activeSelf)
            PoolManager.Instance.Return(gameObject);
    }

    public void Interact()
    {
        BuildingSystem.Instance.BuildBeaverHouse(SpawnPoint);
    }
}
