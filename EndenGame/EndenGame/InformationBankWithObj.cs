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
    public class InformationBankWithObj
    {
        private bool IsCollision;
        //Банк текстур
        private Texture2D _JustText;
        private Texture2D _IdleText;
        private Texture2D _Background;
        private Texture2D _RunRightText;
        private Texture2D _RunBackText;
        private Texture2D _RoomGround;
        private Texture2D _CharacterAtack;

        private Texture2D _GhoulJustTexture;
        private Texture2D _GhoulIdleTexture;
        private Texture2D _GhoulRunLeftTexture;
        private Texture2D _GhoulRunRightTexture;
        private Texture2D _GhoulAtack;
        //Объявление классов

        private Background _background = new Background();
        private Background _roomGround = new Background();

        private GameSpritesPerson Player = new GameSpritesPerson(); //игровой персонаж
        private GameSpritesPerson Enemy = new GameSpritesPerson(); // враг

        private Collision Collis = new Collision();

        //Взять текстуры из Game1

        //enemy load
        public void TakeGhoulRunLeftTexture(Texture2D GhoulRunLeftTexture)
        {
            _GhoulRunLeftTexture = GhoulRunLeftTexture;
        }
        public void TakeGhoulJustText(Texture2D justTexture)
        {
            _GhoulJustTexture = justTexture;
        }
        public void TakeGhoulIdleText(Texture2D IdleText)
        {
            _GhoulIdleTexture = IdleText;
        }
        public void TakeGhoulRunRightTexture(Texture2D GhoulRunRightTexture)
        {
            _GhoulRunRightTexture = GhoulRunRightTexture;
        }
        public void TakeAtackTexture(Texture2D AtackTexture)
        {
            _CharacterAtack = AtackTexture;
        }

        //Player load
        public void TakeJustText(Texture2D justTexture)
        {
            _JustText = justTexture;
        }
        public void TakeRunRightText(Texture2D RunRightText)
        {
            _RunRightText = RunRightText;
        }
        public void TakeRunBackText(Texture2D RunBackText)
        {
            _RunBackText = RunBackText;
        }
        public void TakeIdleText(Texture2D IdleText)
        {
            _IdleText = IdleText;
        }
        public void TakeBackground(Texture2D Background)
        {
            _Background = Background;
        }
        public void TakeRoomground(Texture2D Roomground)
        {
            _Background = Roomground;
        }
        public void TakeRoomGround(Texture2D RoomGround)
        {
            _RoomGround = RoomGround;
        }
        public void TakeEnemyAtack(Texture2D AtackTexture)
        {
            _GhoulAtack = AtackTexture;
        }
        //Отдаем информацию классам
        public void LoadContent()
        {
            _background.TakeBackground(_Background);
            _roomGround.TakeBackground(_RoomGround);

            //отдаем текстуры объекту Player
            Player.IsUseble(true);
            Player.TakeJustTexture(_JustText);
            Player.IdleSpritesTexture(_IdleText);
            Player.TakeRunRightTexture(_RunRightText);
            Player.TakeRunBackTexture(_RunBackText);
            Player.TakeAtackTexture(_CharacterAtack);
            //Отдаем текстуры Enemy
            Enemy.IsUseble(false);
            Enemy.TakeJustTexture(_GhoulJustTexture);
            Enemy.IdleSpritesTexture(_GhoulIdleTexture);
            Enemy.TakeRunBackTexture(_GhoulRunLeftTexture);
            Enemy.TakeRunRightTexture(_GhoulRunRightTexture);
            Enemy.TakeAtackTexture(_GhoulAtack);

            //Collision
            Collis.CollisionTakeTextureOfEnemy(_GhoulJustTexture);
            Collis.CollisionTakeTextureOfPlayer(_JustText);
            
        }


        //Игровые методы
        public void Update(GameTime gameTime)
        {
            Collis.CollisionTakeTPositionOfEnemy(Enemy.GivePos());
            Collis.CollisionTakeTPositionOfPlayer(Player.GivePos());

            IsCollision = Collis.IsCollision();
            Player.TakeCollisionBool(IsCollision);
            IsCollision = false;
            Player.Update(gameTime);
            Enemy.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            _background.Draw(spriteBatch);

            Player.Draw(spriteBatch);
            Enemy.Draw(spriteBatch);

            _roomGround.Draw(spriteBatch);
        }

    }
}
