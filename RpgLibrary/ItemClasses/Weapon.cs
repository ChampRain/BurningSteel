using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Weapon : BaseItem
    {
        private Hands hands;
        private int attackValue, attackModifier, damageValue, damageModifier;

        public Hands NumberHands
        {
            get { return hands; }
            protected set { hands = value; }
        }
        public int AttackValue
        {
            get { return attackValue; }
            protected set { attackValue = value; }
        }
        public int AttackModifier
        {
            get { return attackModifier; }
            protected set { attackModifier = value; }
        }
        public int DamageValue
        {
            get { return damageValue; }
            protected set { damageValue = value; }
        }
        public int DamageModifier
        {
            get { return damageModifier; }
            protected set { damageModifier = value; }
        }

        public Weapon(string weaponName, string weaponType, int price, float weight, 
                      Hands hands, int attackValue, int attackModifier, int damageValue, 
                      int damageModifier, params Type[] allowableClasses) : 
                            base(weaponName, weaponType, price, weight, allowableClasses)
        {
            NumberHands = hands;
            AttackValue = attackValue;
            AttackModifier = attackModifier;
            DamageModifier = damageModifier;
            DamageValue = damageValue;
        }

        public override object Clone()
        {
            Type[] allowedClasses = new Type[allowableClasses.Count];

            for (int i = 0; i < allowableClasses.Count; i++)
            {
                allowedClasses[i] = allowableClasses[i];
            }

            Weapon weapon = new Weapon(Name, Type, Price, Weight, NumberHands, 
                AttackValue, AttackModifier, DamageValue, damageModifier, allowedClasses);

            return weapon;
        }

        public override string ToString()
        {
            string weapon = base.ToString() + ", ";

            weapon += NumberHands + ", ";
            weapon += AttackValue + ", ";
            weapon += AttackModifier + ", ";
            weapon += DamageValue + ", ";
            weapon += DamageModifier + "";

            foreach (Type t in allowableClasses)
            {
                weapon += ", ";
            }

            return weapon;
        }
    }
}
