using System;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : SingletonBase<TreeManager>
{
    #region Events    
    public event Action<int> OnWoodValueChanged; // Temp Code
    public event Action<Resource_Tree> OnTreeSpawned;
    public event Action<Resource_Tree, GJY_TestBeaver> OnTreeDestroyed;
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

        foreach(var tree in TreeList)
        {
            float distance = (beaverTrs.position - tree.transform.position).sqrMagnitude;
            if(distance < closestDistance)
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

        tree.Init();
        tree.Setup();
        TreeList.Add(tree);
        OnTreeSpawned?.Invoke(tree);

        return tree;
    }

    public GameObject SpawnStump(Transform spawner)
        => Util.SpawnGameObjectAndSetPosition(STUMP_PREFAB_PATH, spawner.position, parent: spawner);

    public void DestroyTree(Resource_Tree tree, GJY_TestBeaver beaver)
    {
        PoolManager.Instance.Return(tree.gameObject);
        TreeList.Remove(tree);
        OnWoodValueChanged?.Invoke(tree.TreeSO.wood);
        OnTreeDestroyed?.Invoke(tree, player);
        Debug.Log($"목재 획득:: +{tree.TreeSO.wood}");
    }        

    protected override void InitChild()
    {
        // 아직 초기화 할 것들이 안 보임.
    }

    public override void Dispose()
    {
        TreeList.Clear();
        base.Dispose();        
    }
}
