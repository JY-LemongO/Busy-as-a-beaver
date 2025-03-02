using UnityEngine;

public static class Util
{
    public static T SpawnGameObjectAndSetPosition<T>(string path, Vector3 position, Quaternion rotation = default, Transform parent = null) where T : UnityEngine.Object
        => SpawnGameObjectAndSetPosition(path, position, rotation, parent).GetComponent<T>();

    public static GameObject SpawnGameObjectAndSetPosition(string path, Vector3 position, Quaternion rotation = default, Transform parent = null)
    {
        GameObject go = ResourceManager.Instance.Instantiate(path, parent);
        go.transform.position = position;
        go.transform.rotation = rotation;

        return go;
    }

    /// <summary>
    /// y축은 제외하고 수평 방향만 반환
    /// </summary>
    public static Vector3 GetMoveDirection(Transform from, Transform to)
    {
        Vector3 direction = (to.position - from.position).normalized;
        direction.y = 0;
        
        return direction;
    }
}
