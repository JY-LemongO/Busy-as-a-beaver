using TMPro;
using UnityEngine;

public class GJY_TestScene : MonoBehaviour
{    
    [Range(1, 10)]
    [SerializeField] private float _damage;
    [SerializeField] TMP_Text _woodText;

    private int _currentWood = 0;

    private void Awake()
    {
        TreeManager.Instance.OnWoodValueChanged += OnWoodValueUpdate;
    }

    private void OnWoodValueUpdate(int value)
    {
        _currentWood += value;
        _woodText.text = $"Current Wood : {_currentWood}";
    }
}
