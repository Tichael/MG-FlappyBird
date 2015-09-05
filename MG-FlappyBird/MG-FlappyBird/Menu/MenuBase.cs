using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG_FlappyBird.Menu
{
    class MenuBase
    {
        // Fields
        Texture2D sprite;
        Rectangle background;
        Rectangle backgroundSource;

        // Constructor
        public MenuBase()
        {
            sprite = RessourcesManager.sprite;
            background = new Rectangle(0, 0, 1104, 512);
            backgroundSource = new Rectangle(0, 0, 552, 256);
        }

        // Methods
        private void Background()
        {
            background.X--;
            if (background.X <= -276)
                background.X = 0;
        }

        // Update & Draw
        public void Update(GameTime gameTime)
        {
            Background();
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, background, backgroundSource, Color.White);
        }
    }
}
