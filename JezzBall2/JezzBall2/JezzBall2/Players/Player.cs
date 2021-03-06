﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using Animations;
using Microsoft.Xna.Framework.Graphics;
using JezzBall2.Interfaces;
using JezzBall2.Stages;
using JezzBall2.Constants;
using Microsoft.Xna.Framework.Input;

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

        protected Shield shield;

        public Vector2 getDrawOffset()
        {
            return this.stage.getDrawOffset();
        }

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

        public void setShieldAngle(float activeAngle)
        {
            this.shield.setActiveAngle(activeAngle);
        }

        public Vector2 getCenterPosition()
        {
            return new Vector2(this.position.X + (this.width / 2), this.position.Y + (this.height / 2));
        }

        public Player(Animation standingAnimation, Animation runningAnimation, Animation jumpingAnimation, Vector2 position, int width, int height, int health, float speed, float jumpSpeed, Shield shield)
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
            this.shield = shield;
            this.shield.setPlayer(this);
        }
        
        public void update(GameTime gameTime)
        {
            this.standingAnimation.setPosition(Vector2.Add(this.position, this.stage.getDrawOffset()));
            this.standingAnimation.update(gameTime);
            this.shield.update(gameTime);
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (reverse)
                this.standingAnimation.draw(spriteBatch, SpriteEffects.FlipHorizontally);
            else
                this.standingAnimation.draw(spriteBatch);
            
            this.shield.draw(spriteBatch);
        }

        public void move(Keys key)
        {
            if (key == Keys.Left)
            {
                this.reverse = true;
                this.position.X -= this.speed;
                if (this.position.X < 0)
                    this.position.X = 0;
            }
            else if (key == Keys.Right)
            {
                this.reverse = false;
                this.position.X += this.speed;
                if (this.position.X > this.stage.getWidth() - this.width)
                {
                    this.position.X = this.stage.getWidth() - this.width;
                }
            }
        }

        public void reset()
        {
            this.position = new Vector2(stage.getWidth() / 2, stage.getHeight() - PlayerConstants.PLAYER_HEIGHT);
            this.reverse = false;
            this.setShieldAngle(0);
        }
    }
}
