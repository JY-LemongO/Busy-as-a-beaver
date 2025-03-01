using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GJY_TestScene : MonoBehaviour
{    
    [Range(1, 10)]
    [SerializeField] private float _damage;
    [SerializeField] TMP_Text _logText;
    [SerializeField] BHSpawnPoint _houseTrs1;
    [SerializeField] BHSpawnPoint _houseTrs2;
    [SerializeField] Button _previewBtn;

    private int _currentWood = 0;

    private void Awake()
    {
        TreeManager.Instance.OnWoodValueChanged += OnWoodValueUpdate;
        _previewBtn.onClick.AddListener(OnPreviewMode);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BuildingSystem.Instance.BuildBeaverHouse(_houseTrs1);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            BuildingSystem.Instance.BuildBeaverHouse(_houseTrs2);
        }
    }

    private void OnWoodValueUpdate(int value)
    {
        _currentWood += value;
        _logText.text = $"Current Log : {_currentWood}";
    }

    private void OnPreviewMode()
        => BuildingSystem.Instance.EnterPreviewBH();    
}
