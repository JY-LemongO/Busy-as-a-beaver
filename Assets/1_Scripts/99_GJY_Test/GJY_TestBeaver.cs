using System.Collections;
using UnityEngine;

public class GJY_TestBeaver : Beaver
{
    [SerializeField] private float _needDistance;
    [SerializeField] private float _moveSpeed => GameManager.Instance.fixMoveSpeed;
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

    public override void SetHouse(BeaverHouse house)
        => _house = house;

    private void OnTreeSpawned(Resource_Tree tree)
    {
        if (_targetTree != null || _isMovingToDam || !gameObject.activeSelf)
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
            _targetTree.SetBeaver(this as Beaver);
            _targetTree.OnTreeDestroyed += OnGetLog;
            return true;
        }            

        return false;
    }

    private IEnumerator Co_MoveToTree()
    {   
        Debug.Log($"beaver speed : {GameManager.Instance.fixMoveSpeed}");
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
        Dam dam = DamManager.Instance.Dam;

        while (Vector3.Distance(transform.position, dam.transform.position) > _needDistance)
        {
            Vector3 dir = Util.GetMoveDirection(transform, dam.transform);
            transform.position += dir * _moveSpeed * Time.deltaTime;
            yield return null;
        }

        StartCoroutine(Co_BuildDam());
    }

    private IEnumerator Co_BuildDam()
    {
        yield return new WaitForSeconds(2f);
        DamManager.Instance.Dam.BuildDam();
        PoolManager.Instance.Return(_log);
        _log = null;

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

    public override void Dispose()
    {
        if (_log != null)
            PoolManager.Instance.Return(_log);

        StopAllCoroutines();

        _house = null;
        _targetTree = null;
        _log = null;
        _isMovingToDam = false;
        _isLogging = false;
    }
}
