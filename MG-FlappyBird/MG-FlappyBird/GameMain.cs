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
        MenuBase menuBase;

        // CONSTRUCTOR
        public GameMain()
        {
            menuBase = new MenuBase();
        }
        
        // METHODS

        // UPDATE & DRAW
        public void Update(GameTime gameTime)
        {
            menuBase.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            menuBase.Draw(spriteBatch);
        }
    }
}
