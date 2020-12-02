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
            //Gets the current scene index
            get
            {
                return _currentSceneIndex;
            }
        }

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        public static Scene GetScene(int index)
        //Returns the scene at the index of index
        {
            return _scenes[index];
        }

        public static Scene GetCurrentScene()
        {
            //Returns the current scene index
            return _scenes[_currentSceneIndex];
        }

        public static int AddScene(Scene scene)
        {
            //Function used for adding scenes

            //Temporary array for scenes set to a new scene with a scene's length + 1
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
            //Function used for removing scenes

            //Checks to see if there is a scene, if not return false
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
            //Returns whether the key is being held down
            return Raylib.IsKeyDown((KeyboardKey)key);
        }

        public static bool GetKeyPressed(int key)
        {
            //Returns whether the key is pressed once
            return Raylib.IsKeyPressed((KeyboardKey)key);
        }
        public Game()
        {
            //Creates a new scene at the index of 0
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
            //Creates a new console window for the game
            Raylib.InitWindow(1920, 1080, "Assessment Game");
            //Sets the new windows fps to the amount passed in
            Raylib.SetTargetFPS(60);
            //Makes the console cursor invisible
            Console.CursorVisible = false;
            //Create the console window's name
            Console.Title = "Assessment Game";

            //Creates a new scene
            Scene scene1 = new Scene();
            //Creates new actors
            Player actor1 = new Player(1, 1, Color.BLUE, ' ',ConsoleColor.Blue);
            Actor actor2 = new Actor(20, 10, '#', ConsoleColor.Red);
            Enemy actor3 = new Enemy(40, 10, Color.GREEN, ' ', ConsoleColor.Green);

            //Adds new actors to the scene
            //Actor1's properties
            scene1.AddActor(actor1);
            actor1.SetScale(2, 2);

            //Actor2's properties
            scene1.AddActor(actor2);
            actor2.SetScale(2, 2);

            //Actor3's Properties
            scene1.AddActor(actor3);
            actor3.SetScale(2, 2);


            //Creates a new starting scene variable
            int startingSceneIndex = 0;

            //Sets the created variable's value to adding scene1
            startingSceneIndex = AddScene(scene1);

            //Uses SetCurrentScene function to set the scene 
            //using the previously created variable
            SetCurrentScene(startingSceneIndex);
        }


        //Called every frame.
        public void Update(float deltaTime)
        {
            //If the scene's start function hasn't been called, calls it
            if (!_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();
            
            //Calls the scene's update function
            _scenes[_currentSceneIndex].Update(deltaTime);
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            //Begins drawing the actors to the screen, sets the background color, clears the console
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
            Console.Clear();

            //Calls the scene's draw function
            _scenes[_currentSceneIndex].Draw();

            Raylib.EndDrawing();
        }


        //Called when the game ends.
        public void End()
        {
            //Calls scene's end function
            _scenes[_currentSceneIndex].End();
        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            //Calls the start function
            Start();

            //While gameOver is not true and WindowShouldClose is not true runs the code
            while(!_gameOver && !Raylib.WindowShouldClose())
            {
                float deltaTime = Raylib.GetFrameTime();
                Update(deltaTime);
                Draw();
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
            }

            //Called when the game loop is finished
            End();
        }
    }
}
