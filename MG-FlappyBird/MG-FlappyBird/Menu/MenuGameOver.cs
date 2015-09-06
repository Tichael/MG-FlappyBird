using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MG_FlappyBird.GUI;

namespace MG_FlappyBird.Menu
{
    class MenuGameOver
    {
        // FIELDS
        Texture2D texture;
        bool loaded;

        Rectangle title;
        Rectangle titleSource;

        Rectangle box;
        Rectangle boxSource;

        Rectangle newScore;
        Rectangle newScoreSource;

        Button retryButton;
        Button menuButton;

        int score;
        int highScore;

        int medalLevel;
        Medal medal;

        Score writeScore;
        Score writeBest;

        // CONSTRUCTOR
        public MenuGameOver()
        {
            texture = RessourcesManager.sprite;
            loaded = false;

            titleSource = new Rectangle(558, 179, 94, 19);
            title = new Rectangle(Game1.screenWidth / 2 - titleSource.Width * 3 / 2, 0 - titleSource.Height * 3, titleSource.Width * 3, titleSource.Height * 3);

            boxSource = new Rectangle(558, 0, 113, 58);
            box = new Rectangle(Game1.screenWidth / 2 - boxSource.Width * 3 / 2, Game1.screenHeight, boxSource.Width * 3, boxSource.Height * 3);

            retryButton = new Button(texture, new Point(Game1.screenWidth / 2, Game1.screenHeight / 2 + box.Height / 2 + 32), new Rectangle(558, 226, 40, 14));
            menuButton = new Button(texture, new Point(Game1.screenWidth / 2, retryButton.ButtonY + 80), new Rectangle(558, 212, 40, 14));

            highScore = MenuBase.HighScore;
            score = MenuBase.TotalScore;

            if (MenuBase.NewScore && score > 50)
                medalLevel = 0;
            else if (MenuBase.NewScore && score > 25)
                medalLevel = 1;
            else if (MenuBase.NewScore)
                medalLevel = 2;
            else
                medalLevel = 3;
            medal = new Medal(medalLevel, new Point((Game1.screenWidth / 2 - boxSource.Width * 3 / 2) + 13 * 3, (Game1.screenHeight / 2 - boxSource.Height * 3 / 2) + 21 * 3));

            writeScore = new Score((Game1.screenWidth / 2 - boxSource.Width * 3 / 2) + 92 * 3, (Game1.screenHeight / 2 - boxSource.Height * 3 / 2) + 17 * 3, false);
            writeBest = new Score((Game1.screenWidth / 2 - boxSource.Width * 3 / 2) + 92 * 3, (Game1.screenHeight / 2 - boxSource.Height * 3 / 2) + 38 * 3, false);
            
            newScoreSource = new Rectangle(617, 58, 16, 7);
            newScore = new Rectangle((Game1.screenWidth / 2 - boxSource.Width * 3 / 2) + 60 * 3, (Game1.screenHeight / 2 - boxSource.Height * 3 / 2) + 8 * 3, newScoreSource.Width * 3, newScoreSource.Height * 3);
        }

        // METHODS

        // UPDATE & DRAW
        public void Update(GameTime gameTime)
        {
            if (!loaded)
            {
                if (title.Y < 64)
                    title.Y += 8;
                box.Y -= 8;

                if (box.Y + box.Height / 2 <= Game1.screenHeight / 2)
                {
                    box.Y = Game1.screenHeight / 2 - box.Height / 2;
                    loaded = true;
                }
            }
            else
            {
                retryButton.Update(gameTime);
                if (retryButton.Clicked)
                    GameMain.ChangeMenu = "game";
                menuButton.Update(gameTime);
                if (menuButton.Clicked)
                    GameMain.ChangeMenu = "main";
                medal.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, title, titleSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
            spriteBatch.Draw(texture, box, boxSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            if (box.Y < retryButton.ButtonY - retryButton.ButtonHeight /2)
            {
                retryButton.Draw(spriteBatch);
                menuButton.Draw(spriteBatch);
            }
            if (loaded)
            {
                medal.Draw(spriteBatch);
                writeScore.Draw(spriteBatch, score.ToString());
                writeBest.Draw(spriteBatch, highScore.ToString());
                if (MenuBase.NewScore)
                    spriteBatch.Draw(texture, newScore, newScoreSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
            }
        }
    }
}
