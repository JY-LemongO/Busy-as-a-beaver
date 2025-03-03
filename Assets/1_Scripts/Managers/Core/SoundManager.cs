using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum SoundKey
{
    Button_Click,
    Coin_Reward,
    error,
    SoundEffect,
    Upgrade_Sound,
}

public class SoundManager : SingletonBase<SoundManager>
{
    private const string SOUND_CLIP_PATH = "Sound/";
    private const int SOURCE_COUNT = 10;

    public List<AudioSource> _sfxSources = new List<AudioSource>();    

    private int _currentIndex;

    public void PlaySFX(SoundKey sfxType)
    {
        string key = SOUND_CLIP_PATH + sfxType.ToString();
        AudioClip clip = ResourceManager.Instance.Load<AudioClip>(key);

        _sfxSources[_currentIndex].PlayOneShot(clip);
        _currentIndex++;

        if(_currentIndex == SOURCE_COUNT)
            _currentIndex = 0;
    }

    protected override void InitChild()
    {
        for(int i = 0; i < SOURCE_COUNT; i++)
        {
            AudioSource soruce = transform.AddComponent<AudioSource>();
            _sfxSources.Add(soruce);
        }
    }
}
