using MG_FlappyBird.Menu;
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
        MenuMain mainMenu;

        // CONSTRUCTOR
        public GameMain()
        {
            mainMenu = new MenuMain();
        }
        
        // METHODS

        // UPDATE & DRAW
        public void Update(GameTime gameTime)
        {
            mainMenu.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mainMenu.Draw(spriteBatch);
        }
    }
}
