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

        Texture2D pixel;
        Rectangle black;
        float opacty;

        Rectangle background;
        Rectangle backgroundSource;

        protected Rectangle ground;
        Rectangle groundSource;

        protected bool paused;
        protected bool pauseBackground;

        protected int totalScore;

        protected int highScore;
        string[] txtFile;

        // Constructor
        public MenuBase()
        {
            totalScore = 0;

            sprite = RessourcesManager.sprite;
            pixel = RessourcesManager.pixel;
            black = new Rectangle(0, 0, Game1.screenWidth, Game1.screenHeight);
            opacty = 1f;

            backgroundSource = new Rectangle(0, 0, 552, 256);
            background = new Rectangle(0, 0, backgroundSource.Width * 2, backgroundSource.Height * 2);
            groundSource = new Rectangle(0, 256, 553, 56);
            ground = new Rectangle(0, Game1.screenHeight - groundSource.Height * 2, groundSource.Width * 2, groundSource.Height * 2);
            paused = false;
            pauseBackground = false;

            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Flappy.txt"))
            {
                txtFile = System.IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Flappy.txt");
                if (txtFile[1].Contains("high score="))
                {
                    if (int.TryParse(txtFile[1].Substring(11, 3), out highScore)) { }
                }
            }
        }

        // Methods
        private void BackgroundMovement()
        {
            if (!paused && !pauseBackground)
            {
                background.X--;
                if (background.X <= -276)
                    background.X = 0;
            }
        }

        private void GroundMovement()
        {
            if (!paused && !pauseBackground)
            {
                ground.X -= 2;
                if (ground.X <= -14)
                    ground.X = 0;
            }
        }

        // Update & Draw
        public virtual void Update(GameTime gameTime)
        {
            BackgroundMovement();
            GroundMovement();
            if (opacty > 0)
                    opacty -= 0.03f;
        }
        
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, background, backgroundSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 1f);
            spriteBatch.Draw(sprite, ground, groundSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.6f);
            spriteBatch.Draw(pixel, black, new Rectangle(0, 0, 1, 1), new Color(Color.Black, opacty), 0f, Vector2.Zero, SpriteEffects.None, 0f);
        }
    }
}
