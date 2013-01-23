using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using Animations;
using Microsoft.Xna.Framework.Graphics;
using JezzBall2.Interfaces;

namespace JezzBall2.Players
{
    class Player : IMoveable
    {
        public Animation standingAnimation;
        public Animation runningAnimation;
        public Animation jumpingAnimation;

        public Vector2 position;

        public int health;
        public int width;
        public int height;
        public float speed;
        public float jumpSpeed;
        
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

        public Vector2 getPosition()
        {
            return this.position;
        }

        public void update(GameTime gameTime)
        {
        }

        public void draw(SpriteBatch spriteBatch)
        {
        }
    }
}
