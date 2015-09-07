using MG_FlappyBird.Menu;
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
        Rectangle pipeHeadSource;
        int holeSize;
        int holePosition;
        Random rand;

        // CONSTRUCTORS
        public Pipe(int _startPosition)
        {
            holeSize = 80;
            texture = RessourcesManager.sprite;
            pipeSource = new Rectangle(654, 157, 24, 155);
            pipeHeadSource = new Rectangle(553, 300, 26, 12);
            rand = new Random();
            holePosition = rand.Next(0, 200);
            pipeDown = new Rectangle(Game1.screenWidth + _startPosition, holePosition + holeSize, pipeSource.Width * 2, pipeSource.Height * 2);
            pipeUp = new Rectangle(Game1.screenWidth + _startPosition, holePosition - pipeSource.Height * 2, pipeSource.Width * 2, pipeSource.Height * 2);
        }

        // METHODS
        private void MovePipe()
        {
            pipeDown.X -= 2;
            pipeUp.X -= 2;

            if (pipeDown.X <= -1 - pipeDown.Width)
            {
                pipeDown.X = Game1.screenWidth;
                pipeUp.X = Game1.screenWidth;
                rand = new Random();
                holePosition = rand.Next(0, 200);
                pipeDown.Y = holePosition + holeSize;
                pipeUp.Y = holePosition - pipeSource.Height * 2;
            }
        }

        public Rectangle Hole { get { return new Rectangle(pipeDown.X - Bird.Width / 2, holePosition + Bird.Height * 3 / 2, pipeDown.Width + Bird.Width, holeSize - Bird.Height * 2); } }

        public int XpositionUp { get { return pipeUp.X; } }
        public int XpositionDown { get { return pipeDown.X; } }
        public int YpositionUp { get { return pipeUp.Y; } }
        public int YpositionDown { get { return pipeDown.Y; } }
        public int WidthUp { get { return pipeUp.Width; } }
        public int WidthDown { get { return pipeDown.Width; } }
        public int HeightUp { get { return pipeUp.Height; } }
        public int HeightDown { get { return pipeDown.Height; } }

        // UPDATE & DRAW
        public void Update(GameTime gameTime)
        {
            MovePipe();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pipeDown, pipeSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.8f);
            spriteBatch.Draw(texture, new Rectangle((pipeDown.X + pipeDown.Width / 2) - pipeHeadSource.Width, pipeDown.Y, pipeHeadSource.Width * 2, pipeHeadSource.Height * 2), pipeHeadSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.7f);

            spriteBatch.Draw(texture, pipeUp, pipeSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.8f);
            spriteBatch.Draw(texture, new Rectangle((pipeUp.X + pipeUp.Width / 2) - pipeHeadSource.Width, pipeUp.Y + pipeUp.Height - pipeHeadSource.Height * 2, pipeHeadSource.Width * 2, pipeHeadSource.Height * 2), pipeHeadSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.7f);
        }
    }
}
