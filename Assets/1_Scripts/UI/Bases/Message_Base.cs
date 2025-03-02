using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Message_Base : MonoBehaviour
{
    public MessageType messageType;
    public string message;

    public TMP_Text messageText;

    public abstract void ViewMessage(string message);

}
    
