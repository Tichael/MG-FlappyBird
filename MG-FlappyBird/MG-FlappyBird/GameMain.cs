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
        MenuGame gameMenu;

        string[] menuList = {"main", "game"};
        static string activeMenu;
        static bool reset;

        // CONSTRUCTOR
        public GameMain()
        {
            mainMenu = new MenuMain();
            gameMenu = new MenuGame();

            activeMenu = menuList[0];
            reset = false;
        }
        
        // METHODS
        public static string ChangeMenu { set { activeMenu = value; reset = true; } }

        // UPDATE & DRAW
        public void Update(GameTime gameTime)
        {
            if (reset)
            {
                mainMenu = new MenuMain();
                gameMenu = new MenuGame();
                reset = false;
            }
            if (activeMenu == "main")
                mainMenu.Update(gameTime);
            else if (activeMenu == "game")
                gameMenu.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (activeMenu == "main")
                mainMenu.Draw(spriteBatch);
            else if (activeMenu == "game")
                gameMenu.Draw(spriteBatch);
        }
    }
}
