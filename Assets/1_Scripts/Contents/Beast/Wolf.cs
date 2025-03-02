using System.Collections;
using UnityEngine;

public class Wolf : MonoBehaviour, ITouchable
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _moveTime;
    [SerializeField] private float _nextBehaveTime;
    [Range(0f, 1f)]
    [SerializeField] private float _howlPercentage;

    private Animator _anim;    
    private Rigidbody _rigid;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        StartRandomBehaveRoutine();
    }

    private void StartRandomBehaveRoutine()
    {
        float randomValue = Random.Range(0f, 1f);
        bool move = randomValue > _howlPercentage;
        if (move)
        {
            StartCoroutine(Co_Move());
        }
        else
        {
            Howl();
        }
    }

    private void Howl()
    {
        _anim.SetTrigger("Howl");
        Invoke("StartRandomBehaveRoutine", _nextBehaveTime);
    }    

    public void Interact()
    {
        StopAllCoroutines();
        _anim.SetTrigger("Die");
    }

    private IEnumerator Co_Move()
    {
        float randomX = Random.Range(0f, 1f);
        float randomZ = Random.Range(0f, 1f);

        Vector3 moveDir = new Vector3(randomX, 0f, randomZ).normalized;
        transform.rotation = Quaternion.LookRotation(moveDir);
        _anim.SetFloat("Move", _moveSpeed);
        Vector3 moveVect = moveDir * _moveSpeed;
        float current = 0;
        while(current < _moveTime)
        {
            _rigid.velocity = new Vector3(moveVect.x, _rigid.velocity.y, moveVect.z);
            current += Time.deltaTime;
            yield return null;
        }

        _rigid.velocity = Vector3.zero;
        _anim.SetFloat("Move", 0f);

        yield return new WaitForSeconds(_nextBehaveTime);
        StartRandomBehaveRoutine();
    }

    private void OnDisable()
    {
        Dispose();
    }

    public void Dispose()
    {

    }
}
