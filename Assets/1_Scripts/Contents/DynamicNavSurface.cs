using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class DynamicNavSurface : MonoBehaviour
{
    public NavMeshSurface _navSurface;

    private void OnEnable()
    {
        Bake();
    }

    private void Bake()
    {
        _navSurface.BuildNavMesh();
    }
}
