using Firebase.Database;
using UnityEngine;

public abstract class DatabaseManager : MonoBehaviour
{
    protected Database _database;

    protected void Start()
    {
        // Disable local caching (persistence) to ensure real-time data freshness.
        // This resolves a bug where old data was intermittently being used.
        FirebaseDatabase.DefaultInstance.SetPersistenceEnabled(false);

        // Initialize the Database instance.
        _database = new Database();
    }

    // Accessor method to get the Database instance.
    public Database GetDatabase()
    {
        return _database;
    }
}
