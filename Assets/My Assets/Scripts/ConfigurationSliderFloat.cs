using UnityEngine;

[System.Serializable]
public class ConfigurationSliderFloat : ConfigurationSlider<float>
{
    public override void OnValueChanged(float newValue)
    {
        AmountText.text = Mathf.RoundToInt(newValue).ToString();
        SliderValue = newValue;
    }

    public override void SetValue(float newValue)
    {
        AmountText.text = Mathf.RoundToInt(newValue).ToString();
        SliderValue = newValue;
        UpdateSliderUI();
    }

    public override void UpdateSliderUI()
    {
        SliderUI.value = SliderValue;
    }
}
