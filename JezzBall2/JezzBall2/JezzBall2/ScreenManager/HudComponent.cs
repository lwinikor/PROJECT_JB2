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
using JezzBall2.Constants;

namespace ScreenManager
{
    public class HudComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        double time;
        SpriteFont timerFont;
        Vector2 timerPosition;
        Color timerColor;
        SpriteBatch spriteBatch;

        public HudComponent(Game game, SpriteBatch spriteBatch, SpriteFont timerFont, Vector2 timerPosition, Color timerColor)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.timerFont = timerFont;
            this.timerPosition = timerPosition;
            this.timerColor = timerColor;
            this.time = 0;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            this.time += gameTime.ElapsedGameTime.TotalMilliseconds;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            String timerText = String.Format(HudConstants.TIMER_FORMAT, this.time / 1000);
            this.spriteBatch.DrawString(this.timerFont, timerText, this.timerPosition, this.timerColor); 
        }

        public void pause()
        {
            this.Enabled = false;
        }

        public void unpause()
        {
            this.Enabled = true;
        }
    }
}