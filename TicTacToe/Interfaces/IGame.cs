namespace TicTacToe.Interfaces
{
    public interface IGame
    {
        int BoardSize { get; }
        bool IsGameOver { get; }
        void StartGame();
        void MakeMove(int row, int col);
        IPlayer CurrentPlayer { get; }
        IPlayer? Winner { get; }

    }
}
