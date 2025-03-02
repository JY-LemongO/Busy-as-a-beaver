using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _spawnTime;

    private const string WOLF_PREFAB_PATH = "Prefabs/Beast/Wolf";

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(Co_Countdown());
    }

    private IEnumerator Co_Countdown()
    {
        yield return new WaitForSeconds(_spawnTime);

        GameObject go = ResourceManager.Instance.Instantiate(WOLF_PREFAB_PATH, transform);

        float randomDistance = Random.Range(0f, _spawnTime);
        Vector3 randomDir = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f)).normalized;
        Vector3 randomVect = randomDir * randomDistance;

        Ray ray = new Ray(randomVect + Vector3.up * 10f, randomVect + Vector3.up * 100f);        
        RaycastHit hit;

        Vector3 spawnPosition = Vector3.zero;

        if (Physics.Raycast(ray, out hit, float.MaxValue, ~0, QueryTriggerInteraction.Collide))
        {
            if (hit.collider != null)
            {
                spawnPosition = hit.point;
            }
        }

        spawnPosition = transform.position;

        go.transform.position = spawnPosition;
    }
}
