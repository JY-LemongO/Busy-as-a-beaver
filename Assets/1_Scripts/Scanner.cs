using UnityEngine;

public class Scanner : MonoBehaviour
{
    public Collider[] targets;

    private int targetLayer;

    public Transform Scan(string targetLayerName)
    {
        targetLayer = LayerMask.NameToLayer(targetLayerName); 

        targets = Physics.OverlapSphere(transform.position, int.MaxValue, 1 << targetLayer);

        if (targets.Length == 0)
        {
            Debug.LogWarning("탐지된 타겟이 없습니다.");
            return null;
        }

        return GetNearest().transform;
    }

    Transform GetNearest()
    {
        Transform result = null;
        float diff = Mathf.Infinity;

        foreach (Collider target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;

            float curDiff = Vector3.Distance(myPos, targetPos);

            if (curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }

        if (result == null)
        {
            Debug.LogWarning("가장 가까운 타겟이 없습니다.");
            return null;
        }

        return result;
    }
}

