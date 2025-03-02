using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubUI_Base : MonoBehaviour
{
    public SubUIType type;
    public GameObject itemPref;

    #region Button Function
    public void OnClick_Close()
    {
        CloseUI(type);
    }
    #endregion

    public void CloseUI(SubUIType type)
    {
        if(this.type.Equals(type)) gameObject.SetActive(false);
    }

    public void OpenUI(SubUIType type)
    {
        gameObject.SetActive(type.Equals(this.type));
    }

    public virtual void Initialize() { }

}
