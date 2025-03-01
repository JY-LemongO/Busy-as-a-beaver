using System.Collections;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    // Temp
    [SerializeField] private float _respawnTime;

    private Resource_Tree _tree;

    private void Awake()
    {
        SpawnTree();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _tree.GetDamaged(10f);
        }
    }

    private void SpawnTree()
    {
        _tree = TreeManager.Instance.SpawnTree(transform);
        _tree.Status.OnDead += OnTreeRespawnCountdown;
    }

    private void OnTreeRespawnCountdown()
        => StartCoroutine(Co_CountdownRespawn());

    private IEnumerator Co_CountdownRespawn()
    {
        // 리스폰 UI도 있으면 좋다고 생각합니다... 한다면 이벤트 만들께요!
        yield return new WaitForSeconds(_respawnTime);
        SpawnTree();
    }
}
