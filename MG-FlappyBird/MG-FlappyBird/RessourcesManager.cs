using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG_FlappyBird
{
    class RessourcesManager
    {
        // STATIC FIELDS
        public static Texture2D sprite;

        // LOAD CONTENT
        public static void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("sprite");
        }
    }
}
