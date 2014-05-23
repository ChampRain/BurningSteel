using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class WeaponData
    {
        public string name, type;
        public int price, attackValue, attackModifier, damageValue, damageModifier;
        public float weight;
        public bool equipped;
        public string[] allowableClasses;
        public Hands hands;

        public override string ToString()
        {
            string weapon = name + ", " + type + ", " + price + ", " + weight + ", " + hands + ", " +
                           attackValue + ", " + attackModifier + ", " + damageValue + ", " + damageModifier;

            foreach (string s in allowableClasses)
            {
                weapon += ", " + s;
            }

            return weapon;
        }
    }
}
