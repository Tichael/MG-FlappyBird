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
        MenuGameOver gameOver;
        bool over;

        bool started;
        bool died;
        Button menuButton;
        Button pauseButton;
        Button resumeButton;

        Bird player;
        Pipe[] pipes;
        Score actualScore;
        bool addScore;

        bool writed;

        Rectangle getReady;
        Rectangle getReadySource;
        Rectangle startTip;
        Rectangle startTipSource;
        Rectangle spaceTip;
        Rectangle spaceTipSource;

        string[] txtScore;

        KeyboardState presentKey;
        KeyboardState pastKey;

        // CONSTRUCTOR
        public MenuGame()
        {
            started = false;
            died = false;
            over = false;

            menuButton = new Button(sprite, new Point(60, 21), new Rectangle(558, 212, 40, 14));
            pauseButton = new Button(sprite, new Point(Game1.screenWidth - 13 * 3 / 2, 14 * 3 / 2), new Rectangle(558, 143, 13, 14));
            resumeButton = new Button(sprite, new Point(Game1.screenWidth - 13 * 3 / 2, 14 * 3 / 2), new Rectangle(571, 143, 13, 14));
            
            actualScore = new Score(Game1.screenWidth / 2, Game1.screenHeight / 2 - 192, true);
            totalScore = 0;
            newScore = false;
            writed = false;

            getReadySource = new Rectangle(584, 135, 87, 22);
            getReady = new Rectangle(Game1.screenWidth / 2 - getReadySource.Width * 3 / 2, Game1.screenHeight / 2 - getReadySource.Height * 3 / 2 - 128, getReadySource.Width * 3, getReadySource.Height * 3);
            startTipSource = new Rectangle(558, 58, 19, 37);
            startTip = new Rectangle(Game1.screenWidth / 2 - startTipSource.Width, Game1.screenHeight / 2 - startTipSource.Height, startTipSource.Width * 2, startTipSource.Height * 2);
            spaceTipSource = new Rectangle(577, 58, 31, 15);
            spaceTip = new Rectangle(startTip.X + startTip.Width + 16, startTip.Y + 47, spaceTipSource.Width * 3, spaceTipSource.Height * 3);

            txtScore = new string[2];
            txtScore[0] = "|Flappy Bird Save|";
        }

        // METHODS

        // UPDATE & DRAW
        public override void Update(GameTime gameTime)
        {
            presentKey = Keyboard.GetState();
            base.Update(gameTime);
            if (presentKey.IsKeyDown(Keys.Escape) && pastKey != presentKey && started)
                paused = !paused;
            if (!paused)
            {
                if (started)
                {
                    pauseButton.Update(gameTime);
                    if (pauseButton.Clicked)
                        paused = true;
                    player.Update(gameTime, true);
                    foreach (Pipe pipe in pipes)
                    {
                        pipe.Update(gameTime);
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        if ((!player.Intersect(pipes[i].Hole) && player.XPosition + Bird.Width / 2 > pipes[i].XpositionUp && player.XPosition - Bird.Width / 2 < pipes[i].XpositionUp + pipes[i].WidthUp))
                        {
                            died = true;
                            RessourcesManager.hurt.Play();
                            player.Flap(false);
                        }
                        else if (player.XPosition >= pipes[i].Hole.X + pipes[i].Hole.Width && player.XPosition <= pipes[i].Hole.X + pipes[i].Hole.Width + 1 && addScore)
                        {
                            totalScore++;
                            addScore = false;
                            RessourcesManager.pipePassed.Play();
                        }
                        else
                            addScore = true;
                    }
                    if (player.YPosition + Bird.Height / 2 >= Game1.screenHeight - ground.Height || died)
                    {
                        died = true;
                        started = false;
                        pauseBackground = true;
                        RessourcesManager.hurt.Play();
                        player.Flap(false);
                    }
                    else if (player.YPosition - Bird.Height / 2 < 0)
                    {
                        player.YPosition = 0 + Bird.Height / 2;
                    }
                }
                else if (died)
                {
                    // ################ DIED ##############
                    if (player.YPosition - Bird.Height / 2 > Game1.screenHeight + Bird.Height)
                    {
                        if (!over)
                        {
                            gameOver = new MenuGameOver();
                            over = true;
                        }
                        gameOver.Update(gameTime);
                    }
                    else
                    {
                        player.Update(gameTime, false);
                        if (!writed)
                        {
                            if (totalScore > highScore)
                            {
                                if (totalScore < 10)
                                {
                                    txtScore[1] = "high score=" + "00" + totalScore;
                                }
                                else if (totalScore < 100)
                                {
                                    txtScore[1] = "high score=" + "0" + totalScore;
                                }
                                else
                                {
                                    txtScore[1] = "high score=" + totalScore;
                                }
                                System.IO.File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Flappy.txt", txtScore);
                                highScore = totalScore;
                                newScore = true;
                            }
                            writed = true;
                        }
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
                    player = new Bird();
                    addScore = true;
                    pipes = new Pipe[3];
                    for (int i = 0; i < 3; i++)
                    {
                        pipes[i] = new Pipe(i * 267);
                    }
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
            pastKey = presentKey;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (started)
            {
                if (!paused)
                {
                    pauseButton.Draw(spriteBatch);
                }
                else
                {
                    spriteBatch.Draw(RessourcesManager.pixel, new Rectangle(0, 0, Game1.screenWidth, Game1.screenHeight), new Rectangle(0, 0, 1, 1), new Color(Color.Black, 0.7f), 0f, Vector2.Zero, SpriteEffects.None, 0.4f);
                    menuButton.Draw(spriteBatch);
                    resumeButton.Draw(spriteBatch);
                    spriteBatch.Draw(sprite, new Rectangle(Game1.screenWidth / 2 - 162 / 2, Game1.screenHeight / 2 - 60 / 2, 162, 60), new Rectangle(598, 198, 54, 20), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
                }
                player.Draw(spriteBatch);
                foreach (Pipe pipe in pipes)
                {
                    pipe.Draw(spriteBatch);
                }
                actualScore.Draw(spriteBatch, totalScore.ToString());
            }
            else if (died)
            {
                player.Draw(spriteBatch);
                foreach (Pipe pipe in pipes)
                {
                    pipe.Draw(spriteBatch);
                }
                if (over)
                {
                    gameOver.Draw(spriteBatch);
                }
            }
            else
            {
                menuButton.Draw(spriteBatch);
                spriteBatch.Draw(sprite, startTip, startTipSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
                spriteBatch.Draw(sprite, spaceTip, spaceTipSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
                spriteBatch.Draw(sprite, getReady, getReadySource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
            }
        }
    }
}
