using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levelPresetList;

    private Level _currentLevel;
    private int _currentLevelValue;
    private const int LEVEL_PHASE = 5;    

    private void Awake()
    {
        SetLevel(1);
        StageManager.Instance.OnStageClear += SetLevel;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            DamManager.Instance.BuildDamComplete();
        if (Input.GetKeyDown(KeyCode.P))
            SoundManager.Instance.PlaySFX(SoundKey.Button_Click);
        if (Input.GetKeyDown(KeyCode.O))
            SoundManager.Instance.PlaySFX(SoundKey.Coin_Reward);
        if (Input.GetKeyDown(KeyCode.I))
            SoundManager.Instance.PlaySFX(SoundKey.SoundEffect);
        if (Input.GetKeyDown(KeyCode.U))
            SoundManager.Instance.PlaySFX(SoundKey.error);
    }

    public void SetLevel(int level)
    {
        if (_currentLevel != null)
            PoolManager.Instance.Return(_currentLevel.gameObject);
        _currentLevel = PoolManager.Instance.Get(_levelPresetList[level - 1]).GetComponent<Level>();
        _currentLevel.SpawnDam();
        //StartCoroutine(Co_Delay(level));
    }

    private IEnumerator Co_Delay(int level)
    {
        yield return new WaitForSeconds(1);        

        
    }
}
