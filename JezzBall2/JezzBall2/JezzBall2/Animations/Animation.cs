using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Animations
{
    public class Animation
    {
        // The image representing the collection of images used for animation
        protected Texture2D spriteStrip;

        // The scale used to display the sprite strip
        protected float scale;

        // The time since we last updated the frame
        protected int elapsedTime;

        // The time we display a frame until the next one
        protected int frameTime;

        // The number of frames that the animation contains
        protected int frameCount;

        // The index of the current frame we are displaying
        protected int currentFrame;

        // The color of the frame we will be displaying
        protected Color color;

        // The area of the image strip we want to display
        protected Rectangle sourceRect = new Rectangle();

        // The area where we want to display the image strip in the game
        protected Rectangle destinationRect = new Rectangle();

        // Width of a given frame
        protected int frameWidth;

        // Height of a given frame
        protected int frameHeight;

        // The state of the Animation
        protected bool active;


        // Determines if the animation will keep playing or deactivate after one run
        protected bool looping;

        // Width of a given frame
        protected Vector2 position;


        public Vector2 getPosition()
        {
            return this.position;
        }

        public void setPosition(Vector2 position)
        {
            this.position = position;
        }

        public void initialize(Animation animation)
        {
            this.color = animation.color;
            this.frameWidth = animation.frameWidth;
            this.frameHeight = animation.frameHeight;
            this.frameCount = animation.frameCount;
            this.frameTime = animation.frameTime;
            this.scale = animation.scale;

            this.looping = animation.looping;
            this.position = animation.position;
            this.spriteStrip = animation.spriteStrip;

            // Set the time to zero
            this.elapsedTime = 0;
            this.currentFrame = 0;

            // Set the Animation to active by default
            this.active = true;
        }

        public void initialize(Texture2D texture, Vector2 position,
                                int frameWidth, int frameHeight, int frameCount,
                                int frametime, Color color, float scale, bool looping)
        {
            // Keep a local copy of the values passed in
            this.color = color;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frametime;
            this.scale = scale;

            this.looping = looping;
            this.position = position;
            this.spriteStrip = texture;

            // Set the time to zero
            this.elapsedTime = 0;
            this.currentFrame = 0;

            // Set the Animation to active by default
            this.active = true;
        }

        public virtual void update(GameTime gameTime)
        {
            // Do not update the game if we are not active
            if (this.active == false)
                return;

            // Update the elapsed time
            this.elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            // If the elapsed time is larger than the frame time
            // we need to switch frames
            if (this.elapsedTime > this.frameTime)
            {
                // Move to the next frame
                this.currentFrame++;

                // If the currentFrame is equal to frameCount reset currentFrame to zero
                if (this.currentFrame == this.frameCount)
                {
                    this.currentFrame = 0;
                    // If we are not looping deactivate the animation
                    if (this.looping == false)
                        this.active = false;
                }

                // Reset the elapsed time to zero
                this.elapsedTime = 0;
            }

            // the rectangle in the image that we are grabbing
            this.sourceRect = new Rectangle(this.currentFrame * this.frameWidth + (1 * this.currentFrame), 0, this.frameWidth, this.frameHeight);

            // the rectangle on screen where this will be drawn
            this.destinationRect = new Rectangle((int)this.position.X, (int)this.position.Y, (int)(this.frameWidth * this.scale), (int)(this.frameHeight * this.scale));
        }

        // Draw the Animation Strip
        public void draw(SpriteBatch spriteBatch)
        {
            // Only draw the animation when we are active
            if (this.active)
            {
                spriteBatch.Draw(this.spriteStrip, this.destinationRect, this.sourceRect, this.color);
            }
        }

        public void draw(SpriteBatch spriteBatch, SpriteEffects spriteEffects)
        {
            // Only draw the animation when we are active
            if (this.active)
            {
                spriteBatch.Draw(this.spriteStrip, this.destinationRect, this.sourceRect, this.color, 0f, Vector2.Zero, spriteEffects, 0f);
            }
        }
    }
}
