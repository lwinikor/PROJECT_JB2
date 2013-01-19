using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Animations
{
    public class ReversibleAnimation : Animation
    {
        public Boolean reverse;

        public override void update(GameTime gameTime)
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
                if (this.reverse)
                {
                    this.currentFrame--;

                    if (this.currentFrame < 0)
                    {
                        this.currentFrame = 1;
                        reverse = false;

                        if (this.looping == false)
                            this.active = false;

                    }
                }
                else
                {
                    // Move to the next frame
                    this.currentFrame++;

                    // If the currentFrame is equal to frameCount reset currentFrame to zero
                    if (this.currentFrame == this.frameCount)
                    {
                        this.currentFrame = this.frameCount - 2;
                        reverse = true;
                        // If we are not looping deactivate the animation
                        if (this.looping == false)
                            this.active = false;
                    }
                }
                // Reset the elapsed time to zero
                this.elapsedTime = 0;
            }

            // the rectangle in the image that we are grabbing
            this.sourceRect = new Rectangle(this.currentFrame * this.frameWidth + (1 * this.currentFrame), 0, this.frameWidth, this.frameHeight);

            // the rectangle on screen where this will be drawn
            this.destinationRect = new Rectangle((int)this.position.X, (int)this.position.Y, (int)(this.frameWidth * this.scale), (int)(this.frameHeight * this.scale));
        }
    }
}
