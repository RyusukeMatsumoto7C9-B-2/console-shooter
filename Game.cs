namespace console_shooter;

public class Game
{
    public int PlayerPos { get; private set; }
    public int Score { get; private set; }
    private readonly int _screenWidth;

    public Game(int screenWidth)
    {
        _screenWidth = screenWidth;
        PlayerPos = _screenWidth / 2;
        Score = 0;
    }

    public void UpdateScore()
    {
        Score++;
    }

    public void MovePlayer(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                if (PlayerPos > 0)
                {
                    PlayerPos--;
                }
                break;
            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                if (PlayerPos < _screenWidth - 1)
                {
                    PlayerPos++;
                }
                break;
        }
    }
}
