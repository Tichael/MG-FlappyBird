using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG_FlappyBird
{
    class GameMain
    {
        // FIELDS
        Texture2D texture;
        Rectangle rectangle;

        // CONSTRUCTOR
        public GameMain()
        {
            texture = RessourcesManager.sprite;
            rectangle = new Rectangle(Game1.screenWidth / 2, Game1.screenHeight / 2, 100, 100);
        }
        
        // METHODS

        // UPDATE & DRAW
        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Left))
                rectangle.X += 3;
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right))
                rectangle.X -= 3;
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down))
                rectangle.Y -= 3;
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && Keyboard.GetState().IsKeyUp(Keys.Up))
                rectangle.Y += 3;

            if (Keyboard.GetState().IsKeyDown(Keys.Add) && Keyboard.GetState().IsKeyUp(Keys.Subtract))
                rectangle.Inflate(5, 5);
            if (Keyboard.GetState().IsKeyDown(Keys.Subtract) && Keyboard.GetState().IsKeyUp(Keys.Add))
                rectangle.Inflate(-5, -5);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
