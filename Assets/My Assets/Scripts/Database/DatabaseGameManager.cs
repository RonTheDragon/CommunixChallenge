using UnityEngine;

public class DatabaseGameManager : DatabaseManager
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Paddle _paddle;
    [SerializeField] private Ball _ball;
    
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
            _gameManager.lives = user.Lives;
            _paddle.speed = user.PlayerSpeed;
            BallAdjustments(user.BallSpeed);
        }
        _gameManager.StartGame();
    }

    private void BallAdjustments(float speed)
    {
        float maxSpeedRatio = _ball.maxSpeed / _ball.InitialSpeed;
        float speedIncrementRatio = _gameManager.ballSpeedIncrement / _ball.InitialSpeed;

        _ball.InitialSpeed = speed;
        _ball.maxSpeed = speed * maxSpeedRatio;
        _gameManager.ballSpeedIncrement = (int)(speed * speedIncrementRatio);
    }
}
