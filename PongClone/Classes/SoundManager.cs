using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace PongClone
{
    public static class SoundManager
    {
        public static SoundEffect BallWallCollisionSoundEffect;
        public static SoundEffect PaddleBallCollisionSoundEffect;

        public static void LoadSounds(ContentManager Content)
        {
            BallWallCollisionSoundEffect = Content.Load<SoundEffect>("BallWallCollision");
            PaddleBallCollisionSoundEffect = Content.Load<SoundEffect>("PaddleBallCollision");
        }
    }
}
