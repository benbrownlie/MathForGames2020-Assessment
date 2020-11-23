using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Game
    {
        //Goal: Create a simple wave based shooter that adds more enemies as the waves progress.

        //Missing:
        //Player and enemies, player and enemy sprites.
        //Basic collision detection for enemies and walls 
        //(Example: If player shoots enemy detect hit and remove enemy, if enemy touches player gameover, if player hits wall don't move)
        //
        private static bool _gameOver = false;
        private static Scene[] _scenes;
        private static int _currentSceneIndex;
        private Sprite _sceneSprite;

        public static int CurrentSceneIndex
        {
            get
            {
                return _currentSceneIndex;
            }
        }

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        public static Scene GetScene(int index)
        {
            return _scenes[index];
        }

        public static Scene GetCurrentScene()
        {
            return _scenes[_currentSceneIndex];
        }

        public static int AddScene(Scene scene)
        {
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            for (int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            int index = _scenes.Length;
            tempArray[index] = scene;
            _scenes = tempArray;

            return index;
        }

        public static bool RemoveScene(Scene scene)
        {
            if (scene == null)
            {
                return false;
            }

            bool sceneRemoved = false;

            Scene[] tempArray = new Scene[_scenes.Length - 1];

            int j = 0;
            for (int i = 0; i < _scenes.Length; i++)
            {
                if (tempArray[i] != scene)
                {
                    tempArray[i] = _scenes[j];
                    j++;
                }
                else
                {
                    sceneRemoved = true;
                }
            }

            if (sceneRemoved)
                _scenes = tempArray;

            return sceneRemoved;
        }

        public static void SetCurrentScene(int index)
        {
            if (index < 0 || index >= _scenes.Length)
                return;

            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();

            _currentSceneIndex = index;
        }

        public static bool GetKeyDown(int key)
        {
            return Raylib.IsKeyDown((KeyboardKey)key);
        }

        public static bool GetKeyPressed(int key)
        {
            return Raylib.IsKeyPressed((KeyboardKey)key);
        }
        public Game()
        {
            _scenes = new Scene[0];
        }

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

            Console.CursorVisible = false;
            Console.Title = "Assessment Game";

            Scene scene1 = new Scene();
            Player actor1 = new Player(0, 0, '@',ConsoleColor.Blue);
            Actor actor2 = new Actor(5, 5, '#', ConsoleColor.Red);

            scene1.AddActor(actor1);
            scene1.AddActor(actor2);

            int startingSceneIndex = 0;

            startingSceneIndex = AddScene(scene1);

            SetCurrentScene(startingSceneIndex);
        }


        //Called every frame.
        public void Update(float deltaTime)
        {
            if (!_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();

            _scenes[_currentSceneIndex].Update(deltaTime);
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);
            Console.Clear();
            _scenes[_currentSceneIndex].Draw();

            Raylib.EndDrawing();
        }


        //Called when the game ends.
        public void End()
        {
            _scenes[_currentSceneIndex].End();
        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while(!_gameOver && !Raylib.WindowShouldClose())
            {
                float deltaTime = Raylib.GetFrameTime();
                Update(deltaTime);
                Draw();
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
            }

            End();
        }
    }
}
