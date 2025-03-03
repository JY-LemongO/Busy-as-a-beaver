using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    //BGM 종류들
    public enum EBgm
    {
        BGM_TITLE,
        BGM_GAME,
    }
    
    //SFX 종류들
    public enum ESfx
    {
        SFX_BUTTON,
        SFX_ENDING,
        SFX_TOKEN,
        SFX_BOTTLE,
        SFX_OPENDOOR,
        SFX_MissionClear
    }

    //audio clip 담을 수 있는 배열
    [SerializeField] AudioClip[] bgms;
    [SerializeField] AudioClip[] sfxs;

    //플레이하는 AudioSource
    [SerializeField] AudioSource audioBgm;
    [SerializeField] AudioSource audioSfx;

    


    // EBgm 열거형을 매개변수로 받아 해당하는 배경 음악 클립을 재생
    public void PlayBGM(EBgm bgmIdx)
    {
      	//enum int형으로 형변환 가능
        audioBgm.clip = bgms[(int)bgmIdx];
        audioBgm.Play();
    }

    // 현재 재생 중인 배경 음악 정지
    public void StopBGM()
    {
        audioBgm.Stop();
    }

    // ESfx 열거형을 매개변수로 받아 해당하는 효과음 클립을 재생
    public void PlaySFX(ESfx esfx)
    {   
        audioSfx.PlayOneShot(sfxs[(int)esfx]);
    }
}
