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

    public Task<DataSnapshot> GetUserDataSnapshot()
    {
        return _userDbReference.GetValueAsync();
    }

    public void SetUser(User user)
    {
        string json = JsonUtility.ToJson(user);
        _userDbReference.SetRawJsonValueAsync(json);
    }

    public IEnumerator GetUser(Action<User> onCallBack)
    {
        Task<DataSnapshot> RowsDataTask = _userDbReference.Child("Rows").GetValueAsync();
        Task<DataSnapshot> ColsDataTask = _userDbReference.Child("Columns").GetValueAsync();

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
