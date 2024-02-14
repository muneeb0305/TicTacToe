using TicTacToe.Interfaces;

namespace TicTacToe.Implementations
{
    public class TicTacToeCell : ICell
    {
        public IPlayer? Player { get; set; }
    }
}
