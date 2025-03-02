using System.Collections;

using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _damSpawnPoint;
    [SerializeField] private Transform _water;

    [SerializeField] private float _riseTime;

    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;

    private void Awake()
    {
        DamManager.Instance.OnBuiltDam += OnBuiltDam;
    }

    public void SpawnDam()
        => DamManager.Instance.SpawnDam(_damSpawnPoint);

    private void OnBuiltDam()
    {
        if (gameObject.activeSelf)
            StartCoroutine(Co_RiseWater());
    }

    private IEnumerator Co_RiseWater()
    {
        float current = 0f;
        float percent = 0f;

        while (percent < 1f)
        {
            current += Time.deltaTime;
            percent = current / _riseTime;

            _water.transform.localPosition = Vector3.Lerp(startPos, endPos, percent);
            yield return null;
        }
    }
}
