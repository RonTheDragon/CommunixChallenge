using UnityEngine;
using System.Collections;

public class BricksConfiguration : MonoBehaviour
{
    [SerializeField] private ConfigurationSlider _rowsSlider;
    [SerializeField] private ConfigurationSlider _colsSlider;

    private void Start()
    {
        InitializeRowsAndCols();
    }

    private void InitializeRowsAndCols()
    {
        _rowsSlider?.InitializeSlider();
        _colsSlider?.InitializeSlider();
    }
    public int GetRows()
    {
        return _rowsSlider.GetValue();
    }

    public int GetCols()
    {
        return _colsSlider.GetValue();
    }

    public void SetRows(int newValue)
    {
        _rowsSlider?.SetValue(newValue);
    }

    public void SetCols(int newValue)
    {
        _colsSlider?.SetValue(newValue);
    }

    public void OnRowsValueChanged(float newValue)
    {
        _rowsSlider?.OnValueChanged(newValue);
    }

    public void OnColsValueChanged(float newValue)
    {
        _colsSlider?.OnValueChanged(newValue);
    }

    private void OnEnable()
    {
        StartCoroutine(UpdateSlidersWithDelay());
    }

    private IEnumerator UpdateSlidersWithDelay()
    {
        yield return null;
        _rowsSlider?.UpdateSliderUI();
        _colsSlider?.UpdateSliderUI();
    }  
}
