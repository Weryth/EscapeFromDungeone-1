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
    class Animation
    {
        //Создан для передачи текстуры в GameSpritesPerson в метод Update для Draw
        public KeyboardState ks;

        private Texture2D _textureIdle;
        private Texture2D _justTexture; // простая текстура без анимации

        private Rectangle _spriteFrameRect = new Rectangle();
        private EnumMove _animAction;

        private float _frameSpeed;

        private Vector2 _position;

        private float _time = 0f;
        //ректенгл
        private int _textureLeftConrner = 0;
        public void TakeFrameSpeed(float frameSpeed)
        {
            _frameSpeed = frameSpeed;
        }
        public void TakeIdle(Texture2D IdleSprites)
        {
            _textureIdle = IdleSprites;
        }
        public void TakeJustText(Texture2D JustText)
        {
            _justTexture = JustText;
        }
        public void TakePosition(Vector2 position)
        {
            _position = position;
        }
        public EnumMove GiveKeyboardAction()
        {
            return _animAction;
        }
        //Считывает кнопку с клавиатуры 
        public void Update(GameTime gameTime)
        {
            
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _animAction = EnumMove.RunRight;

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _animAction = EnumMove.RunLeft;

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                _animAction = EnumMove.Atack;
            }
            else
            {
                _animAction = EnumMove.Idle;
            }
            
            _time += gameTime.ElapsedGameTime.Milliseconds;
            if (_time < _frameSpeed)
            {
                return;
            }
            _time = 0;
            _spriteFrameRect = new Rectangle(_textureLeftConrner, 0, _justTexture.Width, _justTexture.Height);
            _textureLeftConrner += _justTexture.Width;

            if (_textureLeftConrner == _textureIdle.Width)
            {
                _textureLeftConrner = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textureIdle, _position, _spriteFrameRect, Color.White);
        }

    }
}
