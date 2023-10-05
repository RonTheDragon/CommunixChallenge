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
        StartCoroutine(IsUserExist());
    }

    private IEnumerator IsUserExist()
    {
        Task<DataSnapshot> userNameDataTask = _database.GetUserDataSnapshot();
        yield return new WaitUntil(() => userNameDataTask.IsCompleted);

        if (userNameDataTask.Exception != null)
        {
            // Handle errors
            Debug.LogError("Error retrieving user data: " + userNameDataTask.Exception);
            UserNotExist();
        }
        else
        {
            // Check if data exists
            if (userNameDataTask.Result.Exists)
            {
                UserAlreadyExist();
            }
            else
            {
                UserNotExist();
            }
        }
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

    public Database GetDatabase()
    {
        return _database;
    }
}
