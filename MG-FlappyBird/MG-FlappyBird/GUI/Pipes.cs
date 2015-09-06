using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG_FlappyBird.GUI
{
    class Pipes
    {
        // FIELDS
        Pipe pipe1;
        Pipe pipe2;
        Pipe pipe3;

        // CONSTRUCTOR
        public Pipes()
        {
            pipe1 = new Pipe(0);
            pipe2 = new Pipe(267);
            pipe3 = new Pipe(534);
        }

        // METHODS

        // UPDATE & DRAW
        public void Update(GameTime gameTime)
        {
            pipe1.Update(gameTime);
            pipe2.Update(gameTime);
            pipe3.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pipe1.Draw(spriteBatch);
            pipe2.Draw(spriteBatch);
            pipe3.Draw(spriteBatch);
        }
    }
}
