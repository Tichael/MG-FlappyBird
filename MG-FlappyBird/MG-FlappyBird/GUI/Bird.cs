using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG_FlappyBird.GUI
{
    class Bird
    {
        // FIELDS
        Texture2D texture;
        Rectangle rectangle;
        Rectangle sourceRectangle;

        // CONSTRUCTOR
        public Bird()
        {
            texture = RessourcesManager.sprite;
            sourceRectangle = new Rectangle(558, 119, 17, 12);
            rectangle = new Rectangle(Game1.screenWidth / 2 - sourceRectangle.Width, Game1.screenHeight / 2 - sourceRectangle.Height, sourceRectangle.Width * 2, sourceRectangle.Height * 2);
        }

        // METHODS

        // UPDATE & DRAW
        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, sourceRectangle, Color.White);
        }
    }
}
