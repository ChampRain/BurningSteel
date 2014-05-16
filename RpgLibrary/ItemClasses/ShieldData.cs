using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ShieldData
    {
        public string name, type;
        public int price, defenseValue, defenseModifier;
        public float weight;
        public bool equipped;
        public string[] allowableClasses;
    }
}
