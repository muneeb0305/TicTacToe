namespace TicTacToe.Interfaces
{
    public interface IBoard
    {
        int Size { get; }
        ICell[,] Cells { get; }
        bool IsMoveValid(int row, int col);
        void MarkCell(int row, int col, IPlayer player);
        bool CheckForWin(int row, int col, IPlayer player);
        bool CheckForDraw();
        void Initialize();
        void Resize(int newSize);

    }
}
