using System;

namespace Tic_Tac_Toe.Game.Backend
{
    public class PlayerMoveHandler
    {
        private readonly Game _game;

        public PlayerMoveHandler(Game game)
        {
            _game = game;
        }

        public bool ProcessPlayerMove(int row, int col)
        {
            if (_game.CurrentPlayer != 'X')
                return false;

            return _game.MakeMove(row, col);
        }
    }
}
