using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG_FlappyBird.GUI
{
    class Bird
    {
        // FIELDS
        Texture2D texture;
        Rectangle rectangle;
        Rectangle sourceRectangle;
        float rotation;
        float rotationSpeed;

        float fallSpeed;
        float fallTime;
        public int displacement;
        int frameCounter;

        KeyboardState presentKey;
        KeyboardState pastKey;

        // CONSTRUCTOR
        public Bird()
        {
            texture = RessourcesManager.sprite;
            sourceRectangle = new Rectangle(558, 107, 17, 12);
            rectangle = new Rectangle(Game1.screenWidth / 2, Game1.screenHeight / 2 - sourceRectangle.Height * 2, sourceRectangle.Width * 2, sourceRectangle.Height * 2);
            rotation = 0f;
            rotationSpeed = 0.3f;

            fallSpeed = 3.5f;
            fallTime = 0f;
            frameCounter = 1;
            displacement = 0;
        }

        // METHODS
        public int YPosition
        {
            get { return rectangle.Y; }
            set { rectangle.Y = value; }
        }
    
        public int XPosition
        {
            get { return rectangle.X; }
        }

        public int Width
        {
            get { return rectangle.Width; }
        }

        public int Height
        {
            get { return rectangle.Height; }
        }

        private void Flap()
        {
            fallTime = -1.4f;
        }

        private void Animation()
        {
            if (displacement < -1)
                frameCounter = 2;
            else if (displacement >= -1 && displacement <= 1)
                frameCounter = 1;
            else if (displacement > 1)
                frameCounter = 0;
        }

        // UPDATE & DRAW
        public void Update(GameTime gameTime)
        {
            presentKey = Keyboard.GetState();
            if (presentKey.IsKeyDown(Keys.Space) && pastKey != presentKey)
                Flap();
            displacement = (int)(Math.Sinh(fallTime) * fallSpeed);
            if (displacement >= 12)
                displacement = 12;
            rotation = (float)(Math.Sinh(fallTime)) * rotationSpeed;
            if (rotation >= 0.9f)
                rotation = 0.9f;
            rectangle.Y += displacement;
            fallTime += 0.1f;
            Animation();
            sourceRectangle = new Rectangle(558, 107 + frameCounter * 12, 17, 12);
            pastKey = presentKey;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, sourceRectangle, Color.White, rotation, new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2), SpriteEffects.None, 0.4f);
        }
    }
}
