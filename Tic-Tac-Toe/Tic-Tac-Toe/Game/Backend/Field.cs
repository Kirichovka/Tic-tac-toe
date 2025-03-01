using System;

namespace Tic_Tac_Toe.Game
{
    public class Field
    {
        private char[,] field;
        private int size;

        public Field(int size = 3)
        {
            if (size != 3 && size != 5)
            {
                throw new ArgumentException("Размер может быть только 3×3 или 5×5");
            }

            this.size = size;
            field = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = '-';
                }
            }
        }

        public int Size
        {
            get { return size; }
        }

        public void SetCell(int row, int col, char value)
        {
            if (row >= 0 && row < size && col >= 0 && col < size)
            {
                // Проверка: ячейка должна быть пустой (обозначается символом '-')
                if (field[row, col] != '-')
                {
                    throw new ArgumentException("Ячейка уже занята");
                }
                if (value == 'X' || value == 'O')
                {
                    field[row, col] = value;
                }
                else
                {
                    throw new ArgumentException("Допустимые символы: 'X' или 'O'");
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Неверные координаты");
            }
        }

        public char GetCell(int row, int col)
        {
            if (row >= 0 && row < size && col >= 0 && col < size)
            {
                return field[row, col];
            }
            throw new IndexOutOfRangeException("Неверные координаты");
        }

        public Field Clone()
        {
            Field clone = new Field(size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    clone.field[i, j] = this.field[i, j];
                }
            }
            return clone;
        }
    }
}
