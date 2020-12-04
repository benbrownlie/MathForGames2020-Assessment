using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Projectile : Actor
    {
        private float _speed = 5;
        private float _damage = 10;
        private Sprite _bulletSprite;

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

        public Projectile(Vector2 direction, Vector2 origin, float speedVal, float damageVal, char icon, ConsoleColor color = ConsoleColor.White)
            : base (origin.X, origin.Y, icon, color)
        {
            _bulletSprite = new Sprite("Sprites/projectile.png");
            _damage = damageVal;
            _speed = speedVal;
            //Forward = direction;
        }

        public override bool CheckCollision(Actor other)
        {
            return base.CheckCollision(other);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }
    }
}
