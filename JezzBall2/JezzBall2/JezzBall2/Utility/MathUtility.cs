using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JezzBall2.Utility
{
    static class MathUtility
    {
        public static Boolean equals(float x, float y, float precision)
        {
            return (Math.Abs(x - y) <= precision);
        }
    }
}
