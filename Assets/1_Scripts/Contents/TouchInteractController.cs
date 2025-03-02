using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInteractController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, float.MaxValue, ~0, QueryTriggerInteraction.Collide))
            {
                if (hit.collider != null)
                {
                    Debug.Log($"터치된 오브젝트: {hit.collider.gameObject.name}");

                    // 특정 오브젝트만 터치 반응하도록 설정
                    if (hit.collider.TryGetComponent(out ITouchable touchable))
                    {
                        Debug.Log("터쳐블 걸림");
                        touchable.Interact();
                    }
                }
            }
        }
    }
}
