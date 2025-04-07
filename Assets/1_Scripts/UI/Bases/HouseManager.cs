using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HouseManager : SingletonBase<HouseManager>
{
    public List<BeaverHouse> houses = new List<BeaverHouse>();
    public BeaverHouse currentHouse;
    public GameObject houseInfo;

    private void OnEnable()
    {
        //InitializeHouses();
    }

    private void OnDisable()
    {
        UnsubscribeFromHouseClickEvents();
    }

    //private void InitializeHouses()
    //{
    //    houses = FindObjectsOfType<BeaverHouse>().ToList();

    //    Debug.Log($"찾은 BeaverHouse 개수: {houses.Count}");

    //    if (houses.Count > 0)
    //    {
    //        SubscribeToHouseClickEvents();
    //    }
    //    else
    //    {
    //        Debug.LogWarning("BeaverHouse가 없습니다!");
    //    }
    //}

    private void SubscribeToHouseClickEvents()
    {
        foreach (var beaverHouse in houses)
        {
            beaverHouse.OnHouseClick += ChangeCurrentHouse;
        }
    }

    private void UnsubscribeFromHouseClickEvents()
    {
        foreach (var beaverHouse in houses)
        {
            beaverHouse.OnHouseClick -= ChangeCurrentHouse;
        }
    }

    private void ChangeCurrentHouse(BeaverHouse beaverHouse)
    {
        if (beaverHouse == null)
            return;

        currentHouse = beaverHouse;
        houseInfo.GetComponent<SubUI_BeaverHouseInfo>().GetCurrentHouse(beaverHouse);
        houseInfo.GetComponent<SubUI_BeaverHouseInfo>().Click(beaverHouse);

        if (currentHouse == null)
            return;

        if (houseInfo == null)
        {
            Debug.Log("인포가 널");
            return;
        }
    }

    public void AddHouse(BeaverHouse newHouse)
    {
        houses.Add(newHouse);
        newHouse.OnHouseClick += ChangeCurrentHouse;
    }

    protected override void InitChild()
    {

    }
}
