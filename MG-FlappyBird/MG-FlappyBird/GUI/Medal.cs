using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG_FlappyBird.GUI
{
    class Medal
    {
        // FIELDS
        Texture2D texture;
        int level;

        Rectangle rectangle;
        Rectangle rectangleSource;

        float opacity;

        // CONSTRUCTOR
        public Medal(int _level, Point _position)
        {
            level = _level;

            texture = RessourcesManager.sprite;

            rectangleSource = new Rectangle(575 + level * 22, 113, 22, 22);
            rectangle = new Rectangle(_position.X, _position.Y, rectangleSource.Width * 3, rectangleSource.Height * 3);

            opacity = 0f;
        }

        // METHODS

        // UPDATE & DRAW
        public void Update(GameTime gameTime)
        {
            if (opacity <= 1f)
                opacity += 0.01f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, rectangleSource, new Color(Color.White, opacity), 0f, Vector2.Zero, SpriteEffects.None, 0f);
        }
    }
}
