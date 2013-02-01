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
using JezzBall2.Utility;
using JezzBall2.Enums;

namespace JezzBall2.Screens
{
    class ActionScreen : GameScreen
    {
        protected Stage stage;
        protected List<Player> players;
        protected List<Ball> balls;
        protected KeyboardState currentKeyboardState;
        protected KeyboardState previousKeyboardState;
        protected int elapsedTime;

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

            this.ballGeneration(gameTime);

            foreach (Player p in this.players)
            {
                if(this.currentKeyboardState.IsKeyDown(Keys.Right))
                {
                    p.setReverse(false);
                    p.setPositionX(p.getPosition().X + p.getSpeed());
                    if(p.getPosition().X > this.stage.getWidth() - p.getWidth())
                        p.setPositionX(this.stage.getWidth() - p.getWidth());
                }
                if (this.currentKeyboardState.IsKeyDown(Keys.Left))
                {
                    p.setReverse(true);
                    p.setPositionX(p.getPosition().X - p.getSpeed());
                    if (p.getPosition().X < 0)
                        p.setPositionX(0);
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

        public void ballGeneration(GameTime gameTime)
        {
            this.elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (this.elapsedTime >= this.stage.getBallGenFrequency())
            {
                Ball b = BallFactory.getInstance().getBall(BallType.NORMAL);
                b.setPosition(PositionUtility.getRandomPosition(this.stage.getWidth(), this.stage.getHeight()));
                b.setStage(this.stage);

                this.balls.Add(b);
                this.elapsedTime = 0;
            }
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
