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
        Dam.SetupDam(1); // 임시
        Dam.transform.position = spawnPoint.position;
        Dam.transform.rotation = spawnPoint.rotation;
    }

    //Temp
    public void SetDam(Dam dam)
        => Dam = dam;

    public void BuildDamComplete()
    {
        GameManager.Instance.OpenPopup(PopupType.Clear);
        // To Do - 스테이지 클리어 UI 띄우기
        Debug.Log("댐 완성");
        OnBuiltDam?.Invoke();
    }

    private void OnStageClear(int notUsed)
    {
        Dam.ResetDam();
    }

    protected override void InitChild()
    {
        StageManager.Instance.OnStageClear += OnStageClear;
    }
}
