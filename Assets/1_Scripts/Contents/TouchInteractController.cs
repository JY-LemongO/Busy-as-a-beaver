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
                    if (hit.collider.TryGetComponent(out ITouchable touchable))
                    {
                        touchable.Interact();
                    }
                }
            }
        }
    }
}
