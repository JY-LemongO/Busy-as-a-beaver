using System.Collections;
using UnityEngine;

public class GJY_TestBeaver : MonoBehaviour
{
    [SerializeField] private float _needDistance;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _logTrs;

    private BeaverHouse _house;
    private Resource_Tree _targetTree;
    private GameObject _log;
    private bool _isMovingToDam = false;
    private bool _isLogging = false;

    private const string LOG_PREFAB_PATH = "Prefabs/Tree/Log";

    private void Awake()
    {        
        TreeManager.Instance.OnTreeSpawned += OnTreeSpawned;
    }

    private void OnEnable()
    {
        SearchTree();
    }

    public void SetHouse(BeaverHouse house)
        => _house = house;

    private void OnTreeSpawned(Resource_Tree tree)
    {
        if (_targetTree != null || _isMovingToDam)
            return;

        StopAllCoroutines();
        SearchTree();
    }

    private void OnGetLog()
    {
        _targetTree.OnTreeDestroyed -= OnGetLog;

        _log = ResourceManager.Instance.Instantiate(LOG_PREFAB_PATH, _logTrs);
        _log.transform.localPosition = Vector3.zero;
        _log.transform.localRotation = Quaternion.identity;

        _isMovingToDam = true;
        _isLogging = false;

        StartCoroutine(Co_MoveToDam());
    }

    private void SearchTree()
    {
        if (FindTree())
            StartCoroutine(Co_MoveToTree());
        else
        {
            // 자신의 집으로 이동 - 휴식
            StartCoroutine(Co_MoveToHouse());
            Debug.Log($"[GJY_TestBeaver] 집으로 이동");
        }
    }

    private bool FindTree()
    {
        _targetTree = TreeManager.Instance.GetClosestTree(transform);
        if (_targetTree != null)
        {
            _targetTree.SetBeaver(this);
            _targetTree.OnTreeDestroyed += OnGetLog;
            return true;
        }            

        return false;
    }

    private IEnumerator Co_MoveToTree()
    {
        while (Vector3.Distance(transform.position, _targetTree.transform.position) > _needDistance)
        {
            Vector3 dir = Util.GetMoveDirection(transform, _targetTree.transform);            
            transform.position += dir * _moveSpeed * Time.deltaTime;
            yield return null;
        }

        LogTree();
    }

    private void LogTree()
        => _targetTree.LogTree(); 

    private IEnumerator Co_MoveToDam()
    {
        while (Vector3.Distance(transform.position, Dam.Instance.transform.position) > _needDistance)
        {
            Vector3 dir = Util.GetMoveDirection(transform, Dam.Instance.transform);
            transform.position += dir * _moveSpeed * Time.deltaTime;
            yield return null;
        }

        StartCoroutine(Co_BuildDam());
    }

    private IEnumerator Co_BuildDam()
    {
        yield return new WaitForSeconds(2f);
        Dam.Instance.BuildDam();
        PoolManager.Instance.Return(_log);

        _isMovingToDam = false;
        SearchTree();
    }

    private IEnumerator Co_MoveToHouse()
    {
        while (Vector3.Distance(transform.position, _house.transform.position) > _needDistance)
        {
            Vector3 dir = Util.GetMoveDirection(transform, _house.transform);
            transform.position += dir * _moveSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
