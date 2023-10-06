using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private DatabaseMenuManager _databaseManager;
    [SerializeField] private SOConfiguration _defaultConfiguration;
    [SerializeField] private SlidersManager _sliderManager;

    public void InitializeOptionsMenu()
    {
        _sliderManager.InitializeAllSliders();
    }

    public void RevertToDefault()
    {
        _sliderManager.GetRowsSlider().SetValue(_defaultConfiguration.ScriptableUser.Rows);
        _sliderManager.GetColsSlider().SetValue(_defaultConfiguration.ScriptableUser.Columns);
        _sliderManager.GetLivesSlider().SetValue(_defaultConfiguration.ScriptableUser.Lives);
        _sliderManager.GetPlayerSpeedSlider().SetValue(_defaultConfiguration.ScriptableUser.PlayerSpeed);
        _sliderManager.GetBallSpeedSlider().SetValue(_defaultConfiguration.ScriptableUser.BallSpeed);

        ApplyConfiguration();
    }

    public void LoadConfigurationFromUser(User user)
    {
        if (user != null)
        {
            _sliderManager.GetRowsSlider().SetValue(user.Rows);
            _sliderManager.GetColsSlider().SetValue(user.Columns);
            _sliderManager.GetLivesSlider().SetValue(user.Lives);
            _sliderManager.GetPlayerSpeedSlider().SetValue(user.PlayerSpeed);
            _sliderManager.GetBallSpeedSlider().SetValue(user.BallSpeed);
        }
    }

    public void ApplyConfiguration()
    {
        User user = new User(
            _sliderManager.GetRowsSlider().GetValue(),
            _sliderManager.GetColsSlider().GetValue(),
            _sliderManager.GetLivesSlider().GetValue(),
            _sliderManager.GetPlayerSpeedSlider().GetValue(),
            _sliderManager.GetBallSpeedSlider().GetValue()
            );
        _databaseManager.GetDatabase().SetUser(user);
    }
}
