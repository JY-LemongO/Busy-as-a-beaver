using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.Events;

public class MessageManager : MonoSingleton<MessageManager>
{
    public UnityAction<string> messageAction;

    public SerializedDictionary<MessageType, Message_Base> dict_Message = new SerializedDictionary<MessageType, Message_Base>();

    #region LifeCycle
    private void OnEnable() 
    {
        Initialize();
    }
    #endregion

    #region private Function
    private void Initialize()
    {
        foreach(var msg in dict_Message.Values)
        {
            msg.gameObject.SetActive(false);
        }

        //
    }
    #endregion

    public void ViewMessage(MessageType type, string message)
    {
        dict_Message[type].ViewMessage(message);
    }
    public void ViewMessage(MessageType type, EnemyData data)
    {
        dict_Message[type].ViewMessage(data);
    }
}
