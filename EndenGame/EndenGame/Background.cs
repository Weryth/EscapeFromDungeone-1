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
    class Background
    {
        private Texture2D _Background;

        public void TakeBackground(Texture2D BackgroundText)
        {
            _Background = BackgroundText;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_Background,
                Vector2.Zero,
                null,
                Color.White);
        }
    }
}
