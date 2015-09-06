using MG_FlappyBird.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG_FlappyBird.Menu
{
    class MenuMain : MenuBase
    {
        // FIELDS
        Vector2 logoPosition;
        Vector2 logoSize;
        Rectangle logoSource;
        float zoom = 0.3f;
        short direction = 1;

        Button startButton;

        // CONSTRUCTOR
        public MenuMain()
        {
            logoSource = new Rectangle(558, 157, 96, 22);
            logoPosition = new Vector2(Game1.screenWidth / 2 - logoSource.Width * 3 / 2, Game1.screenHeight / 2 - logoSource.Height * 3 / 2 - 128);
            logoSize = new Vector2(logoSource.Width * 3, logoSource.Height * 3);

            startButton = new Button(sprite, new Point(Game1.screenWidth / 2, Game1.screenHeight / 2), new Rectangle(558, 198, 40, 14));
        }

        // METHODS
        private void LogoAnimation()
        {
            logoSize.X += zoom * direction;
            logoPosition.X = Game1.screenWidth / 2 - logoSize.X / 2;
            logoSize.Y -= zoom * direction;
            if (logoSize.X >= 290 || logoSize.X <= 270)
                direction = (short)-direction;
        }

        // UPDATE & DRAW
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            LogoAnimation();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.Draw(sprite, new Rectangle((int)logoPosition.X, (int)logoPosition.Y, (int)logoSize.X, (int)logoSize.Y), logoSource, Color.White);
            startButton.Draw(spriteBatch);
        }
    }
}
