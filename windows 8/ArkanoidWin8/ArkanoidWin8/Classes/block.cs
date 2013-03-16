using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidWin8.Classes
{
    class block : GameObject
    {
        public Vector2 velocity;
        public Random random;

            public void CheckWallCollision(float posX, float posY, Vector2 vektor)
            {
               
            if (posX =< posi)
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
