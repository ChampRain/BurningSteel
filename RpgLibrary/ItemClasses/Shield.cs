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

        public Shield(string name, string type, int price, float weight, params Type[] allowableClasses) : base(name, type, price, weight, allowableClasses)
        {
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
