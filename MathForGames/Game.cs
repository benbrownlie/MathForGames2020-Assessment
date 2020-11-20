using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Raylib_cs;

namespace MathForGames
{
    class Game
    {
        //Goal: Create a simple wave based shooter that adds more enemies as the waves progress.

        //Missing:
        //Player and enemies, player and enemy sprites. Scene for actors to exist in.
        //Basic collision detection for enemies and walls 
        //(Example: If player shoots enemy detect hit and remove enemy, if enemy touches player gameover, if player hits wall don't move)
        //
        private static bool _gameOver = false;

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }


        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            Raylib.InitWindow(1920, 1080, "Assessment Game");
            Raylib.SetTargetFPS(60);

        }


        //Called every frame.
        public void Update()
        {

        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {

        }


        //Called when the game ends.
        public void End()
        {

        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while(!_gameOver)
            {
                Update();
                Draw();
            }

            End();
        }
    }
}
