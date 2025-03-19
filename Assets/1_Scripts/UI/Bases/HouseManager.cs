using UnityEngine;

public class HouseManager : MonoBehaviour
{
    public BeaverHouse[] house;
    public BeaverHouse currentHouse;

    public SubUI_BeaverHouseInfo houseInfo;

    private void OnEnable()
    {
        house = FindObjectsOfType<BeaverHouse>();

        if (house.Length > 0)
        {
            Debug.Log($"{house.Length}개의 BeaverHouse 오브젝트가 씬에 있습니다.");

            foreach (var beaverHouse in house)
            {
                beaverHouse.ClickHouse += House_Changed;
            }
        }
        else
        {
            Debug.LogWarning("씬에 BeaverHouse 오브젝트가 없습니다.");
        }
    }

    private void OnDisable()
    {
        foreach (var beaverHouse in house)
        {
            beaverHouse.ClickHouse -= House_Changed;
        }
    }

    private void House_Changed()
    {
        if (currentHouse == null)
        {
            currentHouse = GetClickedHouse();
        }
        if (currentHouse != null)
        {
            Debug.Log($"현재 선택된 BeaverHouse: {currentHouse.gameObject.name}");
            houseInfo.Click();
        }
        else
        {
            Debug.LogError("클릭된 BeaverHouse를 찾을 수 없습니다.");
        }
    }

    private BeaverHouse GetClickedHouse()
    {
        foreach (var beaverHouse in house)
        {
            if (beaverHouse.gameObject.activeInHierarchy)
            {
                return beaverHouse;
            }
        }

        return null;
    }
}
