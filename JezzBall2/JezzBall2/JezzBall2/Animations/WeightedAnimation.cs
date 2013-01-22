using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Animations
{
    public class WeightedAnimation : Animation
    {
        protected int[] frametimes;


        public void initialize(Texture2D texture, Vector2 position,
                        int frameWidth, int frameHeight, int frameCount,
                        int[] frametimes, Color color, float scale, bool looping)
        {
            this.frametimes = frametimes;

            base.initialize(texture, position, frameWidth, frameHeight, frameCount, this.frametimes[0], color, scale, looping);
        }

        public override void update(GameTime gameTime)
        {

            this.frameTime = this.frametimes[this.currentFrame];
            base.update(gameTime);
        }
    }
}
