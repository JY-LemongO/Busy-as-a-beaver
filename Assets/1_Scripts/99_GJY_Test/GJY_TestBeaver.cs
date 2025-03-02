using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJY_TestBeaver : MonoBehaviour
{
    [SerializeField] private float _needDistance;
    [SerializeField] private float _moveSpeed;

    private Resource_Tree _targetTree;
    private bool _isMovingToDam = false;

    private void Awake()
    {
        //TreeManager.Instance.OnTreeDestroyed += OnTryGetLog;
    }

    private void OnEnable()
    {
        SearchTree();
    }

    private void OnTryGetLog(Resource_Tree destroyedTree, GJY_TestBeaver beaver)
    {
        if (_isMovingToDam)
            return;

        if (beaver != this)
        {
            StopAllCoroutines();
            SearchTree();
        }
    }

    private void SearchTree()
    {
        if (FindTree())
            StartCoroutine(Co_MoveToTree());
    }

    private bool FindTree()
    {
        _targetTree = TreeManager.Instance.GetClosestTree(transform);
        if (_targetTree != null)
            return true;

        return false;
    }

    private IEnumerator Co_MoveToTree()
    {
        while (Vector3.Distance(transform.position, _targetTree.transform.position) > _needDistance)
        {
            Vector3 dir = (_targetTree.transform.position - transform.position).normalized;
            dir.y = 0;
            transform.position += dir * _moveSpeed * Time.deltaTime;
            yield return null;
        }

        StartCoroutine(Co_LogTree());
    }

    private IEnumerator Co_LogTree()
    {
        while (_targetTree.Status.IsAlive)
        {
            //_targetTree.GetDamaged(5f, this);
            yield return new WaitForSeconds(1f);
        }

        _isMovingToDam = true;
        StartCoroutine(Co_MoveToDam());
    }

    private IEnumerator Co_MoveToDam()
    {
        while (Vector3.Distance(transform.position, Dam.Instance.transform.position) > _needDistance)
        {
            Vector3 dir = (Dam.Instance.transform.position - transform.position).normalized;
            dir.y = 0;
            transform.position += dir * _moveSpeed * Time.deltaTime;
            yield return null;
        }

        StartCoroutine(Co_BuildDam());
    }

    private IEnumerator Co_BuildDam()
    {
        yield return new WaitForSeconds(2f);
        Dam.Instance.BuildDam();

        _isMovingToDam = false;
        if (FindTree())
            StartCoroutine(Co_MoveToTree());
    }
}
