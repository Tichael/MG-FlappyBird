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

        Button retryButton;
        Button menuButton;

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
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, title, titleSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
            spriteBatch.Draw(texture, box, boxSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            if (loaded || box.Y < retryButton.ButtonY - retryButton.ButtonHeight /2)
            {
                retryButton.Draw(spriteBatch);
                menuButton.Draw(spriteBatch);
            }
        }
    }
}
