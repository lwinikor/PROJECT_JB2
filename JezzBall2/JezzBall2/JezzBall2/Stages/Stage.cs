using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JezzBall2.Players;
using JezzBall2.Balls;
using JezzBall2.Utility;

namespace JezzBall2.Stages
{
    class Stage
    {
        protected int height;
        protected int width;
        protected int borderWidth;
        protected Vector2 drawOffset;
        protected Texture2D borderTexture;
        protected Texture2D backgroundTexture;


        public Stage(int height, int width, int borderWidth, Texture2D borderTexture, Texture2D bgTexture, Vector2 drawOffset)
        {
            this.height = height;
            this.width = width;
            this.borderWidth = borderWidth;
            this.drawOffset = drawOffset;
            this.borderTexture = borderTexture;
            this.backgroundTexture = bgTexture;
        }

        public void update(GameTime gameTime)
        {

        }

        public void draw(SpriteBatch spriteBatch)
        {
            for (int i = (int)this.drawOffset.X; i < this.width + drawOffset.X; i += backgroundTexture.Width)
            {
                for (int j = (int)this.drawOffset.Y; j < this.height + drawOffset.Y; j += backgroundTexture.Height)
                {
                    spriteBatch.Draw(backgroundTexture, new Rectangle(i, j, backgroundTexture.Width, backgroundTexture.Height), Color.White);
                }
            }
            DrawUtility.drawHollowRectangle(spriteBatch, this.borderTexture, Color.White, this.borderWidth, (int)this.drawOffset.Y, (int)this.drawOffset.X, this.height, this.width);
        }
    }
}
