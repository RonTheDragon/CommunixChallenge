using Firebase.Database;
using System;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputName;
    [SerializeField] private TMP_InputField _inputPoints;

    [SerializeField] private TMP_Text _outputName;
    [SerializeField] private TMP_Text _outputPoints;

    private string _userID;
    private DatabaseReference _dbReference;

    // Start is called before the first frame update
    void Start()
    {
        _userID = SystemInfo.deviceUniqueIdentifier;
        Debug.Log(_userID);
        _dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void CreateUser()
    {
        User newUser = new User(_inputName.text,int.Parse(_inputPoints.text));
        string json = JsonUtility.ToJson(newUser);

        _dbReference.Child("users").Child(_userID).SetRawJsonValueAsync(json);
    }

    public IEnumerator GetName(Action<string> onCallback)
    {
        Task<DataSnapshot> userNameData = _dbReference.Child("users").Child(_userID).Child("name").GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;

            onCallback.Invoke(snapshot.Value.ToString());
        }
    }

    public IEnumerator GetPoints(Action<int> onCallback)
    {
        Task<DataSnapshot> userNameData = _dbReference.Child("users").Child(_userID).Child("points").GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;

            onCallback.Invoke(int.Parse(snapshot.Value.ToString()));
        }
    }

    public void GetUserInfo()
    {
        StartCoroutine(GetName((string name) =>
        {
            _outputName.text = name;
        }));

        StartCoroutine(GetPoints((int points) =>
        {
            _outputPoints.text = points.ToString();
        }));
    }
}
