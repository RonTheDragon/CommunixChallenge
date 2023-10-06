[System.Serializable]
public class ConfigurationSliderInt : ConfigurationSlider<int>
{
    public override void OnValueChanged(float newValue)
    {
        AmountText.text = newValue.ToString();
        SliderValue = (int)newValue;
    }

    public override void SetValue(int newValue)
    {
        AmountText.text = newValue.ToString();
        SliderValue = newValue;
        SliderUI.value = newValue;
    }

    public override void UpdateSliderUI()
    {
        SliderUI.value = SliderValue;
    }
}
