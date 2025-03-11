using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public Collider[] targets;

    private int targetLayer;

    public void SetLayer(string targetLayerName)
    {
        targetLayer = LayerMask.NameToLayer(targetLayerName);

        if (targetLayer == -1)
        {
            Debug.LogError("타겟 레이어를 찾을 수 없습니다: " + targetLayerName);
        }
    }

    public Vector3 Scan()
    {
        targets = Physics.OverlapSphere(transform.position, scanRange, 1 << targetLayer);

        if (targets.Length == 0)
        {
            Debug.LogWarning("탐지된 타겟이 없습니다.");
            return Vector3.zero;
        }

        return GetNearest().transform.position;
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
