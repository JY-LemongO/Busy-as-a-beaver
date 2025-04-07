using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UISound : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;

    public void PlaySound()
    {
        if (clickSound)
            SoundManager.Instance.PlayClip(clickSound);
    }
}
