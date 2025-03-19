using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeaverHouse : MonoBehaviour, ITouchable
{
    public event Action ClickHouse;

    public GameObject[] beaver;
    public Image[] beaverImages;

    public HouseData houseData;
    private StatusType statusType;

    private int m_houseLv;
    public int CurrentHouseLv
    {
        get => DataManager.Instance.statusData[statusType].statusValue;
        set
        {
            if (m_houseLv != value)
            {
                m_houseLv = value;
                SetBeaver();
                SetImages();
                StatusManager.Instance.SetDirty();
            }
        }
    }
    public void Interact()
    {
        statusType = Enum.Parse<StatusType>(gameObject.name);
        ClickHouse?.Invoke();
    }

    public void SetBeaver()
    {

        for (int i = 0; i < CurrentHouseLv; i++)
        {
            beaver[i].SetActive(true);
        }
    }

    public void SetImages()
    {

        for (int i = 0; i < CurrentHouseLv; i++)
        {
            beaverImages[i].gameObject.SetActive(true);
        }
    }
}
