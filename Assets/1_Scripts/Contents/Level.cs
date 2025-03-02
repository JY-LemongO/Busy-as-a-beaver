using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _damSpawnPoint;

    public void SpawnDam()
        => DamManager.Instance.SpawnDam(_damSpawnPoint);
}
