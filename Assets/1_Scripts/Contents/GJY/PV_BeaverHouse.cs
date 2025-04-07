using UnityEngine;

public class PV_BeaverHouse : MonoBehaviour, ITouchable
{
    public BHSpawnPoint SpawnPoint { get; private set; }
    public Canvas popupUI;

    private void Awake()
    {
        BuildingSystem.Instance.OnExitPreviewMode += OnExitPVMode;
    }

    private void OnEnable()
    {
        popupUI.gameObject.SetActive(false);
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
        popupUI.gameObject.SetActive(true);
    }
}
