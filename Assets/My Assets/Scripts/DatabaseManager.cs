using Firebase.Database;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System;

public class DatabaseManager : MonoBehaviour
{
    [SerializeField] private OptionsMenu _optionsMenu;
    private string _userID;
    private DatabaseReference _dbReference;

    void Start()
    {
        _userID = SystemInfo.deviceUniqueIdentifier;
        _dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        StartCoroutine(IsUserExist());
    }

    private IEnumerator IsUserExist()
    {
        Task<DataSnapshot> userNameDataTask = _dbReference.Child("users").Child(_userID).GetValueAsync();
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
        StartCoroutine(GetUser((User user) =>
        {
            _optionsMenu.UpdateOptionsFromUser(user);
        }));
    }

    private void UserNotExist()
    {
        _optionsMenu.RevertToDefault();
    }

    public void SetUser(User user)
    {
        string json = JsonUtility.ToJson(user);
        _dbReference.Child("users").Child(_userID).SetRawJsonValueAsync(json);
    }

    public IEnumerator GetUser(Action<User> onCallBack)
    {
        Task<DataSnapshot> RowsDataTask = _dbReference.Child("users").Child(_userID).Child("Rows").GetValueAsync();
        Task<DataSnapshot> ColsDataTask = _dbReference.Child("users").Child(_userID).Child("Columns").GetValueAsync();

        yield return new WaitUntil(() => RowsDataTask.IsCompleted && ColsDataTask.IsCompleted);

        if (RowsDataTask.Exception != null || ColsDataTask.Exception != null)
        {
            Debug.LogError("Error retrieving data from Firebase: " + RowsDataTask.Exception + " | " + ColsDataTask.Exception);
            onCallBack.Invoke(null);
            yield break; // exit the coroutine on error
        }

        try
        {
            // Assuming Rows and Columns are integers, convert the data
            int rows = int.Parse(RowsDataTask.Result.Value.ToString());
            int columns = int.Parse(ColsDataTask.Result.Value.ToString());

            // Create a User object with the retrieved data
            User user = new User(rows, columns);

            // Invoke the callback with the User object
            onCallBack.Invoke(user);
        }
        catch (Exception ex)
        {
            Debug.LogError("Error converting data: " + ex.Message);
            onCallBack.Invoke(null);
        }
    }

}
