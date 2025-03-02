using System.Collections;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [Header("씬에 꺼내놓고 스폰할 나무 프리팹 이름 기입")]
    [SerializeField] private string _treeKey;
    [SerializeField] private float _respawnTime;

    private Resource_Tree _tree;
    private GameObject _stump;

    private void Awake()
    {
        SpawnTree();
    }

    private void SpawnTree()
    {
        if (_stump != null)
            PoolManager.Instance.Return(_stump);

        _tree = TreeManager.Instance.SpawnTree(_treeKey, transform);
        _tree.OnTreeDestroyed += OnTreeRespawnCountdown;
    }

    private void OnTreeRespawnCountdown()
    {
        _tree.OnTreeDestroyed -= OnTreeRespawnCountdown;
        _stump = TreeManager.Instance.SpawnStump(transform);
        StartCoroutine(Co_CountdownRespawn());
    }

    private IEnumerator Co_CountdownRespawn()
    {
        // 리스폰 UI도 있으면 좋다고 생각합니다... 한다면 이벤트 만들께요!
        yield return new WaitForSeconds(_respawnTime);
        SpawnTree();
    }
}
