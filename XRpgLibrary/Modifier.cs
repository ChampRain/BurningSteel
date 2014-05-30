using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary
{
    public struct Modifier
    {
        public int Amount, Duration;
        public TimeSpan timeLeft;

        public Modifier(int amount)
        {
            Amount = amount;
            Duration = -1;
            timeLeft = TimeSpan.Zero;
        }

        public Modifier(int amount, int duration)
        {
            Amount = amount;
            Duration = duration;
            timeLeft = TimeSpan.FromSeconds(duration);
        }

        public void Update(TimeSpan elapsedTime)
        {
            if (Duration == -1)
            {
                return;
            }

            timeLeft -= elapsedTime;

            if (timeLeft.TotalMilliseconds < 0)
            {
                timeLeft = TimeSpan.Zero;
                Amount = 0;
            }
        }
    }
}
