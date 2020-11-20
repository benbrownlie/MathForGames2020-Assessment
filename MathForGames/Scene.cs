using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Scene
    {
        private Actor[] _actors;

        public Scene()
        {
            _actors = new Actor[0];
        }

        public void AddActor(Actor actor)
        {
            Actor[] appendedArray = new Actor[_actors.Length + 1];
            for (int i = 0; i < _actors.Length; i++)
            {
                 appendedArray[i] = _actors[i];
            }
            appendedArray[_actors.Length] = actor;
            _actors = appendedArray;
        }

        public bool RemoveActor(int index)
        {
            if (index < 0 || index >= _actors.Length)
            {
                return false;
            }

            bool actorRemoved = false;

            Actor[] newArray = new Actor[_actors.Length - 1];
            int j = 0;
            for (int i = 0; i < _actors.Length; i++)
            {
                if (i != index)
                {
                    newArray[j] = _actors[i];
                    j++;
                }
                else
                {
                    actorRemoved = true;
                    //if (_actors[i].Started)
                        _actors[i].End();
                }
            }
 
            _actors = newArray;
            return actorRemoved;
        }

        public bool RemoveActor(Actor actor)
        {
            if (actor == null)
            {
                return false;
            }

            bool actorRemoved = false;
            Actor[] newArray = new Actor[_actors.Length - 1];
            int j = 0;
            for (int i = 0; i < _actors.Length; i++)
            {
                if (actor != _actors[i])
                {
                    newArray[j] = _actors[i];
                    j++;
                }
                else
                {
                    actorRemoved = true;
                    //if (actor.Started)
                        actor.End();
                }
            }

            _actors = newArray;

            return actorRemoved;

        }

        public void Start()
        {

        }

        public void Update()
        {

        }

        public void Draw()
        {

        }

        public void End()
        {

        }
    }
}
