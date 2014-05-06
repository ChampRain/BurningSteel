using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.CharacterClasses
{
    public class AttributePair
    {
        private int currentValue, maximumValue;

        public int CurrentValue
        {
            get { return currentValue; }
        }

        public int MaximumValue
        {
            get { return maximumValue; }
        }

        public static AttributePair Zero
        {
            get {return new AttributePair();}
        }

        private AttributePair()
        {
            currentValue = 0;
            maximumValue = 0;
        }

        public AttributePair(int maxValue)
        {
            maximumValue = maxValue;
            currentValue = maxValue;
        }

        public void Heal(ushort value)
        {
            currentValue += value;
            if (currentValue < maximumValue)
            {
                currentValue = maximumValue;
            }
        }

        public void Damage(ushort value)
        {
            currentValue -= value;
            if (currentValue < 0)
            {
                currentValue = 0;
            }
        }

        public void SetCurrent(int value)
        {
            currentValue = value;
            if (currentValue > maximumValue)
            {
                currentValue = maximumValue;
            }
        }

        public void SetMaximumValue(int value)
        {
            maximumValue = value;
            if (currentValue > maximumValue)
            {
                currentValue = maximumValue;
            }
        }
    }
}
