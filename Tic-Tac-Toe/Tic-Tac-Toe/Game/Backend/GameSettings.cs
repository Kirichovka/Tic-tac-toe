using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe.Game.Backend
{
    public class GameSettings
    {
        public int Size { get; }
        public int Difficulty { get; }

        public GameSettings(int size, int difficulty)
        {
            Size = size;
            Difficulty = difficulty;
        }
    }
}

