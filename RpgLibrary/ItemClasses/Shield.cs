using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Shield : BaseItem
    {
        private int defenseValue, defenseModifier;

        public int DefenseValue
        {
            get { return defenseValue; }
            protected set { defenseValue = value; }
        }
        public int DefenseModifier
        {
            get { return defenseModifier; }
            protected set { defenseModifier = value; }
        }

        public Shield(string shieldName, string shieldType, int price, float weight,
                        int defenseValue, int defenseModifier, params Type[] allowableClasses) : 
                        base(shieldName, shieldType, price, weight, allowableClasses)
        {
            DefenseValue = defenseValue;
            DefenseModifier = defenseModifier;
        }

        public override object Clone()
        {
            Type[] allowedClasses = new Type[allowableClasses.Count];

            for(int i = 0; i < allowableClasses.Count; i++)
            {
                allowedClasses[i] = allowableClasses[i];
            }

            Shield shield = new Shield(Name, Type, Price, Weight, DefenseValue, DefenseModifier, allowedClasses);

            return shield;
        }

        public override string ToString()
        {
            string shield = base.ToString();
            shield += DefenseValue + ", ";
            shield += DefenseModifier + "";

            foreach (Type t in allowableClasses)
            {
                shield += ", " + t.Name;
            }

            return shield;
        }
    }
}
