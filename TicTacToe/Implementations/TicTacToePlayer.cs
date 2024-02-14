using TicTacToe.Interfaces;

namespace TicTacToe.Implementations
{
    public class TicTacToePlayer : IPlayer
    {
        public PlayerMark Mark { get; }
        public TicTacToePlayer(PlayerMark mark)
        {
            Mark = mark;
        }
    }
}
