using System.Collections.Generic;
using UnityEngine;

public class Dam : MonoBehaviour
{
    [SerializeField] List<GameObject> _damProgressList;
    [SerializeField] private int _needLogCount;
    public GameObject moveToDamPosition;

    public static Dam Instance { get; private set; }

    private int _currentLogCount;    

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        if (Instance != this)
            Destroy(gameObject);

        if (_needLogCount == 0)
            Debug.LogError("[Dam] 필요한 나무 개수가 잘못 설정되어있습니다.");
    }

    public void BuildDam()
    {
        _currentLogCount++;

        int step = Mathf.FloorToInt(5 * (_currentLogCount - 1) / (_needLogCount - 1)) + 1;        
        if (step <= _damProgressList.Count && !_damProgressList[step - 1].activeSelf)
            _damProgressList[step - 1].SetActive(true);

        if (_currentLogCount == _needLogCount)
        {
            // To Do - Stage Clear            
            Debug.Log("Stage Clear!");
        }            
    }
}
