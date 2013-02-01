using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ScreenManager;
using JezzBall2.Constants;

namespace JezzBall2.Screens
{
    class PauseScreen : GameScreen
    {
        protected readonly String[] menuItems = { "RESUME", "RETURN TO MAIN MENU" };
        protected MenuComponent menuComponent;

        protected Color backgroundColor = Color.Black;
        protected Color textColor = Color.White;

        protected Texture2D image;
        protected Rectangle imageRectangle;
        protected Color color;

        protected KeyboardState currentKeyboardState;
        protected KeyboardState previousKeyboardState;

        protected SpriteFont pauseSpriteFont;
        protected SpriteFont menuSpriteFont;

        protected Vector2 pausePosition;
        protected Vector2 menuPosition;

        protected GameScreen prevScreen;
        protected GameScreen mainMenuScreen;

        public int SelectedIndex
        {
            get { return this.menuComponent.SelectedIndex; }
            set { this.menuComponent.SelectedIndex = value; }
        }

        public PauseScreen(Game game, SpriteBatch spriteBatch, SpriteFont pauseSpriteFont, SpriteFont menuSpriteFont, Texture2D image, Color color, GameScreen prevScreen, GameScreen mainMenuScreen)
            : base(game, spriteBatch)
        {
            this.menuComponent = new MenuComponent(game, spriteBatch, menuSpriteFont, this.menuItems, PauseScreenConstants.SPACING, Color.White, Color.Red);
            this.components.Add(this.menuComponent);
            this.pauseSpriteFont = pauseSpriteFont;
            this.menuSpriteFont = menuSpriteFont;
            this.image = image;
            this.imageRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
            this.color = color;
            this.prevScreen = prevScreen;
            this.mainMenuScreen = mainMenuScreen;
            this.setTextPositions();
        }

        public void setTextPositions()
        {
            float height = 0;
            float width = 0;

            Vector2 size = this.pauseSpriteFont.MeasureString(PauseScreenConstants.PAUSE);
            width = size.X;
            height = size.Y;

            this.pausePosition = new Vector2((Game.Window.ClientBounds.Width - width) / 2, (Game.Window.ClientBounds.Height) * PauseScreenConstants.PAUSE_Y_FRACTION);
        }

        public override void Draw(GameTime gameTime)
        {
            if (this.image != null)
                this.spriteBatch.Draw(this.image, this.imageRectangle, this.color);

            this.spriteBatch.DrawString(this.pauseSpriteFont, PauseScreenConstants.PAUSE, this.pausePosition, this.textColor);

            base.Draw(gameTime);
        }
    }
}
