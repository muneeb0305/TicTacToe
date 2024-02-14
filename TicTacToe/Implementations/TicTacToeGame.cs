using TicTacToe.Implementations;
using TicTacToe.Interfaces;

public class TicTacToeGame : IGame
{
    private readonly IBoard _board;
    private IPlayer _currentPlayer;
    private bool _isGameOver;

    public int BoardSize => _board.Size;
    public IPlayer CurrentPlayer => _currentPlayer;
    public bool IsGameOver => _isGameOver;
    public IPlayer? Winner { get; private set; }

    public TicTacToeGame(IBoard board)
    {
        _board = board;
        _board.Initialize();
        _currentPlayer = new TicTacToePlayer(PlayerMark.X);
        _isGameOver = false;
    }

    public void StartGame()
    {
        _board.Initialize();
    }

    public void MakeMove(int row, int col)
    {
        if (_isGameOver || !_board.IsMoveValid(row, col))
            return;

        _board.MarkCell(row, col, _currentPlayer);

        if (_board.CheckForWin(row, col, _currentPlayer))
        {
            _isGameOver = true;
            Winner = _currentPlayer;
            return;
        }
        else if (_board.CheckForDraw())
        {
            _isGameOver = true;
        }
        else
        {
            _currentPlayer = _currentPlayer.Mark == PlayerMark.X ?
                            new TicTacToePlayer(PlayerMark.O) :
                            new TicTacToePlayer(PlayerMark.X);
        }
    }
}
