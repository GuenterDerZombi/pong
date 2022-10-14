using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.KeyboardKey;
using static Raylib_cs.Color;

namespace PongGame
{
    public class Program
    {
        public static int Main()
        {
            // Initialization
            //-------------------------------------------------------------
            const int screenWidth = 800;
            const int screenHeight = 400;
            const int screenOneFourth = (int) (screenWidth * 0.25);
            const int screenThreeFourth = (int) (screenWidth * 0.75);;
            const string title = "Pong";
            
            InitWindow(screenWidth, screenHeight, title);

            Vector2 ballPosition = new Vector2((float) screenWidth / 2, (float) screenHeight / 2);

            int playerPosiotionA = 20;
            int playerPosiotionB = 20;
            int paddleHeight = 100;
            
            int scoreA, scoreB;
            scoreA = 0;
            scoreB = 0;
            
            SetTargetFPS(60);
            //------------------------------------------------------------
            
            
            // Main game loop
            while (!WindowShouldClose())
            {
                // Update
                //--------------------------------------------------------
                if (IsKeyDown(KEY_S) && (playerPosiotionA + paddleHeight) < screenHeight)
                    playerPosiotionA += 2;
                if (IsKeyDown(KEY_W) && playerPosiotionA > 0)
                    playerPosiotionA -= 2;

                if (IsKeyDown(KEY_DOWN) && (playerPosiotionB + paddleHeight) < screenHeight)
                    playerPosiotionB += 2;
                if (IsKeyDown(KEY_UP) && playerPosiotionB  > 0)
                    playerPosiotionB -= 2;
                    //--------------------------------------------------------
                
                // Draw
                //--------------------------------------------------------
                BeginDrawing();
                ClearBackground(Color.BLACK);
                DrawText(scoreA.ToString(), screenOneFourth, 12, 50, Color.WHITE);
                DrawText(scoreB.ToString(), screenThreeFourth, 12, 50, Color.WHITE);
                
                DrawRectangle(10, playerPosiotionA, 10, paddleHeight, Color.WHITE);                              // Player A
                DrawRectangle(780, playerPosiotionB, 10, paddleHeight, Color.WHITE);                             // Player B

                DrawCircleV(ballPosition, 10, MAROON);
                
                EndDrawing();
                //----------------------------------------------------------
            }
            Raylib.CloseWindow();
            
            return 0;
        }
    }
}