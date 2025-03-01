using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SubUI_Upgrade : SubUI_Base
{
    public ScrollRect scrollView;


    private void OnEnable() 
    {
        Initialize();
    }

    private void Initialize()
    {
        scrollView.normalizedPosition = new Vector2(1f, 0f);
    }
}
