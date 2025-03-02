using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Centering")]
    [Header("화면 중앙으로 자동 돌아가기")]
    [SerializeField] private bool _isReturnCenter;
    [SerializeField] private bool _forcedReturn;
    [SerializeField] private AnimationCurve _curve;
    [Header("오토 센터링 대기시간")]
    [Range(0f, 10f)]
    [SerializeField] private float _returnCountdown;
    [Header("센터링 소요시간")]
    [Range(0f, 10f)]
    [SerializeField] private float _returnTime;

    [Header("화면 경계")]
    [SerializeField] private Vector2 _borderHorizon;
    [SerializeField] private Vector2 _borderVertical;

    [Header("Option")]
    [Header("화면 제어 감도")]
    [Range(0f, 10f)]
    [SerializeField] private float _sensitivity;    
    
    private Coroutine _coroutine;

    private Vector3 _centerPosition;
    private Vector3 _prevMousePosition;
    private Vector3 _swipeDir;
    private float swipeDelta;
    private bool _isControlling = false;

    private void Awake()
    {
        SetCenter(transform.position);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isControlling = true;
            _prevMousePosition = Input.mousePosition;            
        }
        else if (Input.GetMouseButton(0))
        {
            _swipeDir = (Input.mousePosition - _prevMousePosition).normalized;
            swipeDelta = Vector3.Distance(Input.mousePosition, _prevMousePosition);
            _prevMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isControlling = false;
            MoveToCenter();
        }
    }

    private void LateUpdate()
    {
        if (_isControlling)
            MoveCamera();
    }    

    public void SetCenter(Vector3 center)
        => _centerPosition = center;

    public void SetBorder(Vector2 borderHorizon, Vector2 borderVertical)
    {
        _borderHorizon = borderHorizon;
        _borderVertical = borderVertical;
    }        

    private void MoveCamera()
    {        
        float moveX = -_swipeDir.x * _sensitivity;
        float moveY = -_swipeDir.y * _sensitivity;

        Vector3 moveVect = new Vector3(moveX, 0, moveY) + transform.position;
        Debug.Log(swipeDelta);

        Vector3 nextPosition = Vector3.Lerp(transform.position, moveVect, swipeDelta * Time.deltaTime);
        nextPosition.x = Mathf.Clamp(nextPosition.x, _borderHorizon.x, _borderHorizon.y);
        nextPosition.z = Mathf.Clamp(nextPosition.z, _borderVertical.x, _borderVertical.y);

        transform.position = nextPosition;
    }

    private void MoveToCenter()
    {
        if (_isReturnCenter)
        {
            if (!_forcedReturn)
                DoAutoReturn();
            else
                DoForcedCentering();
        }            
    }

    private void DoForcedCentering()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(Co_Centering());
    }

    private void DoAutoReturn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(Co_Countdown());
    }

    private IEnumerator Co_Countdown()
    {
        yield return new WaitForSeconds(_returnCountdown);
        _coroutine = StartCoroutine(Co_Centering());
    }

    private IEnumerator Co_Centering()
    {
        float current = 0f;
        float percent = 0f;
        Vector3 startPosition = transform.position;

        while (percent < 1)
        {
            if (_isControlling)
                break;

            current += Time.deltaTime;
            percent = current / _returnTime;

            transform.position = Vector3.Lerp(startPosition, _centerPosition, _curve.Evaluate(percent));
            yield return null;
        }

        _coroutine = null;
    }
}
