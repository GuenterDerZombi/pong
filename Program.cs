using Raylib_cs;

namespace PongGame
{
    static class Program
    {
        public static void Main()
        {
            const int screenWidth = 800;
            const int screenHeight = 400;
            const string title = "Pong";
            int scoreA, scoreB;
            Raylib.InitWindow(screenWidth, screenHeight, title);

            scoreA = 0;
            scoreB = 0;

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                Raylib.DrawText(scoreA.ToString(), (screenWidth / 2) - 10, 12, 20, Color.BLACK);
                Raylib.DrawText(scoreB.ToString(), (screenWidth / 2) + 10, 12, 20, Color.BLACK);
               
                Raylib.EndDrawing();
                
            }
            Raylib.CloseWindow();
        }
    }
}