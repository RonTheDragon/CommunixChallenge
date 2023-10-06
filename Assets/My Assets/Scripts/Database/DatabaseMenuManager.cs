using UnityEngine;

public class DatabaseMenuManager : DatabaseManager
{
    [SerializeField] private OptionsMenu _optionsMenu;

    new protected void Start()
    {
        base.Start();
        _optionsMenu.InitializeOptionsMenu();
        CheckIfUserExist();
    }

    private void CheckIfUserExist()
    {
        StartCoroutine(_database.IsUserExist((bool userExists) =>
        {
            if (userExists)
            {
                UserAlreadyExist();
            }
            else
            {
                UserNotExist();
            }
        }));
    }


    private void UserAlreadyExist()
    {
        StartCoroutine(_database.GetUser((User user) =>
        {
            _optionsMenu.LoadConfigurationFromUser(user);
        }));
    }

    private void UserNotExist()
    {
        _optionsMenu.RevertToDefault();
    }
}
