using System;
using System.Collections.Generic;
using Tic_Tac_Toe.Game;

namespace Tic_Tac_Toe.Game.Backend
{
    public enum BotDifficulty
    {
        Easy,
        Hard
    }

    public class Bot
    {
        private BotDifficulty difficulty;
        private Random random;

        public Bot(BotDifficulty difficulty)
        {
            this.difficulty = difficulty;
            random = new Random();
        }

        public (int row, int col) GetMove(Field field, char botSymbol, char opponentSymbol)
        {
            int size = field.Size;
            List<(int row, int col)> availableMoves = new List<(int row, int col)>();

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (field.GetCell(r, c) == '-')
                    {
                        availableMoves.Add((r, c));
                    }
                }
            }

            if (availableMoves.Count == 0)
                throw new Exception("Нет доступных ходов");

            if (difficulty == BotDifficulty.Easy)
            {
                return availableMoves[random.Next(availableMoves.Count)];
            }
            else
            {
                foreach (var move in availableMoves)
                {
                    Field temp = field.Clone();
                    try { temp.SetCell(move.row, move.col, botSymbol); }
                    catch { }
                    if (IsWinningMove(temp, botSymbol))
                        return move;
                }

                foreach (var move in availableMoves)
                {
                    Field temp = field.Clone();
                    try { temp.SetCell(move.row, move.col, opponentSymbol); }
                    catch { }
                    if (IsWinningMove(temp, opponentSymbol))
                        return move;
                }

                return availableMoves[random.Next(availableMoves.Count)];
            }
        }

        private bool IsWinningMove(Field field, char symbol)
        {
            int size = field.Size;

            for (int r = 0; r < size; r++)
            {
                bool win = true;
                for (int c = 0; c < size; c++)
                {
                    if (field.GetCell(r, c) != symbol)
                    {
                        win = false;
                        break;
                    }
                }
                if (win) return true;
            }

            for (int c = 0; c < size; c++)
            {
                bool win = true;
                for (int r = 0; r < size; r++)
                {
                    if (field.GetCell(r, c) != symbol)
                    {
                        win = false;
                        break;
                    }
                }
                if (win) return true;
            }

            bool diagWin = true;
            for (int i = 0; i < size; i++)
            {
                if (field.GetCell(i, i) != symbol)
                {
                    diagWin = false;
                    break;
                }
            }
            if (diagWin) return true;

            diagWin = true;
            for (int i = 0; i < size; i++)
            {
                if (field.GetCell(i, size - i - 1) != symbol)
                {
                    diagWin = false;
                    break;
                }
            }
            if (diagWin) return true;

            return false;
        }
    }
}
