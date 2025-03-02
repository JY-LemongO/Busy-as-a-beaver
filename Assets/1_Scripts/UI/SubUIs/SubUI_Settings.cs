using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubUI_Settings : SubUI_Base
{
    public Slider volumnSlider;



    public void ResetStatusButton()
    {
       StatusManager.Instance.Reset();
       MessageManager.Instance.ViewMessage(MessageType.NOMAL, $"데이터를 초기화 합니다. 2초뒤에 게임이 종료됩니다.");
    }

    public void QuitButton()
    {   
        StatusManager.Instance.SetDirty();
        Application.Quit();
    }

    IEnumerator GameQuitCoroutine()
    {
        yield return new WaitForSecondsRealtime(2f);
        Application.Quit();
    }
}
