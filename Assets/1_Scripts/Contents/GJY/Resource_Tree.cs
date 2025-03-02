using UnityEngine;

public class Resource_Tree : MonoBehaviour, IDamagable
{
    // To Do - SO 참조시키고 Status에 정보 전달로 사용하기    
    [SerializeField] Tree_SO _treeSO;
    public Tree_SO TreeSO => _treeSO;

    // Status가 아닌 TreeStatus 등 상속구조로 변경 가능
    public Status Status { get; private set; }

    private GJY_TestBeaver _lastAttackedBeaver;
    private bool _isInit = false;

    public void Init()
    {
        if (_isInit)
            return;

        _isInit = true;
        Status = new Status();
        Status.OnDead += OnTreeDestroyed;
    }

    public void Setup()
        => Status.Setup(_treeSO);

    public void GetDamaged(float damage, GJY_TestBeaver player)
    {
        _lastAttackedBeaver = player;
        Status.GetDamaged(damage);
    }        

    private void OnTreeDestroyed()
    {
        // To Do - 재화 획득 및 게임 오브젝트 비활성화        
        TreeManager.Instance.DestroyTree(this, _lastAttackedBeaver);
        Debug.Log("나무 파괴됨.");
    }
}
