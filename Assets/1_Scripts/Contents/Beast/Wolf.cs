using UnityEngine;

public class Wolf : MonoBehaviour, ITouchable
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _nextBehaveTime;

    private Animator _anim;
    private Collider _coll;
    private Rigidbody _rigid;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        StartRandomBehaveRoutine();
    }

    private void StartRandomBehaveRoutine()
    {

    }

    private void Howl()
    {

    }

    

    public void Interact()
    {
        _anim.SetTrigger("Die");
    }

    private void OnDisable()
    {
        Dispose();
    }

    public void Dispose()
    {

    }
}
