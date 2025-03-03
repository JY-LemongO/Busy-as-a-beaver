using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GJY_TestScene : MonoBehaviour
{   
    [SerializeField] BHSpawnPoint _houseTrs1;
    [SerializeField] BHSpawnPoint _houseTrs2;
    [SerializeField] Button _previewBtn;
    [SerializeField] Button _nextStageBtn;
    [SerializeField] GameObject _nextStagePanel;

    private int _currentWood = 0;

    private void Awake()
    {        
        _previewBtn.onClick.AddListener(OnPreviewMode);
        _nextStageBtn.onClick.AddListener(OnNextStage);
        DamManager.Instance.OnBuiltDam += () => GameManager.Instance.OpenPopup(PopupType.Clear);//() => _nextStagePanel.SetActive(true);
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
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(TreeManager.Instance.GetTreesCount());
        }
            
    }

    private void OnPreviewMode()
        => BuildingSystem.Instance.EnterBHPreviewMode();    

    private void OnNextStage()
    {
        _nextStagePanel.SetActive(false);
        StageManager.Instance.StageClear();
    }        
}
