// Nacho test comment for commit
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Animations;
using JezzBall2.Interfaces;
using JezzBall2.Stages;
using JezzBall2.Utility;

namespace JezzBall2.Balls
{
    class Ball : IMoveable
    {
        protected Animation animation;
        protected Vector2 position;
        protected bool active;
        protected int width;
        protected int height;
        protected float horizontalVelocity;
        protected float verticalVelocity;
        protected Stage stage;

        public void setAnimation(Animation animation)
        {
            this.animation = animation;
        }

        public void setPosition(Vector2 position)
        {
            this.position = position;
            this.animation.setPosition(this.position);
        }

        public void setHorizontalVelocity(float horizontalVelocity)
        {
            this.horizontalVelocity = horizontalVelocity;
        }

        public void setVerticalVelocity(float verticalVelocity)
        {
            this.verticalVelocity = verticalVelocity;
        }

        public void setStage(Stage stage)
        {
            this.stage = stage;
        }

        public Ball(Animation animation, int width, int height, float horizontalVelocity, float verticalVelocity)
        {
            this.animation = animation;
            this.width = width;
            this.height = height;
            this.horizontalVelocity = horizontalVelocity;
            this.verticalVelocity = verticalVelocity;
            this.active = true;
        }

        public Ball(Animation animation, Vector2 position, int width, int height, float horizontalVelocity, float verticalVelocity, Stage stage)
        {
            this.animation = animation;
            this.position = position;
            this.width = width;
            this.height = height;
            this.horizontalVelocity = horizontalVelocity;
            this.verticalVelocity = verticalVelocity;
            this.stage = stage;
            this.active = true;
        }

        public void initialize(Animation animation, Vector2 position, float horizontalVelocity, float verticalVelocity, Stage stage)
        {
            this.animation = animation;
            this.position = position;
            this.horizontalVelocity = horizontalVelocity;
            this.verticalVelocity = verticalVelocity;
            this.stage = stage;
            this.active = true;
        }

        public Vector2 getPosition()
        {
            return this.position;
        }

        public void update(GameTime gameTime)
        {
            if (this.active)
            {
                this.position.X += this.horizontalVelocity;
                this.position.Y += this.verticalVelocity;

                if (this.position.X <= 0)
                {
                    this.position.X = 0;
                    this.horizontalVelocity *= -1;
                }
                else if (this.position.X + this.width >= this.stage.getWidth())
                {
                    this.position.X = this.stage.getWidth() - this.width;
                    this.horizontalVelocity *= -1;
                }

                if (this.position.Y <= 0)
                {
                    this.position.Y = 0;
                    this.verticalVelocity *= -1;
                }
                else if (this.position.Y + this.height >= this.stage.getHeight())
                {
                    this.position.Y = this.stage.getHeight() - this.height;
                    this.verticalVelocity *= -1;
                }

                this.animation.setPosition(Vector2.Add(this.position, this.stage.getDrawOffset()));
                this.animation.update(gameTime);
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (this.active)
            {
                this.animation.draw(spriteBatch);
                //DrawUtility.drawHollowRectangle(spriteBatch, 1, (int)this.position.X, (int)this.position.Y, this.height, this.width);
            }
        }
    }
}
