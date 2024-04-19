using SimpleSnake.Core.Interfaces;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
        private readonly Point[] pointDirections;

        private Direction direction;

        private readonly Snake snake;
        private readonly Field field;

        private float sleepTime;

        private const string GameOverMassage = "GAME OVER";
        private const string RestartMassage = "Would you like to play again y/n ?";

        public Engine(Field field, Snake snake)
        {
            pointDirections = new Point[4];

            pointDirections[0] = new Point(0, 1);
            pointDirections[1] = new Point(0, -1);
            pointDirections[2] = new Point(1, 0);
            pointDirections[3] = new Point(-1, 0);

            this.field = field; 
            this.snake = snake;

            sleepTime = 100;
        }
        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = snake.IsMoving(pointDirections[(int)direction]);

                if (!isMoving)
                {
                    AskUserToRestart();
                }

                sleepTime -= 0.01f;
                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserToRestart()
        {
            Console.SetCursorPosition(field.Column / 2 - GameOverMassage.Length / 2, field.Row / 2);
            Console.Write(GameOverMassage);
            Console.SetCursorPosition(field.Column / 2 - RestartMassage.Length / 2, field.Row / 2 + 1);
            Console.Write(RestartMassage);

            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }

            Console.SetCursorPosition(field.Column , field.Row );
            Environment.Exit(0);
        }


        private void GetNextDirection()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left; 
                }
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }
    }
}
