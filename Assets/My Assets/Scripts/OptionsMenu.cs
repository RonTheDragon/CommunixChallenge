using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private float _minRows, _maxRows, _minCols, _maxCols;
    [SerializeField] private TMP_Text _rowsAmount, _colsAmount;
    [SerializeField] private Slider _rowsSlider, _colsSlider;

    private void Start()
    {
        InitializeRowsAndCols();
    }

    private void InitializeRowsAndCols()
    {
        _rowsSlider.minValue = _minRows;
        _rowsSlider.maxValue = _maxRows;
        _colsSlider.minValue = _minCols;
        _colsSlider.maxValue = _maxCols;
    }

    public void OnRowsValueChanged(float value)
    {
        _rowsAmount.text = value.ToString();
    }

    public void OnColsValueChanged(float value)
    {
        _colsAmount.text = value.ToString();
    }
}
