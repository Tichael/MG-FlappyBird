using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG_FlappyBird.Menu
{
    public abstract class MenuBase
    {
        // Fields
        protected Texture2D sprite;

        Rectangle background;
        Rectangle backgroundSource;

        Rectangle ground;
        Rectangle groundSource;

        // Constructor
        public MenuBase()
        {
            sprite = RessourcesManager.sprite;
            backgroundSource = new Rectangle(0, 0, 552, 256);
            background = new Rectangle(0, 0, backgroundSource.Width * 2, backgroundSource.Height * 2);
            groundSource = new Rectangle(0, 256, 553, 56);
            ground = new Rectangle(0, Game1.screenHeight - groundSource.Height * 2, groundSource.Width * 2, groundSource.Height * 2);
        }

        // Methods
        private void BackgroundMovement()
        {
            background.X--;
            if (background.X <= -276)
                background.X = 0;
        }

        private void GroundMovement()
        {
            ground.X -= 2;
            if (ground.X <= -14)
                ground.X = 0;
        }

        // Update & Draw
        public virtual void Update(GameTime gameTime)
        {
            BackgroundMovement();
            GroundMovement();
        }
        
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, background, backgroundSource, Color.White);
            spriteBatch.Draw(sprite, ground, groundSource, Color.White);
        }
    }
}
