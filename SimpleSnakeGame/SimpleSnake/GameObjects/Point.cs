using SimpleSnake.GameObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Point : IPoint
    {
        public Point(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; protected set; }

        public int Column { get; protected set; }


        public void Draw(char symbol)
        {
            Console.SetCursorPosition(Column, Row);
            Console.Write(symbol);
        }

        public void Draw(int row, int column, char symbol)
        {
            Console.SetCursorPosition(column, row);
            Console.Write(symbol);
        }
    }
}
