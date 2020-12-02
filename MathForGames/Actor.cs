using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Actor
    {
        protected char _icon = ' ';
        private Vector2 _velocity = new Vector2();
        private Vector2 _acceleration = new Vector2();
        protected Matrix3 _globalTransform = new Matrix3();
        protected Matrix3 _localTransform = new Matrix3();
        private Matrix3 _translation = new Matrix3();
        private Matrix3 _rotation = new Matrix3();
        private Matrix3 _scale = new Matrix3();
        protected ConsoleColor _color;
        protected Color _rayColor;
        protected Actor _parent;
        protected Actor[] _children = new Actor[0];
        private float _maxSpeed = 5;
        private float _collisionRadius = 1f;
        
        public bool Started { get; private set; }

        public Vector2 Forward
        {
            get
            {
                return new Vector2(_globalTransform.m11, _globalTransform.m21);
            }
        }

        //Set functions for Translation, Rotation and Scale
        //Will set the values equal to the argument passed in
        public void SetTranslation(Vector2 position)
        {
            _translation = Matrix3.CreateTranslation(position);

        }

        public void SetRotation(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);
        }

        public void SetScale(float x, float y)
        {
            _scale = Matrix3.CreateScale(new Vector2(x, y));
        }

        //Using the translation, rotation, and scale
        //Finds the actor's transform
        public void UpdateTransform()
        {
            _localTransform = _translation * _rotation * _scale;

            if (_parent != null)
                _globalTransform = _parent._globalTransform * _localTransform;
            else
                _globalTransform = Game.GetCurrentScene().World * _localTransform;
        }

        //Used to check if multiple actors have collided
        public virtual bool CheckCollision(Actor other)
        {
            //if other is also the actor will not run the rest of function
            if (other == this)
            {
                return false;
            }

            //if not, checks the actor's radii and combines it
            //then checks the distance between their world position
            float combinedRadius = other._collisionRadius + _collisionRadius;
            float distance = (other.WorldPosition - WorldPosition).Magnitude;

            //if their combined radius is greater than the distance between them
            //return true, else return false
            if (combinedRadius > distance)
            {
                return true;
            }
            return false;
        }

        public virtual void OnCollision(Actor other)
        {
            //When called will execute listed code.
            other.SetRotation(2);
            Scene.RemoveActor(other);
        }

        public Vector2 WorldPosition
        {
            //Actors position in the world
            get
            {
                return new Vector2(_globalTransform.m13, _globalTransform.m23);
            }
        }

        public Vector2 LocalPosition
        {
            //Actors local position
            get
            {
                return new Vector2(_localTransform.m13, _localTransform.m23);
            }
            set
            {
                //Sets translation to an X Y value
                _translation.m13 = value.X;
                _translation.m23 = value.Y;
            }
        }

        public Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }

        //Constructors for actor
        public Actor()
        {
            LocalPosition = new Vector2();
            _velocity = new Vector2();
        }

        //Constructor with four arguments
        public Actor(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _rayColor = Color.WHITE;
            _icon = icon;
            _localTransform = new Matrix3();
            LocalPosition = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
        }

        //Constructor with five arguments
        public Actor(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : this(x, y, icon, color)
        {
            _rayColor = rayColor;
            _localTransform = new Matrix3();
        }

        //Functions for adding and removing childed actors
        public bool AddChild(Actor child)
        {
            if (child == null)
                return false;

            Actor[] tempArray = new Actor[_children.Length + 1];

            for (int i = 0; i < _children.Length; i++)
            {
                tempArray[i] = _children[i];
            }

            tempArray[_children.Length] = child;
            _children = tempArray;
            child._parent = this;
            return true;
        }

        public bool RemoveChild(Actor child)
        {
            bool childRemoved = false;

            if (child == null)
                return false;

            Actor[] tempArray = new Actor[_children.Length - 1];

            int j = 0;
            for (int i = 0; i < _children.Length; i++)
            {
                if (child != _children[i])
                {
                    tempArray[j] = _children[i];
                    j++;
                }
                else
                {
                    childRemoved = true;
                }
            }

            _children = tempArray;
            child._parent = null;
            return childRemoved;
        }

        protected Vector2 Acceleration
        {
            get => _acceleration;
            set => _acceleration = value;
        }
        public float MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
            set
            {
                _maxSpeed = value;
            }
        }

        public void Start()
        {
            Started = true;
        }

        public virtual void Update(float deltaTime)
        {
            UpdateTransform();

            Velocity += Acceleration;

            if (Velocity.Magnitude > MaxSpeed)
                Velocity = Velocity.Normalized * MaxSpeed;


            LocalPosition += _velocity * deltaTime;
        }

        public virtual void Draw()
        {
            Raylib.DrawText(_icon.ToString(), (int)(WorldPosition.X * 32), (int)(WorldPosition.Y * 32), 32, _rayColor);
            Raylib.DrawLine(
              (int)(WorldPosition.X * 32),
              (int)(WorldPosition.Y * 32),
              (int)((WorldPosition.X + Forward.X) * 32),
              (int)((WorldPosition.Y + Forward.Y) * 32),
              Color.WHITE
            );

            Console.ForegroundColor = _color;

            if (WorldPosition.X >= 0 && WorldPosition.X < Console.WindowWidth
                && WorldPosition.Y >= 0 && WorldPosition.Y < Console.WindowHeight)
            {
                Console.SetCursorPosition((int)WorldPosition.X, (int)WorldPosition.Y);
                Console.Write(_icon);
                Console.ForegroundColor = Game.DefaultColor;
            }
        }

        public void End()
        {

        }

    }
}
