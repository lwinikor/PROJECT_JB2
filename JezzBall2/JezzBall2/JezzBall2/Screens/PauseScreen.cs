using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ScreenManager;
using JezzBall2.Constants;
using JezzBall2.Enums;

namespace JezzBall2.Screens
{
    class PauseScreen : GameScreen
    {
        protected readonly String[] menuItems = { "RESUME", "RESTART", "MAIN MENU" };
        protected MenuComponent menuComponent;

        protected Color backgroundColor = Color.Black;
        protected Color textColor = Color.White;

        protected Color transparentBgColor;
        protected Texture2D transparentBg;
        protected Texture2D image;
        protected Rectangle imageRectangle;
        protected Color color;

        protected KeyboardState currentKeyboardState;
        protected KeyboardState previousKeyboardState;

        protected SpriteFont pauseSpriteFont;
        protected SpriteFont menuSpriteFont;

        protected Vector2 pausePosition;
        protected Vector2 menuPosition;

        protected ActionScreen actionScreen;

        public MenuComponent getMenuComponent()
        {
            return this.menuComponent;
        }
        
        public void setActionScreen(ActionScreen actionScreen)
        {
            this.actionScreen = actionScreen;
        }

        public PauseScreen(Game game, SpriteBatch spriteBatch, SpriteFont pauseSpriteFont, SpriteFont menuSpriteFont, Texture2D image, Color color, ActionScreen actionScreen)
            : base(game, spriteBatch)
        {
            this.menuComponent = new MenuComponent(game, spriteBatch, menuSpriteFont, this.menuItems, PauseScreenConstants.SPACING, Color.White, Color.Red);
            this.components.Add(this.menuComponent);
            this.pauseSpriteFont = pauseSpriteFont;
            this.menuSpriteFont = menuSpriteFont;
            this.image = image;
            this.imageRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
            this.color = color;
            this.actionScreen = actionScreen;
            this.setTextPositions();
            this.setTransparentBg();

        }

        private void setTransparentBg()
        {
            this.transparentBg = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            this.transparentBg.SetData(new[] { Color.Black });
            this.transparentBgColor = new Color(255, 255, 255, PauseScreenConstants.PAUSE_BG_ALPHA);
        }

        private void setTextPositions()
        {
            float height = 0;
            float width = 0;

            Vector2 size = this.pauseSpriteFont.MeasureString(PauseScreenConstants.PAUSE);
            width = size.X;
            height = size.Y;

            this.pausePosition = new Vector2((Game.Window.ClientBounds.Width - width) / 2, (Game.Window.ClientBounds.Height) * PauseScreenConstants.PAUSE_Y_FRACTION);
        }

        public override void Update(GameTime gameTime)
        {
            if (this.menuComponent.SelectionConfirmed)
            {
                this.menuComponent.SelectionConfirmed = false;
                switch (this.menuComponent.SelectedIndex)
                {
                    case (int) PauseMenu.RESTART:
                        this.actionScreen.reset();
                        break;
                    case (int) PauseMenu.RETURN:
                        this.actionScreen.reset();
                        ((Game1) this.game).switchToMainMenu(true);
                        break;
                    case (int) PauseMenu.RESUME:
                    default:
                        this.actionScreen.unpause();
                        break;
                }
                this.menuComponent.SelectedIndex = (int) PauseMenu.RESUME;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.spriteBatch.Draw(this.transparentBg, new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height), this.transparentBgColor);

            if (this.image != null)
                this.spriteBatch.Draw(this.image, this.imageRectangle, this.color);

            this.spriteBatch.DrawString(this.pauseSpriteFont, PauseScreenConstants.PAUSE, this.pausePosition, this.textColor);

            base.Draw(gameTime);
        }
    }
}
