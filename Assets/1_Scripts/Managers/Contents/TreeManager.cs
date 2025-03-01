using System;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : SingletonBase<TreeManager>
{
    #region Events
    public event Action<int> OnWoodValueChanged;
    #endregion

    public List<Resource_Tree> TreeList { get; private set; } = new();

    #region TempCode
    private const string TREE_PREFAB_PATH = "Prefabs/Tree/Tree_Temp";
    #endregion

    public Resource_Tree SpawnTree(Transform spawnPoint)
    {
        GameObject treeObj = Resources.Load<GameObject>(TREE_PREFAB_PATH);
        Resource_Tree newTree = Instantiate(treeObj, spawnPoint).GetComponent<Resource_Tree>();
        newTree.Init();
        TreeList.Add(newTree);

        newTree.transform.position = spawnPoint.position;
        return newTree;
    }

    public void DestroyTree(Resource_Tree tree)
    {
        TreeList.Remove(tree);
        OnWoodValueChanged?.Invoke(tree.TreeSO.wood);
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
