// Nacho test comment for commit
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Animations;
using JezzBall2.Interfaces;
 
namespace JezzBall2.Balls
{
    class Ball : IMoveable
    {
        private Animation animation;
        private Vector2 position;
        private bool active;
        private int width;
        private int height;
        private float horizontalVelocity;
        private float verticalVelocity;

        public Ball(Animation animation, Vector2 position, bool active, int width, int height, float horizontalVelocity, float verticalVelocity)
        {
            this.animation = animation;
            this.position = position;
            this.active = active;
            this.width = width;
            this.height = height;
            this.horizontalVelocity = horizontalVelocity;
            this.verticalVelocity = verticalVelocity;
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

                this.animation.setPosition(this.position);
                this.animation.update(gameTime);
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (this.active)
            {
                this.animation.draw(spriteBatch);
            }
        }
    }
}
