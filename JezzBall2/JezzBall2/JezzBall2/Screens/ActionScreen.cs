using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JezzBall2.Stages;
using JezzBall2.Players;
using JezzBall2.Balls;

namespace JezzBall2.Screens
{
    class ActionScreen : GameScreen
    {
        protected Stage stage;
        protected List<Player> players;
        protected List<Ball> balls;


        public ActionScreen(Game game, SpriteBatch spriteBatch, Stage stage, List<Player> players)
            : base(game, spriteBatch)
        {
            this.stage = stage;
            this.players = players;
            this.balls = new List<Ball>();
        }

        public override void Update(GameTime gameTime)
        {
            this.stage.update(gameTime);

            foreach (Player p in this.players)
            {
                p.update(gameTime);
            }
            foreach (Ball b in this.balls)
            {
                b.update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.stage.draw(this.spriteBatch);
            foreach (Player p in this.players)
            {
                p.draw(spriteBatch);
            }
            foreach (Ball b in this.balls)
            {
                b.draw(spriteBatch);
            }
            base.Draw(gameTime);
        }
    }
}
