using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class BricksConfiguration : MonoBehaviour
{
    [SerializeField] private float _minRows, _maxRows, _minCols, _maxCols;
    [SerializeField] private TMP_Text _rowsAmountText, _colsAmountText;
    [SerializeField] private Slider _rowsSlider, _colsSlider;
    private int _rows, _cols;

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
        _rowsAmountText.text = value.ToString();
        _rows = (int)value;
    }

    public void OnColsValueChanged(float value)
    {
        _colsAmountText.text = value.ToString();
        _cols = (int)value;
    }

    public void SetRows(int value)
    {
        _rowsSlider.value = value;
        _rowsAmountText.text = value.ToString();
        _rows = value;
    }

    public void SetCols(int value)
    {
        _colsSlider.value = value;
        _colsAmountText.text = value.ToString();
        _cols = value;
    }

    private void OnEnable()
    {
        StartCoroutine(UpdateSlidersWithDelay());
    }

    private IEnumerator UpdateSlidersWithDelay()
    {
        yield return null;
        _rowsSlider.value = _rows;
        _colsSlider.value = _cols;
    }

    public int GetRows()
    {
        return _rows;
    }

    public int GetCols()
    {
        return _cols;
    }
}
