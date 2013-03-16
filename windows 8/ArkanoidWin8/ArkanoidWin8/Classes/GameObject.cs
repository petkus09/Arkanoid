using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArkanoidWin8.Classes
{
    class GameObject
    {
        public Vector2 position;
        public Texture2D texture;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public virtual void Move(Vector2 amount)
        {
            position += amount;
        }

        public Rectangle Bounds
        {
            get { return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); }
        }

        public static bool CheckPaddleBallCollision(GameObject objektas, Ball ball)
        {
            if (objektas.Bounds.Intersects(ball.Bounds))
                return true;
            return false;
        }
    }
}
