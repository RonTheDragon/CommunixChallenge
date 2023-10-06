using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ConfigurationSlider<T> : ISlider
{
    [SerializeField] private float MinValue;
    [SerializeField] private float MaxValue;
    [SerializeField] protected TMP_Text AmountText;
    [SerializeField] protected Slider SliderUI;
    protected T SliderValue;

    public void InitializeSlider()
    {
        SliderUI.minValue = MinValue;
        SliderUI.maxValue = MaxValue;
    }

    public T GetValue()
    {
        return SliderValue;
    }

    public abstract void OnValueChanged(float newValue);

    public abstract void SetValue(T newValue);

    public abstract void UpdateSliderUI();
}
