using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JezzBall2.Players;
using JezzBall2.Balls;

namespace JezzBall2.Stages
{
    class Stage
    {
        protected int height;
        protected int width;
        protected int borderWidth;
        protected Vector2 drawOffset;
        protected Texture2D borderTexture;
        protected List<Player> players;
        protected List<Ball> balls;

        public Stage(int height, int width, int borderWidth, Texture2D borderTexture, Vector2 drawOffset)
        {
            this.height = height;
            this.width = width;
            this.borderWidth = borderWidth;
            this.drawOffset = drawOffset;

            this.players = new List<Player>();
            this.balls = new List<Ball>();

            this.borderTexture = borderTexture;
        }

        public void update(GameTime gameTime)
        {
            foreach (Player p in this.players)
            {
                p.update(gameTime);
            }
            foreach (Ball b in this.balls)
            {
                b.update(gameTime);
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.borderTexture, new Rectangle(0 + (int)this.drawOffset.X, 0 + (int)this.drawOffset.Y, this.borderWidth, this.height), Color.White);
            spriteBatch.Draw(this.borderTexture, new Rectangle(this.width + (int)this.drawOffset.X, 0 + (int)this.drawOffset.Y, this.borderWidth, this.height), Color.White);
            spriteBatch.Draw(this.borderTexture, new Rectangle(0 + (int)this.drawOffset.X, 0 + (int)this.drawOffset.Y, this.width, this.borderWidth), Color.White);
            spriteBatch.Draw(this.borderTexture, new Rectangle(0 + (int)this.drawOffset.X, this.height + (int)this.drawOffset.Y, this.width, this.borderWidth), Color.White);

            foreach (Player p in this.players)
            {
                p.draw(spriteBatch);
            }
            foreach (Ball b in this.balls)
            {
                b.draw(spriteBatch);
            }
        }
    }
}
