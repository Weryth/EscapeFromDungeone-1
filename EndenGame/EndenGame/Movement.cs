using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EndenGame
{
    class Movement
    {
        private Vector2 _position;

        public KeyboardState ks;

        private int _force = 0;
        private EnumMove _action;
        private int _time;

        private float _gameGravity;
        const float a = 9.7f;

        public void TakePosition(Vector2 pos)
        {
            _position = pos;
        }

        public Vector2 KeyboardMove()
        {
            //Проверна на действие
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _action = EnumMove.RunRight;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _action = EnumMove.RunLeft;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                _action = EnumMove.Atack;
                
            }
            //Выбор действий
            switch (_action)
            {
                case EnumMove.Idle:
                    break;
                case EnumMove.RunRight:
                    while (_force < 3)
                    {
                        _force++;
                        _position.X += _force;
                    }
                    while (_force > 0)
                    {
                        _force--;
                        _position.X += _force;
                    }
                    break;
                case EnumMove.RunLeft:
                    while (_force < 3)
                    {
                        _force++;
                        _position.X -= _force;
                    }
                    while (_force > 0)
                    {
                        _force--;
                        _position.X -= _force;
                    }
                    break;
                case EnumMove.Jump:

                    break;
                case EnumMove.Atack:

                    break;
                default:
                    break;
            }
            _action = EnumMove.Idle;


            //Типа физика...
            if (_position.Y < 500)
            {
                _gameGravity = 10;
                _position.Y += _gameGravity;
            }
            

            return _position;
        }
    }
}
