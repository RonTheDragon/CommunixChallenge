using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ConfigurationSlider
{
    [SerializeField] private float MinValue;
    [SerializeField] private float MaxValue;
    [SerializeField] private TMP_Text AmountText;
    [SerializeField] private Slider SliderUI;
    private int SliderValue;

    public void InitializeSlider()
    {
        SliderUI.minValue = MinValue;
        SliderUI.maxValue = MaxValue;
    }

    public int GetValue()
    {
        return SliderValue;
    }

    public void SetValue(int newValue)
    {
        SliderUI.value = newValue;
        OnValueChanged(newValue);
    }

    public void OnValueChanged(float newValue)
    {
        AmountText.text = newValue.ToString();
        SliderValue = (int)newValue;
    }

    public void UpdateSliderUI()
    {
        SliderUI.value = SliderValue;
    }
}
