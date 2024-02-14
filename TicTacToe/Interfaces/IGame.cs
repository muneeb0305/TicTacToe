namespace TicTacToe.Interfaces
{
    public interface IGame
    {
        int BoardSize { get; }
        IPlayer CurrentPlayer { get; }
        bool IsGameOver { get; }
        IPlayer? Winner { get; }

        void StartGame();
        void MakeMove(int row, int col);
    }
}
