using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Snake : Point
    {
        private const int StartSnakeRow = 3;
        private const int StartSnakeColumn = 3;
        private const int StartSnakeLength = 6;

        private const char SnakeSymbol = '\u25CF';

        private Food food;

        private Queue<Point> snake;
        private Field field;

        private int nextRow;
        private int nextColumn;


        public Snake(Field field) 
            : base(StartSnakeRow, StartSnakeColumn)
        {
            snake = new Queue<Point>();
            this.field = field;

            this.food = new Food(field);

            CreateSnake();
            food.CreateFoodPosition();
            food.InitializeFood();
        }

        public Queue<Point> GetSnakePoints
            => snake;

        public bool IsMoving(Point direction)
        {
            Point snakeHead = snake.Last();

            GetNextDirection(direction, snakeHead);

            bool isPartOfSnake = snake
                .Any(x => x.Row == nextRow && x.Column == nextColumn);

            if (isPartOfSnake)
            {
                return false;
            }

            Point newHead = new Point(nextRow, nextColumn);

            bool isFieldHit = field.IsPointOfTheField(newHead);

            if (isFieldHit)
            {
                return false;
            }

            snake.Enqueue(newHead);
            newHead.Draw(SnakeSymbol);

            if (food.IsFoodPoint(newHead))
            {
                Eat(direction, newHead);
            }

            Point tail = snake.Dequeue();
            tail.Draw(' ');

            return true;
        }

        private void Eat(Point direction, Point newHead)
        {
            snake.Enqueue(new Point(nextRow, nextColumn));
            GetNextDirection(direction, newHead);

            food.CreateFoodPosition();
            food.InitializeFood();
        }

        private void CreateSnake()
        {
            for (int col = StartSnakeColumn; col < StartSnakeLength + 3; col++)
            {
                snake.Enqueue(new Point(StartSnakeRow, col));

                //Draw(StartSnakeRow, col, SnakeSymbol);

                //Console.SetCursorPosition(0, field.Row + 1);
            }
        }

        private void GetNextDirection(Point direction, Point snakeHead)
        {
            nextRow = snakeHead.Row + direction.Row;
            nextColumn = snakeHead.Column + direction.Column;
        }
    }
}
