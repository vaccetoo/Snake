namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Field field = new Field(26, 50);

            Snake snake = new Snake(field);

            Engine engine = new Engine(field, snake);
            engine.Run();
        }
    }
}
