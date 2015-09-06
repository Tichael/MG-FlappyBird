using MG_FlappyBird.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG_FlappyBird.Menu
{
    class MenuGame : MenuBase
    {
        // FIELDS
        bool started;
        Button menuButton;
        Button pauseButton;
        Button resumeButton;

        Bird player;
        Pipe testPipe;

        Rectangle getReady;
        Rectangle getReadySource;
        Rectangle startTip;
        Rectangle startTipSource;
        Rectangle spaceTip;
        Rectangle spaceTipSource;

        // CONSTRUCTOR
        public MenuGame()
        {
            started = false;

            menuButton = new Button(sprite, new Point(60, 21), new Rectangle(558, 212, 40, 14));
            pauseButton = new Button(sprite, new Point(Game1.screenWidth - 13 * 3 / 2, 14 * 3 / 2), new Rectangle(558, 143, 13, 14));
            resumeButton = new Button(sprite, new Point(Game1.screenWidth - 13 * 3 / 2, 14 * 3 / 2), new Rectangle(571, 143, 13, 14));

            player = new Bird();
            testPipe = new Pipe(0);

            getReadySource = new Rectangle(584, 135, 87, 22);
            getReady = new Rectangle(Game1.screenWidth / 2 - getReadySource.Width * 3 / 2, Game1.screenHeight / 2 - getReadySource.Height * 3 / 2 - 128, getReadySource.Width * 3, getReadySource.Height * 3);
            startTipSource = new Rectangle(558, 58, 19, 37);
            startTip = new Rectangle(Game1.screenWidth / 2 - startTipSource.Width, Game1.screenHeight / 2 - startTipSource.Height, startTipSource.Width * 2, startTipSource.Height * 2);
            spaceTipSource = new Rectangle(577, 58, 31, 15);
            spaceTip = new Rectangle(startTip.X + startTip.Width + 16, startTip.Y + 47, spaceTipSource.Width * 3, spaceTipSource.Height * 3);
        }

        // METHODS

        // UPDATE & DRAW
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!paused)
            {
                if (started)
                {
                    pauseButton.Update(gameTime);
                    if (pauseButton.Clicked)
                        paused = true;
                    player.Update(gameTime);
                    testPipe.Update(gameTime);
                    if (player.YPosition + player.Height >= Game1.screenHeight - ground.Height || (player.YPosition <= testPipe.YpositionUp + testPipe.HeightUp && (player.XPosition + player.Width >= testPipe.XpositionUp && player.XPosition <= testPipe.XpositionUp + testPipe.WidthUp)) || (player.YPosition + player.Height >= testPipe.YpositionDown && (player.XPosition + player.Width >= testPipe.XpositionDown && player.XPosition <= testPipe.XpositionDown + testPipe.WidthDown)))
                    {
                        started = false;
                        player = new Bird();
                        testPipe = new Pipe(0);
                    }
                    else if (player.YPosition  < 0)
                    {
                        player.YPosition = 0;
                    }
                }
                else
                {
                    menuButton.Update(gameTime);
                    if (menuButton.Clicked)
                    {
                        GameMain.ChangeMenu = "main";
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                        started = true;
                }
            }
            else
            {
                menuButton.Update(gameTime);
                if (menuButton.Clicked)
                {
                    GameMain.ChangeMenu = "main";
                }
                resumeButton.Update(gameTime);
                if (resumeButton.Clicked)
                {
                    paused = false;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (!paused)
            {
                if (started)
                {
                    pauseButton.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    testPipe.Draw(spriteBatch);
                }
                else
                {
                    menuButton.Draw(spriteBatch);
                    spriteBatch.Draw(sprite, startTip, startTipSource, Color.White);
                    spriteBatch.Draw(sprite, spaceTip, spaceTipSource, Color.White);
                    spriteBatch.Draw(sprite, getReady, getReadySource, Color.White);
                }
            }
            else
            {
                menuButton.Draw(spriteBatch);
                resumeButton.Draw(spriteBatch);
                player.Draw(spriteBatch);
                testPipe.Draw(spriteBatch);
            }
        }
    }
}
