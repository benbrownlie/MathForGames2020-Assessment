using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Enemy : Actor
    {
        private Actor _target;

        public Actor Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
          : base(x, y, icon, color)
        {

        }

        public Enemy(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {

        }

        public bool CheckTargetInSight(float maxAngle, float maxDistance)
        {
            if (Target == null)
                return false;

            Vector2 direction = Target.LocalPosition - LocalPosition;

            float distance = direction.Magnitude;

            float angle = (float)Math.Acos(Vector2.DotProduct(Forward, direction.Normalized));

            if (angle < maxAngle && distance <= maxDistance)
                return true;

            return false;
        }

        public void Start()
        {
            
        }

        public override void Update(float deltaTime)
        {
            if (CheckTargetInSight(5, 5))
            {

            }
            base.Update(deltaTime);
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
