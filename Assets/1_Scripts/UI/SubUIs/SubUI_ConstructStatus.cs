using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubUI_ConstructStatus : SubUI_Base
{
    [Header("Model")]
    [SerializeField] Dam m_Dam;
    [Header("View")]
    [SerializeField] Image DamImg;
    [SerializeField] Image treeImg;
    [SerializeField] Slider m_Slider;
    [SerializeField] TextMeshProUGUI m_Label;

    private void OnEnable()
    {
        m_Dam = FindObjectOfType<Dam>();
        Initialize();
        m_Dam.DamChanged += Dam_Changed;
    }

    private void OnDisable()
    {
        m_Dam.DamChanged -= Dam_Changed;
    }

    public override void Initialize()
    {
        m_Slider.maxValue = m_Dam.NeedLogCount;
        UpdateView();
    }

    public void UpdateView()
    {
        if (m_Dam == null)
        {
            return;
        }

        if (m_Dam.NeedLogCount != 0)
        {
            m_Slider.value = ((float)m_Dam.CurrentLogCount / (float)m_Dam.NeedLogCount);
        }

        if (m_Label != null)
        {
            m_Label.text = $"{m_Dam.CurrentLogCount} / {m_Dam.NeedLogCount}";
        }
    }

    public void Dam_Changed()
    {
        UpdateView();
    }
}
