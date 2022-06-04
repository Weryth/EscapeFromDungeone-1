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
    //Создает необходимого для игрока персонажа
    class GameSpritesPerson
    {
        private Texture2D _justTexture;
        private Texture2D _IdleSpritesTexture;
        private Texture2D _RunRightTexture;
        private Texture2D __RunBackTexture;
        private Texture2D _AtackTexture;

        private Texture2D _textureForDraw;

        private Vector2 _position;
        //Объявляем классы
        private Movement _move = new Movement();


        private Animation _animIdle = new Animation();
        private Animation _animRunRight = new Animation();
        private Animation _animRunBack = new Animation();
        private Animation _animAtack = new Animation();


        private bool IsCollision = false;

        //Объект управляемый?
        private bool _isUseble = true;

        private EnumMove _action;
        //Берем информацию из банка
        public void TakeJustTexture(Texture2D justTexture)
        {
            _justTexture = justTexture;
        }
        public void TakeAtackTexture(Texture2D AtackTexture)
        {
            _AtackTexture = AtackTexture;
        }
        public void TakeRunRightTexture(Texture2D RunRightTexture)
        {
            _RunRightTexture = RunRightTexture;
        }
        public void TakeRunBackTexture(Texture2D _RunBackTexture)
        {
            __RunBackTexture = _RunBackTexture;
        }
        public void IdleSpritesTexture(Texture2D IdleSpritesTexture)
        {
            _IdleSpritesTexture = IdleSpritesTexture;
        }
        public void IsUseble(bool IsUsedle)
        {
            _isUseble = IsUsedle;
        }

        public void TakeCollisionBool(bool fIsCollision)
        {
            IsCollision = fIsCollision;
        }
        public Vector2 GivePos()
        {
            return _position;
        }
        
        public void Update(GameTime gameTime)
        {


            //Работаем с классом Movement
            
            if (_isUseble && IsCollision==false)
            {

                _move.TakePosition(_position); //даем позицию
                _position = _move.KeyboardMove(); //принимаем новую
            }
            if (_isUseble == false)
            {
                _position.X = 1000;
                _position.Y = 500;
            }
            if (IsCollision == true)
            {
                _position.X -= 1;
            }
            //берем Idle Animation
            _animIdle.TakeIdle(_IdleSpritesTexture); //даем спрайтовую анимацию
            _animIdle.TakeJustText(_justTexture); //даем обычную текстуру объекта
            _animIdle.TakePosition(_position); // даем позицию
            _animIdle.TakeFrameSpeed(130);
            _animIdle.Update(gameTime);
            _action = _animIdle.GiveKeyboardAction();
            //Берем бег
            _animRunRight.TakeIdle(_RunRightTexture); //даем спрайтовую анимацию
            _animRunRight.TakeJustText(_justTexture); //даем обычную текстуру объекта
            _animRunRight.TakePosition(_position); // даем позицию
            _animRunRight.TakeFrameSpeed(60);
            _animRunRight.Update(gameTime);
            //Бег назад
            _animRunBack.TakeIdle(__RunBackTexture); //даем спрайтовую анимацию
            _animRunBack.TakeJustText(_justTexture); //даем обычную текстуру объекта
            _animRunBack.TakePosition(_position); // даем позицию
            _animRunBack.TakeFrameSpeed(60);
            _animRunBack.Update(gameTime);
            //Атака
            _animAtack.TakeIdle(_AtackTexture);
            _animAtack.TakeJustText(_justTexture); //даем обычную текстуру объекта
            _animAtack.TakePosition(_position); // даем позицию
            _animAtack.TakeFrameSpeed(90);
            _animAtack.Update(gameTime);

            

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_isUseble)
            {
                switch (_action)
                {
                    case EnumMove.Idle:
                        _animIdle.Draw(spriteBatch);
                        break;
                    case EnumMove.RunRight:
                        _animRunRight.Draw(spriteBatch);
                        break;
                    case EnumMove.RunLeft:
                        _animRunBack.Draw(spriteBatch);
                        break;
                    case EnumMove.Jump:
                        break;
                    case EnumMove.Atack:
                        _animAtack.Draw(spriteBatch);
                        break;
                    default:
                        break;
                }
            }
            else if (_isUseble == false)
            {
                _animIdle.Draw(spriteBatch);
            }
            
            
            //_anim.DrawIdle(spriteBatch);
            /*spriteBatch.Draw(
                _textureForDraw, // текстура
                _position, //Позиция
                null, //rect обрезания текстуры
                Color.White); //цвет*/
        }


    }
}
