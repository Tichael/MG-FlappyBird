using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG_FlappyBird.GUI
{
    class Button
    {
        // FIELDS
        Texture2D texture;
        Rectangle button;
        Rectangle buttonSource;

        // CONSTRUCTOR
        public Button(Texture2D _texture, Point _position, Rectangle _buttonSource)
        {
            texture = _texture;
            buttonSource = _buttonSource;
            button = new Rectangle(_position.X - buttonSource.Width * 3 / 2, _position.Y - buttonSource.Height * 3 / 2, buttonSource.Width * 3, buttonSource.Height * 3);
        }

        // METHODS

        // UPDATE & DRAW
        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, button, buttonSource, Color.White);
        }
    }
}
