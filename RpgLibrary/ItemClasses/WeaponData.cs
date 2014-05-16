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
    }
}
