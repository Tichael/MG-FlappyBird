using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG_FlappyBird.GUI
{
    class Pipe
    {
        // FIELDS
        Texture2D texture;
        Rectangle pipeUp;
        Rectangle pipeDown;
        Rectangle pipeSource;
        int holeSize;
        int holePosition;
        Random rand;

        // CONSTRUCTORS
        public Pipe(int _startPosition)
        {
            holeSize = 100;
            texture = RessourcesManager.sprite;
            pipeSource = new Rectangle(652, 191, 26, 121);
            rand = new Random();
            holePosition = rand.Next(20, 100);
            pipeDown = new Rectangle(Game1.screenWidth + _startPosition, holePosition + holeSize * 2, pipeSource.Width * 2, pipeSource.Height * 2);
            pipeUp = new Rectangle(Game1.screenWidth + _startPosition, holePosition - pipeSource.Height, pipeSource.Width * 2, pipeSource.Height * 2);
        }

        // METHODS
        private void MovePipe()
        {
            pipeDown.X -= 2;
            pipeUp.X -= 2;

            if (pipeDown.X <= 0 - pipeDown.Width)
            {
                pipeDown.X = Game1.screenWidth;
                pipeUp.X = Game1.screenWidth;
                holePosition = rand.Next(20, 100);
                pipeDown.Y = holePosition + holeSize * 2;
                pipeUp.Y = holePosition - pipeSource.Height;
            }
        }

        // UPDATE & DRAW
        public void Update(GameTime gameTime)
        {
            MovePipe();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pipeDown, pipeSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.8f);
            spriteBatch.Draw(texture, pipeUp, pipeSource, Color.White, 0f, Vector2.Zero, SpriteEffects.FlipVertically, 0.8f);
        }
    }
}
