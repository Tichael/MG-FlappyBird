using Microsoft.Xna.Framework.Audio;
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
        public static Texture2D pixel;

        public static SoundEffect buttonClick;
        public static SoundEffect flap;
        public static SoundEffect hurt;
        public static SoundEffect pipePassed;
        public static SoundEffect over;
        public static SoundEffect bronze;
        public static SoundEffect silver;
        public static SoundEffect gold;

        // LOAD CONTENT
        public static void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("sprite");
            pixel = content.Load<Texture2D>("pixel");

            buttonClick = content.Load<SoundEffect>("Sounds/buttonClick");
            flap = content.Load<SoundEffect>("Sounds/flap");
            hurt = content.Load<SoundEffect>("Sounds/hurt");
            pipePassed = content.Load<SoundEffect>("Sounds/pipePassed");
            over = content.Load<SoundEffect>("Sounds/overHighNo");
            bronze = content.Load<SoundEffect>("Sounds/overHighBronze");
            silver = content.Load<SoundEffect>("Sounds/overHighSilver");
            gold = content.Load<SoundEffect>("Sounds/overHighGold");
        }
    }
}
