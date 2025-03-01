using System;
using System.Windows.Forms;

namespace Tic_Tac_Toe.Game.Backend
{
    public class Game
    {
        private Field _field;
        private GameSettings _settings;

        // Текущий игрок: 'X' (человек) или 'O' (бот)
        public char CurrentPlayer { get; private set; }

        // Режим игры: true, если игра идет против бота
        public bool IsBotGame { get; set; } = false;

        // Экземпляр бота (если IsBotGame == true)
        public Bot BotInstance { get; set; }

        // Событие, уведомляющее о том, что поле обновилось (для UI)
        public event Action<Field> GameUpdated;

        public void StartGame(GameSettings settings)
        {
            _settings = settings;
            _field = new Field(settings.Size);
            CurrentPlayer = 'X'; // Предполагаем, что игрок ходит первым
            // После старта сразу уведомляем UI
            GameUpdated?.Invoke(_field);
        }
        public void SetStartingPlayer(char player)
        {
            if (player == 'X' || player == 'O')
            {
                CurrentPlayer = player;
            }
            else
            {
                throw new ArgumentException("Допустимый символ: 'X' или 'O'");
            }
        }

        public Field GetField() => _field;

        // Центральный метод для совершения хода (как игрока, так и бота)
        public bool MakeMove(int row, int col)
        {
            try
            {
                // Ставим символ текущего игрока в выбранную ячейку
                _field.SetCell(row, col, CurrentPlayer);

                // Уведомляем UI об изменениях
                GameUpdated?.Invoke(_field);

                // Проверка победителя или ничьей (при необходимости можно оставить или вынести отдельно)
                char winner = CheckWinner();
                if (winner != '-')
                {
                    MessageBox.Show($"Победитель: {winner}");
                }
                else if (IsBoardFull())
                {
                    MessageBox.Show("Ничья!");
                }
                else
                {
                    // Переключаем текущего игрока
                    CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';

                    // Уведомляем UI об изменениях после переключения (если требуется обновление цвета или подсветки)
                    GameUpdated?.Invoke(_field);

                    // Если игра против бота и сейчас очередь бота, автоматически делаем ход бота
                    if (IsBotGame && CurrentPlayer == 'O' && BotInstance != null)
                    {
                        // Получаем ход от бота: бот играет за 'O', противник 'X'
                        var move = BotInstance.GetMove(_field, 'O', 'X');
                        // Выполняем ход бота (рекурсивно вызывает MakeMove, который переключит игрока обратно на 'X')
                        MakeMove(move.row, move.col);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка хода: " + ex.Message);
                return false;
            }
        }

        // Проверка победителя – заполненная строка, столбец или диагональ
        public char CheckWinner()
        {
            int size = _settings.Size;

            // Проверка строк
            for (int i = 0; i < size; i++)
            {
                char first = _field.GetCell(i, 0);
                if (first == '-') continue;
                bool win = true;
                for (int j = 1; j < size; j++)
                {
                    if (_field.GetCell(i, j) != first)
                    {
                        win = false;
                        break;
                    }
                }
                if (win) return first;
            }

            // Проверка столбцов
            for (int j = 0; j < size; j++)
            {
                char first = _field.GetCell(0, j);
                if (first == '-') continue;
                bool win = true;
                for (int i = 1; i < size; i++)
                {
                    if (_field.GetCell(i, j) != first)
                    {
                        win = false;
                        break;
                    }
                }
                if (win) return first;
            }

            // Проверка главной диагонали
            char diagFirst = _field.GetCell(0, 0);
            if (diagFirst != '-')
            {
                bool win = true;
                for (int i = 1; i < size; i++)
                {
                    if (_field.GetCell(i, i) != diagFirst)
                    {
                        win = false;
                        break;
                    }
                }
                if (win) return diagFirst;
            }

            // Проверка побочной диагонали
            diagFirst = _field.GetCell(0, size - 1);
            if (diagFirst != '-')
            {
                bool win = true;
                for (int i = 1; i < size; i++)
                {
                    if (_field.GetCell(i, size - i - 1) != diagFirst)
                    {
                        win = false;
                        break;
                    }
                }
                if (win) return diagFirst;
            }

            return '-'; // Победителя не найдено
        }

        private bool IsBoardFull()
        {
            int size = _settings.Size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (_field.GetCell(i, j) == '-')
                        return false;
                }
            }
            return true;
        }
    }
}
