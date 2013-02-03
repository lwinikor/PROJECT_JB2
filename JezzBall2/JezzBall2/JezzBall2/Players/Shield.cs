using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace JezzBall2.Players
{
    class Shield
    {
        Player player;
        Texture2D inactiveTexture;
        Texture2D activeTexture;
        float radius;
        Vector2 position;
        Vector2 centerPosition;
        Color color;

        public Shield(Texture2D inactiveTexture, Texture2D activeTexture, float radius, Color color)
        {
            this.inactiveTexture = inactiveTexture;
            this.activeTexture = activeTexture;
            this.radius = radius;
            this.color = color;
            position = Vector2.Zero;
            centerPosition = Vector2.Zero;
        }

        public void setPlayer(Player player)
        {
            this.player = player;
        }

        public void update(GameTime gameTime)
        {
            Vector2 playerCenter = this.player.getCenterPosition();
            this.position.X = playerCenter.X - radius;
            this.position.Y = playerCenter.Y - radius;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.inactiveTexture, this.getDestinationRect(), this.color);
        }

        public Rectangle getDestinationRect()
        {
            Vector2 drawPosition = Vector2.Add(this.position, this.player.getDrawOffset());
            return new Rectangle((int)drawPosition.X, (int)drawPosition.Y, (int)this.radius * 2, (int)this.radius * 2);
        }
    }
}
