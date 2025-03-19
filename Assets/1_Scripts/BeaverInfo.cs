using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeaverInfo : MonoBehaviour
{
    public Image[] beaver;
    public int beavers;

    private void OnEnable()
    {
        for (int i = beavers; i < beaver.Length; i++)
        {
            beaver[i].gameObject.SetActive(false);
        }
    }
}
