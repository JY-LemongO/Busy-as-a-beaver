using System;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : SingletonBase<TreeManager>
{
    #region Events    
    public event Action<int> OnWoodValueChanged; // Temp Code
    public event Action<Resource_Tree> OnTreeSpawned;
    public event Action<Resource_Tree, Beaver> OnTreeDestroyed;    
    #endregion

    public List<Resource_Tree> TreeList { get; private set; } = new();

    private const string TREE_PREFAB_PATH = "Prefabs/Tree/";
    private const string STUMP_PREFAB_PATH = "Prefabs/Tree/Stump";

    public Resource_Tree GetClosestTree(Transform beaverTrs)
    {
        if (TreeList.Count == 0)
            return null;

        Resource_Tree closestTree = null;
        float closestDistance = float.MaxValue;

        foreach (var tree in TreeList)
        {
            if (tree.IsTargeted)
                continue;

            float distance = (beaverTrs.position - tree.transform.position).sqrMagnitude;
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTree = tree;
            }
        }

        return closestTree;
    }

    public Resource_Tree SpawnTree(string treeKey, Transform spawner)
    {
        string path = TREE_PREFAB_PATH + treeKey;
        Resource_Tree tree = Util.SpawnGameObjectAndSetPosition<Resource_Tree>(path, spawner.position, parent: spawner);

        // 나무 셋업할 때 시간이나 요구시간 설정해야함.
        tree.Setup();
        TreeList.Add(tree);
        OnTreeSpawned?.Invoke(tree);

        return tree;
    }

    public GameObject SpawnStump(Transform spawner)
        => Util.SpawnGameObjectAndSetPosition(STUMP_PREFAB_PATH, spawner.position, parent: spawner);

    public void DestroyTree(Resource_Tree tree, Beaver beaver)
    {
        PoolManager.Instance.Return(tree.gameObject);
        TreeList.Remove(tree);        
        OnTreeDestroyed?.Invoke(tree, beaver);

        GameManager.Instance.SetValue(StatusType.Wood, (int)(5 * (1 + GameManager.Instance.Income)));
    }

    public void DestroyAllTree()
    {
        foreach(Resource_Tree tree in TreeList)
        {
            tree.Dispose();
            PoolManager.Instance.Return(tree.gameObject);
        }            
        TreeList.Clear();
    }

    public int GetTreesCount()
        => TreeList.Count;

    protected override void InitChild()
    {
        StageManager.Instance.OnStageClear += OnStageClear;
    }    

    private void OnStageClear(int notUsed)
    {
        DestroyAllTree();
    }

    public override void Dispose()
    {
        TreeList.Clear();
        base.Dispose();
    }
}
