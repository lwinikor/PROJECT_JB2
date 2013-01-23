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

        public Stage(int height, int width, int borderWidth, Texture2D borderTexture, Vector2 drawOffset)
        {
            this.height = height;
            this.width = width;
            this.borderWidth = borderWidth;
            this.drawOffset = drawOffset;
            this.borderTexture = borderTexture;
        }

        public void update(GameTime gameTime)
        {

        }

        public void draw(SpriteBatch spriteBatch)
        {
            DrawUtility.drawHollowRectangle(spriteBatch, this.borderTexture, Color.White, this.borderWidth, (int)this.drawOffset.Y, (int)this.drawOffset.X, this.height, this.width);
        }
    }
}
