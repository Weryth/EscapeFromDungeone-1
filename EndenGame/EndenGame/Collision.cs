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
    public class Collision
    {
        private Rectangle _playerRect = new Rectangle();
        private Rectangle _enemyRect = new Rectangle();

        private Texture2D _justTextureOfPlayer;
        private Texture2D _justTextureOfEnemy;

        private bool fIsCollision = false;

        private Vector2 _enemyPos;
        private Vector2 _playerPos;

        public void CollisionTakeTextureOfPlayer(Texture2D justTextureOfPlayer)
        {
            _justTextureOfPlayer = justTextureOfPlayer;
        }
        public void CollisionTakeTextureOfEnemy(Texture2D justTextureOfEnemy)
        {
            _justTextureOfEnemy = justTextureOfEnemy;
        }
        public void CollisionTakeTPositionOfPlayer(Vector2 playerPos)
        {
            _playerPos = playerPos;
        }
        public void CollisionTakeTPositionOfEnemy(Vector2 enemyPos)
        {
            _enemyPos = enemyPos;
        }

        public bool GiveBColl()
        {
            return fIsCollision;
        }
        public bool IsCollision()
        {
            _playerRect = new Rectangle((int)_playerPos.X-100, (int)_playerPos.Y, _justTextureOfPlayer.Width, _justTextureOfPlayer.Height);
            _enemyRect = new Rectangle((int)_enemyPos.X, (int)_enemyPos.Y, _justTextureOfEnemy.Width, _justTextureOfEnemy.Height);
            
            return _playerRect.Intersects(_enemyRect);


        }
    }
}
