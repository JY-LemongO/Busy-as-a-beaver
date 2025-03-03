using UnityEngine;
using UnityEngine.Events;

public class CanvasCameraFinder : MonoBehaviour
{
    public Canvas cv;
    public string SortingLayerName;
    public static UnityAction SceneChangeEvent;

    private void OnEnable() 
    {
        SceneChange();
        SceneChangeEvent += SceneChange;
    }

    public void SceneChange()
    {
        if(cv == null) 
        {
            Debug.LogError($"Component [canvas] is null");
            return;
        }

        cv.worldCamera = Camera.main;
        cv.worldCamera = GameObject.Find("SubUICamera").GetComponent<Camera>();
        cv.sortingLayerName = string.IsNullOrEmpty(SortingLayerName)? "Default" : SortingLayerName;
    }
}
