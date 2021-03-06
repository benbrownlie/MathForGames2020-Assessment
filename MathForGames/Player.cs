﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Player : Actor
    {
        private float _speed;
        private Sprite _sprite;
        private float _health;
        Projectile bullet;

        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }
        public Player(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base (x, y, icon, color)
        {
            _sprite = new Sprite("/Sprites/dog.png");
        }

        public Player(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base (x, y, rayColor, icon, color)
        {
            _sprite = new Sprite("Sprites/dog.png");
        }

        public void CreateBullet(Projectile bullet)
        {
            Game.GetKeyPressed((int)KeyboardKey.KEY_SPACE);
            {
                bullet = new Projectile(Forward, LocalPosition + Forward, 5, 10, '0', ConsoleColor.Red);
            }
        }

        public override void Update(float deltaTime)
        {
            int xVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_A))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_D));

            int yVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_W))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_S));

            Acceleration = new Vector2(xVelocity, yVelocity);

            base.Update(deltaTime);
        }

        public override void Draw()
        {
            _sprite.Draw(_globalTransform);
            base.Draw();
        }
    }
}
