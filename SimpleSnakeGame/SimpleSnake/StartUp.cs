namespace SimpleSnake
{
    using SimpleSnake.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Field field = new Field(25, 50);

            Food food = new Food(field);
            food.CreateFoodPosition();
            food.InitializeFood();
        }
    }
}
