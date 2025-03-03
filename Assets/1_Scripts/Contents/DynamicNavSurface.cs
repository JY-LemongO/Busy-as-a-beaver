using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class DynamicNavSurface : MonoBehaviour
{
    [SerializeField] List<GameObject> _dontBakeObjs;

    public NavMeshSurface _navSurface;

    private void OnEnable()
    {
        foreach(GameObject obj in _dontBakeObjs)
            obj.SetActive(false);
        Bake();
        foreach (GameObject obj in _dontBakeObjs)
            obj.SetActive(true);
    }

    private void Bake()
    {
        _navSurface.BuildNavMesh();

    }
}
