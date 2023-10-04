using UnityEngine;

public class DatabaseGameManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    private Database _database;
    
    void Start()
    {
        _database = new Database();
        StartCoroutine(_database.GetUser((User user) =>
        {
            UpdateGameConfiguration(user);
        }));
    }

    private void UpdateGameConfiguration(User user)
    {
        if (user != null)
        {
            _gameManager.brickCountX = user.Rows;
            _gameManager.brickCountY = user.Columns;
        }
        _gameManager.StartGame();
    }
}
