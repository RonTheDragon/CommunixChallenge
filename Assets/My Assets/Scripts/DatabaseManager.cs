using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    protected Database _database;

    protected void Start()
    {
        _database = new Database();
    }
}
