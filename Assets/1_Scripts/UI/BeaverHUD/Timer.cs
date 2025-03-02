using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image timerImg;
    public Transform obj;
    public RectTransform thisRect;

    public Vector3 offest;

    public float time;

    private void OnEnable() 
    {
        thisRect.sizeDelta = new Vector2(0.1f, 0.1f);
        
        StartTimer(time); //Test

    }

    private void Update() {
        thisRect.transform.position = obj.position + offest;
    }

    private void StartTimer(float time)
    {
        StartCoroutine(TimerCoroutine(time));
    }

    IEnumerator TimerCoroutine(float time)
    {   
        this.gameObject.SetActive(true);

        float currentTime = 0f;

        while(currentTime < time)
        {
            currentTime += Time.deltaTime;
            timerImg.fillAmount = 1 - currentTime / time;
            yield return new WaitForSecondsRealtime(0.01f);
        }

        this.gameObject.SetActive(false);
    }

    
}
