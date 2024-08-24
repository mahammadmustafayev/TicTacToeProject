namespace TicTacToe.Models;

public class TicTacToeEntity
{
    public char[,] Board { get; private set; }
    public char CurrentPlayer { get;private set; }
    public bool GameOver { get; private set; }
    public string Winner { get;private set; }
    public TicTacToeEntity()
    {
        Board = new char[3, 3];
        CurrentPlayer = 'X';
        GameOver = false;
        Winner = string.Empty;
        InitializeBoard();
    }
    private void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Board[i, j] = ' ';
            }
        }
    }
    public bool MakeMove(int row, int col)
    {
        if (Board[row, col] == ' ' && !GameOver)
        {
            Board[row, col] = CurrentPlayer;
            if (CheckWinner())
            {
                GameOver = true;
                Winner = $"{CurrentPlayer} wins!";
            }
            else if (IsBoardFull())
            {
                GameOver = true;
                Winner = "Draw!";
            }
            else
            {
                CurrentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';
            }
            return true;
        }
        return false;
    }
    private bool IsBoardFull()
    {
        foreach (var cell in Board)
        {
            if (cell == ' ') return false;
        }
        return true;
    }

    private bool CheckWinner()
    {
        // Check rows, columns, and diagonals
        for (int i = 0; i < 3; i++)
        {
            if (Board[i, 0] != ' ' && Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2])
                return true;
            if (Board[0, i] != ' ' && Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i])
                return true;
        }
        if (Board[0, 0] != ' ' && Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
            return true;
        if (Board[0, 2] != ' ' && Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])
            return true;

        return false;
    }

    public void ResetGame()
    {
        InitializeBoard();
        CurrentPlayer = 'X';
        GameOver = false;
        Winner = string.Empty;
    }
}
