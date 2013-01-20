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
        List<Vector2> positions;
        protected float textSpeed;
        protected SpriteFont font;
        protected int spacing;
        protected Color textColor;

        public CreditScreen(Game game, SpriteBatch spriteBatch, SpriteFont font, String[] credits, float textSpeed, int spacing, Color textColor)
            : base(game, spriteBatch)
        {
            this.font = font;
            this.credits = credits;
            this.textSpeed = textSpeed;
            this.spacing = spacing;
            this.textColor = textColor;
            this.positions = new List<Vector2>();

            float x = 0;
            float y = 0;

            for(int i=0; i < credits.Length; i++)
            {
                x = Game.Window.ClientBounds.Width / 2 - font.MeasureString(credits[i]).X / 2;
                y = Game.Window.ClientBounds.Height + i * (font.MeasureString(credits[i]).Y + spacing);
                positions.Add(new Vector2(x, y));
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (positions[positions.Count - 1].Y <= -font.MeasureString(credits[credits.Length - 1]).Y)
            {
                this.Enabled = false;
                float x = 0;
                float y = 0;

                for(int j=0; j < positions.Count; j++)
                {
                    x = Game.Window.ClientBounds.Width / 2 - font.MeasureString(credits[j]).X / 2;
                    y = Game.Window.ClientBounds.Height + j * (font.MeasureString(credits[j]).Y + spacing);
                    positions[j] = new Vector2(x, y);
                }
            }
            else
            {
                for (int i = 0; i < positions.Count; i++)
                {
                    Vector2 curPos = positions[i];
                    curPos.Y -= textSpeed;
                    positions[i] = curPos;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            for (int i = 0; i < credits.Length; i++)
            {
                this.spriteBatch.DrawString(this.font, credits[i], positions[i], this.textColor);
            }
            base.Draw(gameTime);
        }
    }
}