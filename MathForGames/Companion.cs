using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Companion : Actor
    {
        private Sprite _sprite;

        public Companion(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
          : base(x, y, icon, color)
        {
            _sprite = new Sprite("Sprites/duck.png");
        }

        public Companion(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {
            _sprite = new Sprite("Sprites/duck.png");
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }

        public override void Draw()
        {
            _sprite.Draw(_globalTransform);
            base.Draw();
        }
    }
}
