using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Message_Enemy : Message_Base
{   
    public Image icon;

    public override void ViewMessage(EnemyData data)
    {
        base.messageText.text = $"{data.enemyName}가 나타났습니다!\n{data.description}";

        gameObject.SetActive(true);

        StartCoroutine(WaitCoroutine(3f));
    }

    public override void ViewMessage(string message) { }
}
