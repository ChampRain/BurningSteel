using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BurningSteel.Components
{
    class Animation
    {
        public enum AnimationKey {down, left, right, up}

        private Rectangle[] frames;
        private int framesPerSecond;
        private TimeSpan frameLength, frameTimer;
        private int currentFrame, frameWidth, frameHeight;

        public int FramesPerSecond
        {
            get { return framesPerSecond; }
            set
            {
                if (value < 1)
                    framesPerSecond = 1;
                else if (value > 60)
                    framesPerSecond = 60;
                else
                    framesPerSecond = value;

                frameLength = TimeSpan.FromSeconds(1/(double) framesPerSecond);
            }
        }

        public Rectangle currentFrameRect
        {
            get { return frames[currentFrame]; }
        }

        public int CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = (int) MathHelper.Clamp(value, 0, frames.Length - 1); }
        }
    }
}
