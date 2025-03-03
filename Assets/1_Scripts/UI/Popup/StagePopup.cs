using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StagePopup : Popup_Base
{
    public TMP_Text title;

    public StageData data;

    public int stageLevel; //어딘가 스테이지 저장하는 변수가 있을듯.

    private void OnEnable() {
        data = GameManager.Instance.GetStageData(stageLevel);
    }

    public void OnClick_NextButton()
    {
        StageManager.Instance.StageClear();
    }

    public void OnClick_PreButton()
    {
        
    }

}
