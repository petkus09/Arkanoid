using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidWin8.Classes
{
    public static class Input
    {
        public static List<GestureSample>Gestures;
 
        static Input()
        {
            Gestures = new List<GestureSample>();
        }

        public static Vector2 GetKeyboardInputDirection(PlayerIndex playerIndex)
        {
            Vector2 direction = Vector2.Zero;
            KeyboardState keyboardState = Keyboard.GetState(playerIndex);

            if (playerIndex == PlayerIndex.One)
            {
                if (keyboardState.IsKeyDown(Keys.Left))
                    direction.X += -1;
                if (keyboardState.IsKeyDown(Keys.Right))
                    direction.X += 1;
            }

            return direction;
        }

        public static void ProcessTouchInput(out Vector2 player1Velocity)
        {
            Gestures.Clear();
            while (TouchPanel.IsGestureAvailable)
            {
                Gestures.Add(TouchPanel.ReadGesture());
            }
            player1Velocity = Vector2.Zero;
 
            foreach (GestureSample gestureSample in Gestures)
            {
                player1Velocity.X += gestureSample.Delta.X;
            }
        }
    }
}
