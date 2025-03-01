using UnityEngine;

public class BHSpawnPoint : MonoBehaviour
{
    private void Awake()
    {
        BuildingSystem.Instance.RegistBHSpawnPoint(this);
    }
}
