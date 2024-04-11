using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Field : Point
    {
        private char wallSymbol = '\u25A0';

        public Field(int row, int column)
            : base(row, column)
        {
            CreateField();
        }

        private void CreateField()
        {
            char[,] field = new char[Row, Column];

            for (int currentRow = 0; currentRow < Row; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < Column; currentColumn++)
                {
                    if (currentRow == 0 ||
                        currentRow == Row - 1 ||
                        currentColumn == 0 ||
                        currentColumn == Column - 1)
                    {
                        Draw(currentRow, currentColumn, wallSymbol);
                    }
                    else
                    {
                        Draw(currentRow, currentColumn, ' ');
                    }
                }
            }
        }
    }
}
