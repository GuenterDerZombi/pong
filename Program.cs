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
            // Window
            const int screenWidth = 800;
            const int screenHeight = 400;
            const int screenOneFourth = (int) (screenWidth * 0.25);
            const int screenThreeFourth = (int) (screenWidth * 0.75);;
            const string title = "Pong";
            
            InitWindow(screenWidth, screenHeight, title);
            //--------------------------------------------------------------
            
            // Ball
            Vector2 ballPosition = new Vector2((float) screenWidth / 2, (float) screenHeight / 2);
            Vector2 ballSpeed = new Vector2(5.0f, 4.0f);
            int ballRadius = 10;
            //--------------------------------------------------------------
            
            // Paddle
            int paddleHeight = 100;
            int paddleWidth = 10;
            int paddleSpeed = 5;
            Rectangle leftPaddle = new Rectangle(10, 20, paddleWidth, paddleHeight);
            Rectangle rightPaddle = new Rectangle(780, 20, paddleWidth, paddleHeight);
            
            //--------------------------------------------------------------
            
            // Score
            int scoreA, scoreB;
            scoreA = 0;
            scoreB = 0;
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
                    if ((ballPosition.X >= (GetScreenWidth() - ballRadius)) || (ballPosition.X <= ballRadius) || CheckCollisionCircleRec(ballPosition, ballRadius, leftPaddle) || CheckCollisionCircleRec(ballPosition, ballRadius, rightPaddle))
                        ballSpeed.X *= -1.0f;
                    if ((ballPosition.Y >= (GetScreenHeight() - ballRadius)) || (ballPosition.Y <= ballRadius))
                        ballSpeed.Y *= -1.0f;
                    
                    // TODO: Check if ball is out of play and change the score.
                    
                    
                    // check paddle collision
                    if (IsKeyDown(KEY_S) && (leftPaddle.y + paddleHeight) < screenHeight)
                        leftPaddle.y += paddleSpeed;
                    if (IsKeyDown(KEY_W) && leftPaddle.y > 0)
                        leftPaddle.y -= paddleSpeed;
                    if (IsKeyDown(KEY_DOWN) && (rightPaddle.y + paddleHeight) < screenHeight)
                        rightPaddle.y += paddleSpeed;
                    if (IsKeyDown(KEY_UP) && rightPaddle.y  > 0)
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
                ClearBackground(Color.BLACK);
                DrawText(scoreA.ToString(), screenOneFourth, 12, 50, Color.WHITE);
                DrawText(scoreB.ToString(), screenThreeFourth, 12, 50, Color.WHITE);
                
                DrawRectangleRec(leftPaddle, WHITE);
                DrawRectangleRec(rightPaddle, WHITE);
                
                DrawCircleV(ballPosition, ballRadius, MAROON);

                
                // On pause, we draw a blinking message
                if (pause && ((framesCounter / 30) % 2) == 0)
                {
                    DrawText("PAUSED", 350, 200, 30, GRAY);
                }
                
                EndDrawing();
                //----------------------------------------------------------
            }
            CloseWindow();

            return 0;
        }
    }
}