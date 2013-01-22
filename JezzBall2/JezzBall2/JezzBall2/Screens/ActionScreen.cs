using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JezzBall2.Stages;

namespace JezzBall2.Screens
{
    class ActionScreen : GameScreen
    {
        protected Stage stage;

        public ActionScreen(Game game, SpriteBatch spriteBatch, Stage stage)
            : base(game, spriteBatch)
        {
            this.stage = stage;
        }

        public override void Draw(GameTime gameTime)
        {
            this.stage.draw(this.spriteBatch);
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            this.stage.update(gameTime);
            base.Update(gameTime);
        }
    }
}
