using System.Linq;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    public BeaverHouse[] houses;
    public BeaverHouse currentHouse;
    public SubUI_BeaverHouseInfo houseInfo;

    private void OnEnable()
    {
        InitializeHouses();
    }

    private void OnDisable()
    {
        UnsubscribeFromHouseClickEvents();
    }

    private void InitializeHouses()
    {
        houses = FindObjectsOfType<BeaverHouse>();
        Debug.Log($"찾은 BeaverHouse 개수: {houses.Length}");

        if (houses.Length > 0)
        {
            SubscribeToHouseClickEvents();
        }
        else
        {
            Debug.LogWarning("BeaverHouse가 없습니다!");
        }
    }

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
        currentHouse = beaverHouse;

        if (currentHouse == null)
            return;

        houseInfo.Click();
    }

    public void AddHouse(BeaverHouse newHouse)
    {
        if (!houses.Contains(newHouse))
        {
            houses = houses.Concat(new[] { newHouse }).ToArray();
            newHouse.OnHouseClick += ChangeCurrentHouse;
        }
    }
}
