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

public class SoundManager : MonoSingleton<SoundManager>
{
    [SerializeField][Range(0f, 1f)] private float soundEffectVolume;
    [SerializeField][Range(0f, 1f)] private float soundEffectPitchVariance;
    [SerializeField][Range(0f, 1f)] private float musicVolume;

    private AudioSource musicAudioSource;
    public AudioClip musicClip;

    private void Awake()
    {
        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.volume = musicVolume;
        musicAudioSource.loop = true;
    }

    private void Start()
    {
        ChangeBackGroundMusic(musicClip);
    }

    public void ChangeBackGroundMusic(AudioClip music)
    {
        musicAudioSource.Stop();
        musicAudioSource.clip = music;
        musicAudioSource.Play();
    }

    string PREFAB_PATH = "Prefabs/Sound/Sound";
    public void PlayClip(AudioClip clip)
    {
        GameObject obj = ResourceManager.Instance.Instantiate(PREFAB_PATH);
        obj.SetActive(true);
        SoundSource soundSource = obj.GetComponent<SoundSource>();
        soundSource.Play(clip, soundEffectVolume, soundEffectPitchVariance);
    }
}
