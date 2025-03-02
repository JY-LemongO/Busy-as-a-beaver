using System;
using UnityEngine;

public class DamManager : SingletonBase<DamManager>
{
    public event Action OnBuiltDam;

    public Dam Dam { get; private set; }

    private const string DAM_PREFAB_PATH = "Prefabs/Building/Dam";

    public void SpawnDam(Transform spawnPoint)
    {
        GameObject go = ResourceManager.Instance.Instantiate(DAM_PREFAB_PATH);
        Dam = go.GetComponent<Dam>();
        Dam.transform.position = spawnPoint.position;
        Dam.transform.rotation = spawnPoint.rotation;
    }

    public void BuildDamComplete()
    {
        // To Do - 스테이지 클리어 UI 띄우기
        OnBuiltDam?.Invoke();
    }

    protected override void InitChild()
    {

    }
}
