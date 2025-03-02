using System;
using UnityEngine;

public class Status
{
    #region Events    
    public event Action<float> OnHpValueChanged;
    public event Action OnDead;
    #endregion

    public float MaxHP { get; private set; }
    public float HP
    {
        get => _hp;
        private set
        {
            _hp = value;
            OnHpValueChanged?.Invoke(_hp);
        }
    }    
    private float _hp;

    public bool IsAlive { get; private set; }

    // Tree_SO를 바로 받지만 Status에선 Base가 되는 SO를 받도록 수정
    public void Setup(Tree_SO treeSO)
    {
        if (!IsAlive)
            IsAlive = true;
        MaxHP = treeSO.hp;
        HP = treeSO.hp;
    }

    public void GetDamaged(float damage)
    {
        HP = Mathf.Clamp(HP - damage, 0, HP);
        Debug.Log($"데미지를 받았습니다. 현재체력:: {HP}");
        if (HP <= 0)
        {
            IsAlive = false;
            OnDead?.Invoke();            
        }
    }
}
