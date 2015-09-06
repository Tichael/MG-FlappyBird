using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG_FlappyBird.GUI
{
    class Button
    {
        // FIELDS
        Texture2D texture;
        Point position;
        Rectangle button;
        Rectangle buttonSource;
        Color color;
        bool clicked;
        bool inClick;

        // CONSTRUCTOR
        public Button(Texture2D _texture, Point _position, Rectangle _buttonSource)
        {
            color = Color.White;
            texture = _texture;
            buttonSource = _buttonSource;
            position = _position;
            button = new Rectangle(position.X - buttonSource.Width * 3 / 2, position.Y - buttonSource.Height * 3 / 2, buttonSource.Width * 3, buttonSource.Height * 3);
            clicked = false;
            inClick = false;
        }

        // METHODS
        public bool Clicked
        {
            get { return clicked; }
            set { clicked = value; }
        }
        public int ButtonWidth
        {
            get { return button.Width; }
        }
        public int ButtonHeight
        {
            get { return button.Height; }
        }

        // UPDATE & DRAW
        public void Update(GameTime gameTime)
        {
            if (Mouse.GetState().X >= button.X && Mouse.GetState().X <= button.X + button.Width && Mouse.GetState().Y >= button.Y && Mouse.GetState().Y <= button.Y + button.Height)
            {
                color = Color.LightGray;
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    button.Width = buttonSource.Width * 3 - 10;
                    button.Height = buttonSource.Height * 3 - 4;
                    inClick = true;
                }
                else
                {
                    if (inClick)
                    {
                        inClick = false;
                        clicked = true;
                    }
                    else if (inClick == false)
                        clicked = false;
                    button.Width = buttonSource.Width * 3;
                    button.Height = buttonSource.Height * 3;
                }
            }
            else if (color != Color.White)
                color = Color.White;

            button.X = position.X - button.Width / 2;
            button.Y = position.Y - button.Height / 2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, button, buttonSource, color, 0f, Vector2.Zero, SpriteEffects.None, 0f);
        }
    }
}
