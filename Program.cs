#region

using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.KeyboardKey;
using static Raylib_cs.Color;

#endregion

namespace RayLib;

public static class Program
{
    public static int Main()
    {
        // Initialization
        //-------------------------------------------------------------
        // Window
        const int screenWidth = 800;
        const int screenHeight = 400;
        const int screenOneFourth = (int) (screenWidth * 0.25);
        const int screenThreeFourth = (int) (screenWidth * 0.75);
        const string title = "Pong";

        InitWindow(screenWidth, screenHeight, title);
        //--------------------------------------------------------------

        // Ball
        var ballPosition = new Vector2((float) screenWidth / 2, (float) screenHeight / 2);
        var ballSpeed = new Vector2(5.0f, 4.0f);
        const int ballRadius = 10;
        //--------------------------------------------------------------

        // Paddle
        const int paddleHeight = 100;
        const int paddleWidth = 10;
        const int paddleSpeed = 5;
        var leftPaddle = new Rectangle(10, 20, paddleWidth, paddleHeight);
        var rightPaddle = new Rectangle(780, 20, paddleWidth, paddleHeight);

        //--------------------------------------------------------------

        // Score
        int leftScore = 0, rightScore = 0;
        //--------------------------------------------------------------

        // Menu
        bool pause = false;
        int framesCounter = 0;
        //--------------------------------------------------------------

        SetTargetFPS(60);
        //--------------------------------------------------------------


        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //--------------------------------------------------------
            if (IsKeyPressed(KEY_SPACE))
                pause = !pause;

            if (!pause)
            {
                ballPosition.X += ballSpeed.X;
                ballPosition.Y += ballSpeed.Y;

                // Check ball collision
                if (ballPosition.X >= GetScreenWidth() - ballRadius || ballPosition.X <= ballRadius ||
                    CheckCollisionCircleRec(ballPosition, ballRadius, leftPaddle) ||
                    CheckCollisionCircleRec(ballPosition, ballRadius, rightPaddle))
                    ballSpeed.X *= -1.0f;
                if (ballPosition.Y >= GetScreenHeight() - ballRadius || ballPosition.Y <= ballRadius)
                    ballSpeed.Y *= -1.0f;
                
                if (ballPosition.X >= GetScreenWidth() - ballRadius)
                {
                    ballPosition.X = screenHeight / 2;
                    ballPosition.Y = screenHeight / 2;
                    leftScore += 1;
                    pause = true;
                }

                if (ballPosition.X <= ballRadius)
                {
                    ballPosition.X = screenWidth / 2;
                    ballPosition.Y = screenHeight / 2;
                    rightScore += 1;
                    pause = true;
                }

                // check paddle collision
                if (IsKeyDown(KEY_S) && leftPaddle.y + paddleHeight < screenHeight)
                    leftPaddle.y += paddleSpeed;
                if (IsKeyDown(KEY_W) && leftPaddle.y > 0)
                    leftPaddle.y -= paddleSpeed;
                if (IsKeyDown(KEY_DOWN) && rightPaddle.y + paddleHeight < screenHeight)
                    rightPaddle.y += paddleSpeed;
                if (IsKeyDown(KEY_UP) && rightPaddle.y > 0)
                    rightPaddle.y -= paddleSpeed;
            }
            else
            {
                framesCounter += 1;
            }
            //--------------------------------------------------------

            // Draw
            //--------------------------------------------------------
            BeginDrawing();
            DrawFPS(10, 10);
            ClearBackground(BLACK);
            DrawText(leftScore.ToString(), screenOneFourth, 12, 50, WHITE);
            DrawText(rightScore.ToString(), screenThreeFourth, 12, 50, WHITE);

            DrawRectangleRec(leftPaddle, WHITE);
            DrawRectangleRec(rightPaddle, WHITE);

            DrawCircleV(ballPosition, ballRadius, MAROON);


            // On pause, we draw a blinking message
            if (pause && framesCounter / 30 % 2 == 0) DrawText("PAUSED", 350, 200, 30, GRAY);

            EndDrawing();
            //----------------------------------------------------------
        }

        CloseWindow();

        return 0;
    }
}