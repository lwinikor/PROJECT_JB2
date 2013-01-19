using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JezzBall2.Screens
{
    class CreditScreen : GameScreen
    {
        String[] credits;
        protected float textSpeed;
        protected SpriteFont font;
        protected int spacing;

        public CreditScreen(Game game, SpriteBatch spriteBatch, SpriteFont font, String[] credits, float textSpeed, int spacing)
            : base(game, spriteBatch)
        {
            this.credits = credits;
            this.textSpeed = textSpeed;
            this.spacing = spacing;
        }

        public override void Update(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}