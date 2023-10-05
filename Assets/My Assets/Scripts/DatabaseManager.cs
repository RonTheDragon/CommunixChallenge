using UnityEngine;

public abstract class DatabaseManager : MonoBehaviour
{
    protected Database _database;

    protected void Start()
    {
        _database = new Database();
    }

    public Database GetDatabase()
    {
        return _database;
    }
}
