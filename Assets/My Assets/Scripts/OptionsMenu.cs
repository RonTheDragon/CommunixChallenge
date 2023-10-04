using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private DatabaseManager _databaseManager;
    [SerializeField] private SOConfiguration _defaultConfiguration;
    [SerializeField] private BricksConfiguration _brickConfiguration;

    public void RevertToDefault()
    {
        _brickConfiguration.SetRows(_defaultConfiguration.Rows);
        _brickConfiguration.SetCols(_defaultConfiguration.Columns);

        ApplyConfiguration();
    }

    public void UpdateOptionsFromUser(User user)
    {
        if (user != null)
        {
            _brickConfiguration.SetRows(user.Rows);
            _brickConfiguration.SetCols(user.Columns);
        }
    }

    public void ApplyConfiguration()
    {
        User user = new User(_brickConfiguration.GetRows(), _brickConfiguration.GetCols());
        _databaseManager.SetUser(user);
    }
}
