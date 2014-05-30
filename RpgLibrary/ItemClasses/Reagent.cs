using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Reagent : BaseItem
    {
        public Reagent(string name, string type, int price, float weight, params string[] allowableClasses) : 
            base(name, type, price, weight, allowableClasses)
        {

        }

        public override object Clone()
        {
            Reagent reagent = new Reagent(Name, Type, Price, Weight);

            return reagent;
        }
    }
}
