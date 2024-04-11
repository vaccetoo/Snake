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

            Field field = new Field(25, 50);

            Snake snake = new Snake(field);

            Engine engine = new Engine(field, snake);
            engine.Run();

            //TODO: When hit the bottom row continuing moving... FIX
            //      Global problem when hitting the wall
            //      Add points
            // Check for more problems

        }
    }
}
