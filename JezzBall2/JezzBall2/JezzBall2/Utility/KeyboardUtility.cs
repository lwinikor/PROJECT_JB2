using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace JezzBall2.Utility
{
    static class KeyboardUtility
    {
        public static bool checkKeyReleased(Keys theKey, KeyboardState currentKeyboardState, KeyboardState previousKeyboardState)
        {
            return currentKeyboardState.IsKeyUp(theKey) && previousKeyboardState.IsKeyDown(theKey);
        }
    }
}
