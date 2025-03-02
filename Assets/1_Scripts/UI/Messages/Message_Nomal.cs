using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_Nomal : Message_Base
{
    public override void ViewMessage(string message)
    {   
        base.messageText.text = message;
        gameObject.SetActive(true);

        StartCoroutine(WaitCoroutine(1f));
    }

    public override void ViewMessage(EnemyData data){ }
}
