using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JezzBall2.Utility
{
    static class DrawUtility
    {
        public static void drawHollowRectangle(SpriteBatch spriteBatch, Texture2D borderTexture, Color color, int borderWidth, int top, int left, int height, int width)
        {
            spriteBatch.Draw(borderTexture, new Rectangle(left, top, borderWidth, height), color); //left
            spriteBatch.Draw(borderTexture, new Rectangle(width + left, top, borderWidth, height), color); //right
            spriteBatch.Draw(borderTexture, new Rectangle(left, top, width, borderWidth), color); //top
            spriteBatch.Draw(borderTexture, new Rectangle(left, height + top, width, borderWidth), color); //bottom
        }
    }
}
