using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JezzBall2.Constants;
using Microsoft.Xna.Framework.Input;
using JezzBall2.Utility;

namespace JezzBall2.Screens
{
    class CreditScreen : GameScreen
    {
        String[] credits;
        List<Vector2> positions;
        protected SpriteFont font;
        protected Color textColor;

        protected KeyboardState currentKeyboardState;
        protected KeyboardState previousKeyboardState;

        public CreditScreen(Game game, SpriteBatch spriteBatch, SpriteFont font, String[] credits, Color textColor)
            : base(game, spriteBatch)
        {
            this.font = font;
            this.credits = credits;
            this.textColor = textColor;
            this.resetCredits();
        }

        public override void Update(GameTime gameTime)
        {
            this.currentKeyboardState = Keyboard.GetState();
            this.updateCredits();
            this.checkExit();
            this.previousKeyboardState = this.currentKeyboardState;
            base.Update(gameTime);
        }

        private void checkExit()
        {
            if (KeyboardUtility.checkKeyReleased(Keys.Enter, this.currentKeyboardState, this.previousKeyboardState))
            {
                this.hide();
            }
        }

        private void updateCredits()
        {
            if (this.positions[this.positions.Count - 1].Y <= -this.font.MeasureString(this.credits[credits.Length - 1]).Y)
            {
                this.Enabled = false;
                float x = 0;
                float y = 0;

                for (int j = 0; j < this.positions.Count; j++)
                {
                    x = Game.Window.ClientBounds.Width / 2 - font.MeasureString(this.credits[j]).X / 2;
                    y = Game.Window.ClientBounds.Height + j * (font.MeasureString(this.credits[j]).Y + CreditsConstants.SPACING);
                    this.positions[j] = new Vector2(x, y);
                }
            }
            else
            {
                for (int i = 0; i < this.positions.Count; i++)
                {
                    Vector2 curPos = this.positions[i];
                    curPos.Y -= CreditsConstants.TEXTSPEED;
                    this.positions[i] = curPos;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            for (int i = 0; i < this.credits.Length; i++)
            {
                this.spriteBatch.DrawString(this.font, this.credits[i], this.positions[i], this.textColor);
            }
            base.Draw(gameTime);
        }

        public override void show()
        {
            base.show();
            this.resetCredits();
        }

        private void resetCredits()
        {
            this.positions = new List<Vector2>();
            float x = 0;
            float y = 0;
            for (int i = 0; i < this.credits.Length; i++)
            {
                x = Game.Window.ClientBounds.Width / 2 - this.font.MeasureString(credits[i]).X / 2;
                y = Game.Window.ClientBounds.Height + i * (this.font.MeasureString(credits[i]).Y + CreditsConstants.SPACING);
                this.positions.Add(new Vector2(x, y));
            }
        }
    }
}