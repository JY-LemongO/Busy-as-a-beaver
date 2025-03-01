using UnityEngine;

[CreateAssetMenu(menuName = "InGameResource/Tree", fileName = "Tree_")]
public class Tree_SO : ScriptableObject
{
    public string displayName;
    public string displayDesc;

    public float hp;
    [Range(1, 10)]
    public int wood;
}
