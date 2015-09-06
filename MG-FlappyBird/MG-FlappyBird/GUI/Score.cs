using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG_FlappyBird.GUI
{
    class Score
    {
        // FIELDS
        Texture2D texture;
        Rectangle score;
        Rectangle scoreSource;
        Point position;
        bool big;
        int characterPosition;

        // CONSTRUCTOR
        public Score(int _x, int _y, bool _big)
        {
            texture = RessourcesManager.sprite;
            position = new Point(_x, _y);
            big = _big;
            characterPosition = 0;
        }

        // METHODS
        private void DrawNumber(SpriteBatch spriteBatch, int characterPosition, char number, string scoreString)
        {
            if (big)
            {
                scoreSource = new Rectangle(617, 65, 8, 10);
                switch (number)
                {
                    case '0':
                        scoreSource.Location = new Point(617, 65);
                        break;
                    case '1':
                        scoreSource.Location = new Point(625, 65);
                        break;
                    case '2':
                        scoreSource.Location = new Point(633, 65);
                        break;
                    case '3':
                        scoreSource.Location = new Point(641, 65);
                        break;
                    case '4':
                        scoreSource.Location = new Point(617, 76);
                        break;
                    case '5':
                        scoreSource.Location = new Point(625, 76);
                        break;
                    case '6':
                        scoreSource.Location = new Point(633, 76);
                        break;
                    case '7':
                        scoreSource.Location = new Point(641, 76);
                        break;
                    case '8':
                        scoreSource.Location = new Point(617, 87);
                        break;
                    case '9':
                        scoreSource.Location = new Point(625, 87);
                        break;
                    default:
                        scoreSource.Location = new Point(617, 65);
                        break;
                }
            }
            else
            {
                scoreSource = new Rectangle(617, 98, 7, 7);
                switch (number)
                {
                    case '0':
                        scoreSource.Location = new Point(617, 98);
                        break;
                    case '1':
                        scoreSource.Location = new Point(624, 98);
                        break;
                    case '2':
                        scoreSource.Location = new Point(631, 98);
                        break;
                    case '3':
                        scoreSource.Location = new Point(638, 98);
                        break;
                    case '4':
                        scoreSource.Location = new Point(645, 98);
                        break;
                    case '5':
                        scoreSource.Location = new Point(617, 106);
                        break;
                    case '6':
                        scoreSource.Location = new Point(624, 106);
                        break;
                    case '7':
                        scoreSource.Location = new Point(631, 106);
                        break;
                    case '8':
                        scoreSource.Location = new Point(638, 106);
                        break;
                    case '9':
                        scoreSource.Location = new Point(645, 106);
                        break;
                    default:
                        scoreSource.Location = new Point(617, 98);
                        break;
                }
            }

            score = new Rectangle((position.X + characterPosition * (scoreSource.Width * 3)) - (scoreString.Length * scoreSource.Width * 3) / 2, position.Y, scoreSource.Width * 3, scoreSource.Height * 3);
            spriteBatch.Draw(texture, score, scoreSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
        }

        // DRAW
        public void Draw(SpriteBatch spriteBatch, string score)
        {
            foreach(char c in score)
            {
                DrawNumber(spriteBatch, characterPosition, c, score);
                characterPosition++;
            }
            characterPosition = 0;
        }
    }
}
