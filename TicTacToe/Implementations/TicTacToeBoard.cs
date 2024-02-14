using TicTacToe.Interfaces;

namespace TicTacToe.Implementations
{
    public class TicTacToeBoard : IBoard
    {
        private ICell[,] _cells;
        public int Size { get; private set; }

        public ICell[,] Cells => _cells;

        public TicTacToeBoard(int size)
        {
            Size = size;
            _cells = new ICell[Size, Size];
            Initialize();
        }

        public void Initialize()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    _cells[i, j] = new TicTacToeCell();
                }
            }
        }

        public bool IsMoveValid(int row, int col)
        {
            return _cells[row, col].Player == null;
        }

        public void MarkCell(int row, int col, IPlayer player)
        {
            _cells[row, col].Player = player;
        }
        public bool CheckForWin(int row, int col, IPlayer player)
        {
            // Check row
            bool win = true;
            for (int i = 0; i < Size; i++)
            {
                if (_cells[row, i].Player?.Mark != player.Mark)
                {
                    win = false;
                    break;
                }
            }
            if (win) return true;

            // Check column
            win = true;
            for (int i = 0; i < Size; i++)
            {
                if (_cells[i, col].Player?.Mark != player.Mark)
                {
                    win = false;
                    break;
                }
            }
            if (win) return true;

            // Check main diagonal if the move is on it
            if (row == col)
            {
                win = true;
                for (int i = 0; i < Size; i++)
                {
                    if (_cells[i, i].Player?.Mark != player.Mark)
                    {
                        win = false;
                        break;
                    }
                }
                if (win) return true;
            }

            // Check anti-diagonal if the move is on it
            if (row + col == Size - 1)
            {
                win = true;
                for (int i = 0; i < Size; i++)
                {
                    if (_cells[i, Size - 1 - i].Player?.Mark != player.Mark)
                    {
                        win = false;
                        break;
                    }
                }
                if (win) return true;
            }

            return false;
        }
        public bool CheckForDraw()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (_cells[i, j].Player == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void Resize(int newSize)
        {
            ICell[,] newBoard = new ICell[newSize, newSize];
            for (int i = 0; i < newSize; i++)
            {
                for (int j = 0; j < newSize; j++)
                {
                    if (i < Size && j < Size)
                    {
                        newBoard[i, j] = _cells[i, j];
                    }
                    else
                    {
                        newBoard[i, j] = new TicTacToeCell();
                    }
                }
            }
            _cells = newBoard;
            Size = newSize;
        }

    }
}
