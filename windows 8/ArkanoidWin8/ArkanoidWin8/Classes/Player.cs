using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ArkanoidWin8.Classes
{
    class Player : GameObject
    {
        public override void Move(Vector2 amount)
        {
            base.Move(amount);
            if (position.X <= 0)
                position.X = 0;
            if (position.X + texture.Width >= Arkanoid.screenWidth)
                position.X = Arkanoid.screenWidth - texture.Width;
        }
    }
}
