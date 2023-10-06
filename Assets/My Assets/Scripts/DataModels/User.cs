[System.Serializable]
public class User
{
    public int Rows, Columns, Lives;
    public float PlayerSpeed, BallSpeed;

    public User(int rows, int columns, int lives, float playerSpeed, float ballSpeed)
    {
        Rows = rows;
        Columns = columns;
        Lives = lives;
        PlayerSpeed = playerSpeed;
        BallSpeed = ballSpeed;
    }
}
