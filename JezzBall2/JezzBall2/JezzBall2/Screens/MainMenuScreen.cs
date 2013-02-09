using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JezzBall2.Constants;
using JezzBall2.Enums;

namespace JezzBall2.Screens
{
    class MainMenuScreen : GameScreen
    {
        protected readonly String[] menuItems = { "SURVIVAL", "VS", "CREDITS", "EXIT" };
        protected MenuComponent menuComponent;
        protected Texture2D image;
        protected Rectangle imageRectangle;
        protected Color color;

        public int SelectedIndex
        {
            get { return this.menuComponent.SelectedIndex; }
            set { this.menuComponent.SelectedIndex = value; }
        }

        public bool SelectionConfirmed
        {
            get { return this.menuComponent.SelectionConfirmed; }
            set { this.menuComponent.SelectionConfirmed = value; }
        }

        public override void Update(GameTime gameTime)
        {
            if (this.SelectionConfirmed)
            {
                this.SelectionConfirmed = false;
                switch (this.SelectedIndex)
                {
                    case (int)MainMenu.SURVIVAL:
                        ((Game1)this.game).switchToAction();
                        break;
                    case (int)MainMenu.VS:
                        break;
                    case (int)MainMenu.CREDITS:
                        ((Game1) this.game).switchToCredits();
                        break;
                    case (int)MainMenu.EXIT:
                    default:
                        this.game.Exit();
                        break;
                }
            }  
            base.Update(gameTime);
        }


        public MainMenuScreen(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D image, Color color)
            : base(game, spriteBatch)
        {
            this.menuComponent = new MenuComponent(game, spriteBatch, spriteFont, this.menuItems, MainMenuConstants.SPACING, Color.White, Color.Red);
            this.components.Add(this.menuComponent);
            this.image = image;
            this.imageRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
            this.color = color;
        }
        
        public override void Draw(GameTime gameTime)
        {
            if (this.image != null)
                this.spriteBatch.Draw(this.image, this.imageRectangle, this.color);
            base.Draw(gameTime);
        }
    }
}
