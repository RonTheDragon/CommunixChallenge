using UnityEngine;
using System.Collections;

public class SlidersManager : MonoBehaviour
{
    [SerializeField] private ConfigurationSliderInt _rowsSlider;
    [SerializeField] private ConfigurationSliderInt _colsSlider;
    [SerializeField] private ConfigurationSliderInt _livesSlider;
    [SerializeField] private ConfigurationSliderFloat _playerSpeedSlider;
    [SerializeField] private ConfigurationSliderFloat _ballSpeedSlider;
    private ISlider[] _allSliders;

    public void InitializeAllSliders()
    {
        SetupSliderList();
        foreach (ISlider slider in _allSliders)
        {
            slider.InitializeSlider();
        }
    }

    private void SetupSliderList()
    {
        if (_allSliders != null)
        {
            return; // list already set
        }

        _allSliders = new ISlider[]
        {
            _rowsSlider,
            _colsSlider,
            _livesSlider,
            _playerSpeedSlider,
            _ballSpeedSlider
        };
    }

    #region GetSliders
    public ConfigurationSliderInt GetRowsSlider() 
    {
        return _rowsSlider; 
    }

    public ConfigurationSliderInt GetColsSlider()
    {
        return _colsSlider;
    }
    public ConfigurationSliderInt GetLivesSlider()
    {
        return _livesSlider;
    }

    public ConfigurationSliderFloat GetPlayerSpeedSlider()
    {
        return _playerSpeedSlider;
    }

    public ConfigurationSliderFloat GetBallSpeedSlider()
    {
        return _ballSpeedSlider;
    }
    #endregion

    #region OnValueChanged
    public void OnRowsValueChanged(float newValue)
    {
        _rowsSlider?.OnValueChanged(newValue);
    }

    public void OnColsValueChanged(float newValue)
    {
        _colsSlider?.OnValueChanged(newValue);
    }

    public void OnLivesValueChanged(float newValue)
    {
        _livesSlider?.OnValueChanged(newValue);
    }

    public void OnPlayerSpeedValueChanged(float newValue)
    {
        _playerSpeedSlider?.OnValueChanged(newValue);
    }

    public void OnBallSpeedValueChanged(float newValue)
    {
        _ballSpeedSlider?.OnValueChanged(newValue);
    }
    #endregion


    private void OnEnable()
    {
        StartCoroutine(UpdateSlidersWithDelay());
    }

    private IEnumerator UpdateSlidersWithDelay()
    {
        yield return null;

        SetupSliderList();
        foreach (ISlider slider in _allSliders)
        {
            slider?.UpdateSliderUI();
        }
    }  
}
