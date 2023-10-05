using Firebase.Database;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;

public class DatabaseMenuManager : DatabaseManager
{
    [SerializeField] private OptionsMenu _optionsMenu;

    new protected void Start()
    {
        base.Start();
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
