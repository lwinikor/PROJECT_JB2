using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JezzBall2.Enums;
using Animations;
using JezzBall2.Constants;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace JezzBall2.Balls
{
    class BallFactory
    {
        private static BallFactory instance;

        private Dictionary<BallType, int> widths = new Dictionary<BallType, int>();
        private Dictionary<BallType, int> heights = new Dictionary<BallType, int>();
        private Dictionary<BallType, int> frametimes = new Dictionary<BallType, int>();
        private Dictionary<BallType, int> numFrames = new Dictionary<BallType, int>();
        private Dictionary<BallType, int> numFramesPerRow = new Dictionary<BallType, int>();
        private Dictionary<BallType, int> numFrameRows = new Dictionary<BallType, int>();
        private Dictionary<BallType, float> xVelocities = new Dictionary<BallType, float>();
        private Dictionary<BallType, float> yVelocities = new Dictionary<BallType, float>();
        private Dictionary<BallType, Animation> animations = new Dictionary<BallType, Animation>();

        private BallFactory()
        {
            this.widths.Add(BallType.NORMAL, BallConstants.BALL_WIDTH);
            this.heights.Add(BallType.NORMAL, BallConstants.BALL_HEIGHT);
            this.frametimes.Add(BallType.NORMAL, BallConstants.BALL_FRAMETIME);
            this.numFrames.Add(BallType.NORMAL, BallConstants.BALL_NUM_FRAMES);
            this.numFramesPerRow.Add(BallType.NORMAL, BallConstants.BALL_NUM_FRAMES_PER_ROW);
            this.numFrameRows.Add(BallType.NORMAL, BallConstants.BALL_NUM_FRAME_ROWS);
            this.xVelocities.Add(BallType.NORMAL, BallConstants.BALL_INIT_X_VELOCITY);
            this.yVelocities.Add(BallType.NORMAL, BallConstants.BALL_INIT_Y_VELOCITY);
        }

        public static BallFactory getInstance()
        {
            if (instance == null)
            {
                instance = new BallFactory();
            }

            return instance;
        }

        public void loadContent(Dictionary<BallType, Texture2D> textures)
        {
            Animation normalAnimation = new Animation();
            normalAnimation.initialize(textures[BallType.NORMAL], new Vector2(), this.widths[BallType.NORMAL],
                this.heights[BallType.NORMAL], this.numFrames[BallType.NORMAL], this.numFrameRows[BallType.NORMAL], this.numFramesPerRow[BallType.NORMAL], this.frametimes[BallType.NORMAL],
                Color.White, 1.0f, true);

            this.animations.Add(BallType.NORMAL, normalAnimation);
        }

        public Ball getBall(BallType type)
        {
            switch (type)
            {
                case BallType.NORMAL:
                    return new Ball((Animation) this.animations[BallType.NORMAL].Clone(), this.widths[BallType.NORMAL], 
                        this.heights[BallType.NORMAL], this.xVelocities[BallType.NORMAL], this.yVelocities[BallType.NORMAL]);
                default:
                    return new Ball((Animation) this.animations[BallType.NORMAL].Clone(), this.widths[BallType.NORMAL], 
                        this.heights[BallType.NORMAL], this.xVelocities[BallType.NORMAL], this.yVelocities[BallType.NORMAL]);
            }
        }
    }
}
