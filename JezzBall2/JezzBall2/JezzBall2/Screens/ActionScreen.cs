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
        protected HudComponent hud;

        public ActionScreen(Game game, SpriteBatch spriteBatch, Stage stage, List<Player> players, HudComponent hud)
            : base(game, spriteBatch)
        {
            this.stage = stage;
            this.players = players;
            this.balls = new List<Ball>();
            this.hud = hud;
            this.Components.Add(hud);
        }

        public override void Update(GameTime gameTime)
        {
            this.stage.update(gameTime);
            this.currentKeyboardState = Keyboard.GetState();

            this.ballGeneration(gameTime);

            foreach (Player p in this.players)
            {
                if (this.currentKeyboardState.IsKeyDown(Keys.Right))
                {
                    p.move(Keys.Right);
                }
                if (this.currentKeyboardState.IsKeyDown(Keys.Left))
                {
                    p.move(Keys.Left);
                }

                this.setPlayerShieldAngle(p);
                p.update(gameTime);
            }
            foreach (Ball b in this.balls)
            {
                b.update(gameTime);
            }

            base.Update(gameTime);

            this.previousKeyboardState = this.currentKeyboardState;
        }

        public void setPlayerShieldAngle(Player p)
        {
            if (this.currentKeyboardState.IsKeyDown(Keys.W) && this.currentKeyboardState.IsKeyDown(Keys.D))
                p.setShieldAngle(45);
            else if (this.currentKeyboardState.IsKeyDown(Keys.A) && this.currentKeyboardState.IsKeyDown(Keys.W))
                p.setShieldAngle(135);
            else if (this.currentKeyboardState.IsKeyDown(Keys.S) && this.currentKeyboardState.IsKeyDown(Keys.A))
                p.setShieldAngle(225);
            else if (this.currentKeyboardState.IsKeyDown(Keys.D) && this.currentKeyboardState.IsKeyDown(Keys.S))
                p.setShieldAngle(315);
            else if (this.currentKeyboardState.IsKeyDown(Keys.D))
                p.setShieldAngle(0);    
            else if (this.currentKeyboardState.IsKeyDown(Keys.W))
                p.setShieldAngle(90);
            else if (this.currentKeyboardState.IsKeyDown(Keys.A))
                p.setShieldAngle(180);
            else if (this.currentKeyboardState.IsKeyDown(Keys.S))
                p.setShieldAngle(270);
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
            
            foreach (Ball b in this.balls)
            {
                b.draw(spriteBatch);
            }

            foreach (Player p in this.players)
            {
                p.draw(spriteBatch);
            }

            base.Draw(gameTime);
        }
    }
}
