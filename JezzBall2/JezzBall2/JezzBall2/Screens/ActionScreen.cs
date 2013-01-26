using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        protected KeyboardState currentKeyboardState;
        protected KeyboardState previousKeyboardState;


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
            this.currentKeyboardState = Keyboard.GetState();

            foreach (Player p in this.players)
            {
                if(this.currentKeyboardState.IsKeyDown(Keys.Right))
                {
                    p.position.X += p.speed;
                    if(p.position.X > this.stage.playableRight - p.width)
                        p.position.X = this.stage.playableRight - p.width;
                }
                if (this.currentKeyboardState.IsKeyDown(Keys.Left))
                {
                    p.position.X -= p.speed;
                    if (p.position.X < this.stage.playableLeft)
                        p.position.X = this.stage.playableLeft;
                }

                p.update(gameTime);
            }
            foreach (Ball b in this.balls)
            {
                b.update(gameTime);
            }

            base.Update(gameTime);

            this.previousKeyboardState = this.currentKeyboardState;
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
