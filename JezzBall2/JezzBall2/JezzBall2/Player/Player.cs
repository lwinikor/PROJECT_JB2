using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using Animations;
using Microsoft.Xna.Framework.Graphics;
using JezzBall2.Interfaces;
using JezzBall2.Stages;

namespace JezzBall2.Players
{
    class Player : IMoveable
    {
        protected Animation standingAnimation;
        protected Animation runningAnimation;
        protected Animation jumpingAnimation;

        protected Vector2 position;

        protected int health;
        protected int width;
        protected int height;
        protected float speed;
        protected float jumpSpeed;
        protected Stage stage;

        protected Boolean reverse;

        public void setReverse(Boolean reverse)
        {
            this.reverse = reverse;
        }

        public int getWidth()
        {
            return this.width;
        }

        public int getHeight()
        {
            return this.height;
        }

        public Vector2 getPosition()
        {
            return this.position;
        }

        public void setPosition(Vector2 position)
        {
            this.position = position;
        }

        public void setPositionX(float X)
        {
            this.position.X = X;
        }

        public void setPositionY(float Y)
        {
            this.position.Y = Y;
        }

        public float getSpeed()
        {
            return this.speed;
        }

        public void setStage(Stage stage)
        {
            this.stage = stage;
        }

        public Player(Animation standingAnimation, Animation runningAnimation, Animation jumpingAnimation, Vector2 position, int width, int height, int health, float speed, float jumpSpeed)
        {
            this.standingAnimation = standingAnimation;
            this.runningAnimation = runningAnimation;
            this.jumpingAnimation = jumpingAnimation;
            this.position = position;
            this.width = width;
            this.height = height;
            this.health = health;
            this.speed = speed;
            this.jumpSpeed = jumpSpeed;
        }
        
        public void update(GameTime gameTime)
        {
            this.standingAnimation.setPosition(Vector2.Add(this.position, this.stage.getDrawOffset()));
            this.standingAnimation.update(gameTime);
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (reverse)
                this.standingAnimation.draw(spriteBatch, SpriteEffects.FlipHorizontally);
            else
                this.standingAnimation.draw(spriteBatch);
        }
    }
}
