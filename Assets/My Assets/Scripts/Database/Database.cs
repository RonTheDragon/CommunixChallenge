using Firebase.Database;
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Database
{
    private string _userID;
    private DatabaseReference _dbReference;
    private DatabaseReference _userDbReference;

    public Database()
    {
        _userID = SystemInfo.deviceUniqueIdentifier;
        _dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        _userDbReference = _dbReference.Child("users").Child(_userID);
    }

    public IEnumerator IsUserExist(Action<bool> onCallBack)
    {
        Task<DataSnapshot> userNameDataTask = _userDbReference.GetValueAsync();
        yield return new WaitUntil(() => userNameDataTask.IsCompleted);

        if (userNameDataTask.Exception != null)
        {
            // Handle errors
            Debug.LogError("Error retrieving user data: " + userNameDataTask.Exception);
            onCallBack.Invoke(false);
        }
        else
        {
            // Check if data exists
            if (userNameDataTask.Result.Exists)
            {
                onCallBack.Invoke(true);
            }
            else
            {
                onCallBack.Invoke(false);
            }
        }
    }

    public void SetUser(User user)
    {
        string json = JsonUtility.ToJson(user);
        _userDbReference.SetRawJsonValueAsync(json);
    }

    public IEnumerator GetUser(Action<User> onCallBack)
    {
        Task<DataSnapshot> UserDataTask = _userDbReference.GetValueAsync();

        yield return new WaitUntil(() => UserDataTask.IsCompleted);

        if (UserDataTask.Exception != null)
        {
            Debug.LogError("Error retrieving data from Firebase: " + UserDataTask.Exception);
            onCallBack.Invoke(null);
            yield break; // exit the coroutine on error
        }

        try
        {
            // Assuming the data is stored as a JSON string
            string jsonData = UserDataTask.Result.GetRawJsonValue();

            // Deserialize the JSON string into a User object
            User user = JsonUtility.FromJson<User>(jsonData);

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
