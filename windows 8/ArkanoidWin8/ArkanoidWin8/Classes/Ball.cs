using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidWin8.Classes
{
    class Ball : GameObject
    {
        public Vector2 velocity;
        public Random random;

        public Ball()
        {
            random = new Random();
        }
        public void Launch(float speed, float screenX, float screenY)
        {
            position = new Vector2(screenX, screenY);
            // get a random + or - 60 degrees angle to the right
            float rotation = (float)( (random.NextDouble() * (Math.PI / 1.5f) - Math.PI / 3));

            velocity.X = (float)Math.Sin(rotation);
            velocity.Y = (float)Math.Cos(rotation);
            velocity.Y *= -1; //launch to the left
            velocity *= speed;
        }

        public void CheckWallCollision(float BOUND)
        {
            if (position.X < BOUND)
            {
                position.X = BOUND;
                velocity.X *= -1;
            }
            if (position.X + texture.Width > Arkanoid.screenWidth - BOUND)
            {
                position.X = Arkanoid.screenWidth - texture.Width - BOUND;
                velocity.X *= -1;
            }
            if (position.Y < BOUND)
            {
                position.Y = BOUND;
                velocity.Y *= -1;
            }
        }

        public void Move(Vector2 amount, float BOUND)
        {
            base.Move(amount);
            CheckWallCollision(BOUND);
        }
    }
}
