using UnityEditor;
using UnityEngine;

// SingletonBase를 상속받은 클래스들은(주로 매니저급) 
public abstract class SingletonBase<T> : MonoBehaviour where T : SingletonBase<T>
{
    private static T _instance;
    private static bool _isInitialized = false;

    // 자식 클래스에서 설정 및 DontDestroy 설정
    protected bool _isDontDestroy = true;

    public static T Instance { get { if (!_isInitialized) Init(); return _instance; } }

    private static void Init()
    {
        _isInitialized = true;
        GameObject go = GameObject.Find($"@{typeof(T).Name}");
        if (go == null)
            go = new GameObject($"@{typeof(T).Name}", typeof(T));

        _instance = go.GetComponent<T>();
        _instance.InitChild();

        if (_instance._isDontDestroy)
            DontDestroyOnLoad(go);

#if UNITY_EDITOR
        EditorApplication.playModeStateChanged += state =>
        {
            if (state == PlayModeStateChange.ExitingPlayMode)
                _instance.Dispose();
        };
#endif
    }

    // 자식 클래스(매니저)에서 필요한 내용들이 들어갈 추상함수
    protected abstract void InitChild();

    public virtual void Dispose()
    {
        _isInitialized = false;
    }
}
