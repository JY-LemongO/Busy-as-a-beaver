using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Build_Base : MonoBehaviour
{
    public TMP_Text CostText;

    public BeaverHouse house;

    public void OnClick_BuildBtn()
    {
        if (DataManager.Instance.coin >= 1000)
        {
            house.Build();
        }
    }
}
