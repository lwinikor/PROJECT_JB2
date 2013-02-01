using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JezzBall2.Utility
{
    static class PositionUtility
    {
        public static Vector2 getRandomPosition(int width, int height)
        {
            Random rand = new Random();
            int x = rand.Next(0, width);
            int y = rand.Next(0, height);

            return new Vector2(x, y);
        }
    }
}
