using UnityEngine;

public class DatabaseMenuManager : DatabaseManager
{
    [SerializeField] private OptionsMenu _optionsMenu;
    [SerializeField] private GameObject _ui;

    new protected void Start()
    {
        base.Start();
        _ui.SetActive(false);
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
            _ui.SetActive(true);
        }));
    }

    private void UserNotExist()
    {
        _optionsMenu.RevertToDefault();
        _ui.SetActive(true);
    }
}
