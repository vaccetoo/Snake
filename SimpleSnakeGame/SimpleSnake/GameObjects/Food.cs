using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Food : Point
    {
        Field field;
        Random random;
        private char foodSymbol;
        private const int InitialFieldRowCol = 0;

        public Food(Field field)
            : base(InitialFieldRowCol, InitialFieldRowCol)
        {
            this.field = field;
            random = new Random();
            foodSymbol = '*';
        }

        public void CreateFoodPosition()
        {
            Row = random.Next(1, field.Row - 1);
            Column = random.Next(1, field.Column - 1);
        }

        public void InitializeFood()
        {
            Console.BackgroundColor = ConsoleColor.Green;

            Draw(Row, Column, foodSymbol);

            Console.BackgroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, field.Row + 1);
        }
    }
}
