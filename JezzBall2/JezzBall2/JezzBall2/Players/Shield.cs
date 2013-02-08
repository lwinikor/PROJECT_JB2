using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using JezzBall2.Utility;

namespace JezzBall2.Players
{
    class Shield
    {
        protected static float precision = 0.01f;
        protected Player player;
        protected Texture2D inactiveTexture;
        protected Texture2D activeTexture;
        protected float radius;
        protected Vector2 position;
        protected Color color;
        protected float activeAngle;
        protected float activeDegrees;

        public Shield(Texture2D inactiveTexture, Texture2D activeTexture, float radius, Color color, float activeDegrees)
        {
            this.inactiveTexture = inactiveTexture;
            this.activeTexture = activeTexture;
            this.radius = radius;
            this.color = color;
            this.activeDegrees = activeDegrees;
            position = Vector2.Zero;
        }

        public void setActiveAngle(float activeAngle)
        {
            this.activeAngle = activeAngle;
        }

        public void setPlayer(Player player)
        {
            this.player = player;
        }

        public void update(GameTime gameTime)
        {
            this.position.X = this.player.getCenterPosition().X - radius;
            this.position.Y = this.player.getCenterPosition().Y - radius;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            //inactive part
            spriteBatch.Draw(this.inactiveTexture, this.getInactiveDestinationRect(), this.color);
            //active part
            this.drawActiveShield(spriteBatch);
        }

        private void drawActiveShield(SpriteBatch spriteBatch)
        {
            Rectangle destinationRectangle = this.getActiveDestinationRect();
            Rectangle sourceRectangle =  new Rectangle((int) (destinationRectangle.X - this.position.X - this.player.getDrawOffset().X), 
                (int) (destinationRectangle.Y - this.position.Y - this.player.getDrawOffset().Y), destinationRectangle.Width, destinationRectangle.Height);

            spriteBatch.Draw(this.activeTexture, destinationRectangle, sourceRectangle, this.color);
        }

        private Vector2 getDestinationCoordinate(float angle, Vector2 center)
        {
            float x = center.X + this.radius * (float)Math.Cos(MathHelper.ToRadians(angle));
            float y = center.Y - this.radius * (float)Math.Sin(MathHelper.ToRadians(angle));

            return new Vector2(x, y);
        }

        public Rectangle getActiveDestinationRect()
        {
            float angle1 = this.activeAngle + this.activeDegrees / 2;
            float angle2 = this.activeAngle - this.activeDegrees / 2;

            Vector2 c1 = this.getDestinationCoordinate(angle1, this.player.getCenterPosition());
            Vector2 c2 = this.getDestinationCoordinate(angle2, this.player.getCenterPosition());

            float dist1 = Vector2.Distance(c1, this.position);
            float dist2 = Vector2.Distance(c2, this.position);

            Vector2 drawPosition = Vector2.Zero;
            int width = 0;
            int height = 0;

            float distTop1 = Vector2.Distance(c1, new Vector2(c1.X, this.position.Y));
            float distBottom1 = Vector2.Distance(c1, new Vector2(c1.X, this.position.Y + this.radius * 2));
            float distLeft1 = Vector2.Distance(c1, new Vector2(this.position.X, c1.Y));
            float distRight1 =  Vector2.Distance(c1, new Vector2(this.position.X + this.radius * 2, c1.Y));

            float distTop2 = Vector2.Distance(c2, new Vector2(c2.X, this.position.Y));
            float distBottom2 = Vector2.Distance(c2, new Vector2(c2.X, this.position.Y + this.radius * 2));
            float distLeft2 = Vector2.Distance(c2, new Vector2(this.position.X, c2.Y));
            float distRight2 = Vector2.Distance(c2, new Vector2(this.position.X + this.radius * 2, c2.Y));

            float minDist1 = Math.Min(distRight1, Math.Min(distLeft1, Math.Min(distTop1, distBottom1)));
            float minDist2 = Math.Min(distRight2, Math.Min(distLeft2, Math.Min(distTop2, distBottom2)));

            bool top1 = (minDist1 == distTop1);
            bool bottom1 = (minDist1 == distBottom1);
            bool left1 = (minDist1 == distLeft1);
            bool right1 = (minDist1 == distRight1);

            bool top2 = (minDist2 == distTop2);
            bool bottom2 = (minDist2 == distBottom2);
            bool left2 = (minDist2 == distLeft2);
            bool right2 = (minDist2 == distRight2);

            if (top1 && top2)
            {
                drawPosition = Vector2.Add(new Vector2(Math.Min(c1.X, c2.X), this.position.Y), this.player.getDrawOffset());
                width = (int)(Math.Max(c1.X, c2.X) - Math.Min(c1.X, c2.X));
                height = (int)this.radius;
            }
            else if (top1 && right2)
            {
                drawPosition = Vector2.Add(new Vector2(c1.X, this.position.Y), this.player.getDrawOffset());
                width = (int)(this.position.X + radius * 2 - c1.X);
                height = (int) (c2.Y - this.position.Y);
            }
            else if (right1 && right2)
            {
                drawPosition = Vector2.Add(new Vector2(this.player.getCenterPosition().X, Math.Min(c1.Y, c2.Y)), this.player.getDrawOffset());
                width = (int) this.radius;
                height = (int) (Math.Max(c1.Y, c2.Y) - Math.Min(c1.Y, c2.Y));
            }
            else if (right1 && bottom2)
            {
                drawPosition = Vector2.Add(new Vector2(c2.X, c1.Y), this.player.getDrawOffset());
                width = (int)(this.position.X + radius * 2 - c2.X);
                height = (int)(this.position.Y + radius * 2 - c1.Y);
            }
            else if (bottom1 && bottom2)
            {
                drawPosition = Vector2.Add(new Vector2(Math.Min(c1.X, c2.X), this.player.getCenterPosition().Y), this.player.getDrawOffset());
                width = (int)(Math.Max(c1.X, c2.X) - Math.Min(c1.X, c2.X));
                height = (int)this.radius;
            }
            else if (bottom1 && left2)
            {
                drawPosition = Vector2.Add(new Vector2(this.position.X, c2.Y), this.player.getDrawOffset());
                width = (int) (c1.X - this.position.X);
                height = (int)(this.position.Y + 2 * radius - c2.Y);
            }
            else if (left1 && left2)
            {
                drawPosition = Vector2.Add(new Vector2(this.position.X, Math.Min(c1.Y, c2.Y)), this.player.getDrawOffset());
                width = (int) this.radius;
                height = (int) (Math.Max(c1.Y, c2.Y) - Math.Min(c1.Y, c2.Y));
            }
            else if (left1 && top2)
            {
                drawPosition = Vector2.Add(new Vector2(this.position.X, this.position.Y), this.player.getDrawOffset());
                width = (int) (c2.X - this.position.X);
                height = (int) (c1.Y - this.position.Y);
            }
            else
            {
                //shouldn't get here
            }

            return new Rectangle((int) drawPosition.X, (int) drawPosition.Y, width, height);
        }

        public Rectangle getInactiveDestinationRect()
        {
            Vector2 drawPosition = Vector2.Add(this.position, this.player.getDrawOffset());
            return new Rectangle((int)drawPosition.X, (int)drawPosition.Y, (int)this.radius * 2, (int)this.radius * 2);
        }
    }
}
