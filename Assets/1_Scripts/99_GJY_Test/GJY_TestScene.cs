using TMPro;
using UnityEngine;

public class GJY_TestScene : MonoBehaviour
{    
    [Range(1, 10)]
    [SerializeField] private float _damage;
    [SerializeField] TMP_Text _woodText;
    [SerializeField] Transform _houseTrs1;
    [SerializeField] Transform _houseTrs2;

    private int _currentWood = 0;

    private void Awake()
    {
        TreeManager.Instance.OnWoodValueChanged += OnWoodValueUpdate;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BuildingSystem.Instance.BuildBeaverHouse(_houseTrs1.position);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            BuildingSystem.Instance.BuildBeaverHouse(_houseTrs2.position);
        }
    }

    private void OnWoodValueUpdate(int value)
    {
        _currentWood += value;
        _woodText.text = $"Current Wood : {_currentWood}";
    }
}
