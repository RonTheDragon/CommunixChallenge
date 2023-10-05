using UnityEngine;

public class DatabaseGameManager : DatabaseManager
{
    [SerializeField] private GameManager _gameManager;
    
    new protected void Start()
    {
        base.Start();
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
