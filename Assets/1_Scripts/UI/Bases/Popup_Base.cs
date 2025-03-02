using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup_Base : MonoBehaviour
{
    public PopupType type;

    public void ClosePopup(PopupType type)
    {
        if(this.type.Equals(type)) gameObject.SetActive(false);
    }

    public void OpenPopup(PopupType type)
    {
        gameObject.SetActive(type.Equals(this.type));
    }

}
