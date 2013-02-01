using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using JezzBall2.Constants;
using JezzBall2.Utility;

namespace JezzBall2.Screens
{
    class TitleScreen : GameScreen
    {
        protected Color backgroundColor = Color.Black;
        protected Color textColor = Color.White;

        protected Texture2D image;
        protected Rectangle imageRectangle;
        protected Color color;

        protected KeyboardState currentKeyboardState;
        protected KeyboardState previousKeyboardState;

        protected SpriteFont titleSpriteFont;
        protected SpriteFont pressStartSpriteFont;

        protected Vector2 titlePosition;
        protected Vector2 pressStartPosition;

        protected Boolean displayPressStart;
        protected int elapsedTime;

        public TitleScreen(Game game, SpriteBatch spriteBatch, SpriteFont titleSpriteFont, SpriteFont pressStartSpriteFont, Texture2D image, Color color)
            : base(game, spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            this.titleSpriteFont = titleSpriteFont;
            this.pressStartSpriteFont = pressStartSpriteFont;
            this.image = image;
            this.color = color;
            this.imageRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
            this.setTextPositions();
        }


        public void setTextPositions()
        {
            float height = 0;
            float width = 0;

            Vector2 size = this.titleSpriteFont.MeasureString(StartScreenConstants.TITLE);
            width = size.X;
            height = size.Y;

            this.titlePosition = new Vector2((Game.Window.ClientBounds.Width - width) / 2, (Game.Window.ClientBounds.Height) * StartScreenConstants.TITLE_Y_FRACTION);

            size = this.pressStartSpriteFont.MeasureString(StartScreenConstants.PRESS_START);
            width = size.X;
            height = size.Y;

            this.pressStartPosition = new Vector2((Game.Window.ClientBounds.Width - width) / 2, (Game.Window.ClientBounds.Height) * StartScreenConstants.PRESS_START_Y_FRACTION);
        }

        public override void Draw(GameTime gameTime)
        {
            if (this.image != null)
                this.spriteBatch.Draw(this.image, this.imageRectangle, this.color);

            this.spriteBatch.DrawString(this.titleSpriteFont, StartScreenConstants.TITLE, this.titlePosition, this.textColor);

            if (this.displayPressStart)
            {
                this.spriteBatch.DrawString(this.pressStartSpriteFont, StartScreenConstants.PRESS_START, this.pressStartPosition, this.textColor);
            }
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            this.previousKeyboardState = this.currentKeyboardState;
            this.currentKeyboardState = Keyboard.GetState();

            if (KeyboardUtility.checkKeyReleased(Keys.Enter, this.currentKeyboardState, this.previousKeyboardState))
            {
                this.Enabled = false;
            }

            this.elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (this.elapsedTime >= StartScreenConstants.PRESS_START_FLASH_DURATION)
            {
                this.displayPressStart = !this.displayPressStart;
                this.elapsedTime = 0;
            }
        }
    }
}
