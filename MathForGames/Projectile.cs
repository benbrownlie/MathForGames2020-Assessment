using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Projectile : Actor
    {
        private float _speed;
        private float _damage;
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

        public Projectile(float x, float y, float speedVal, float damageVal, char icon, ConsoleColor color = ConsoleColor.White)
            : base (x, y, icon, color)
        {
            _bulletSprite = new Sprite("Sprites/projectile.png");
            _damage = damageVal;
            _speed = speedVal;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }
    }
}
