using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using JezzBall2.Utility;


namespace ScreenManager
{
    public class MenuComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected String[] menuItems;
        protected int selectedIndex;
        

        protected Color normal;
        protected Color hilite;

        protected KeyboardState currentKeyboardState;
        protected KeyboardState previousKeyboardState;

        protected SpriteBatch spriteBatch;
        protected SpriteFont spriteFont;

        protected Vector2 position;

        protected int spacing;

        public bool SelectionConfirmed = false;

        public int SelectedIndex
        {
            get { return this.selectedIndex; }
            set { this.selectedIndex = value; }
        }

        public MenuComponent(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, String[] menuItems, int spacing, Color normal, Color hilite)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.menuItems = menuItems;
            this.spacing = spacing;
            this.normal = normal;
            this.hilite = hilite;
            this.MeasureMenu();
        }

        private void MeasureMenu()
        {
            float height = 0;
            float width = 0;

            foreach (String item in this.menuItems)
            {
                Vector2 size = this.spriteFont.MeasureString(item);
                if (size.X > width)
                    width = size.X;
                height += this.spriteFont.LineSpacing + this.spacing;
            }

            this.position = new Vector2((Game.Window.ClientBounds.Width - width) / 2,
                (Game.Window.ClientBounds.Height - height) / 2);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            this.currentKeyboardState = Keyboard.GetState();

            if (KeyboardUtility.checkKeyReleased(Keys.Down, this.currentKeyboardState, this.previousKeyboardState))
            {
                this.selectedIndex++;
                if (this.selectedIndex == this.menuItems.Length)
                    this.selectedIndex = 0;
            }
            if (KeyboardUtility.checkKeyReleased(Keys.Up, this.currentKeyboardState, this.previousKeyboardState))
            {
                this.selectedIndex--;
                if (this.selectedIndex < 0)
                    this.selectedIndex = this.menuItems.Length - 1;
            }
            if (KeyboardUtility.checkKeyReleased(Keys.Enter, this.currentKeyboardState, this.previousKeyboardState))
            {
                this.SelectionConfirmed = true;
            }

            base.Update(gameTime);

            this.previousKeyboardState = this.currentKeyboardState;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Vector2 location = position;
            Color color;

            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == this.selectedIndex)
                    color = this.hilite;
                else
                    color = this.normal;

                this.spriteBatch.DrawString(this.spriteFont, this.menuItems[i], location, color);
                location.Y += this.spriteFont.LineSpacing + this.spacing;
            }
        }
    }
}
