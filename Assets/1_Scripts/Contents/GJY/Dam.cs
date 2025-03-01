using UnityEngine;

public class Dam : MonoBehaviour
{
    [SerializeField] private int _needLogCount;

    public static Dam Instance { get; private set; }

    private int _currentLogCount;    

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        if (Instance != this)
            Destroy(gameObject);
    }

    public void BuildDam()
    {
        _currentLogCount++;
        if (_currentLogCount == _needLogCount)
        {
            // To Do - Stage Clear            
            Debug.Log("Stage Clear!");
        }            
    }
}
