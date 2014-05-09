using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public enum Hands{ One, Two }
    public enum ArmorLocation { Hands, Feet, Head, Body }

    public abstract class BaseItem
    {
        public List<string> allowableClasses = new List<string>();

        private string name, type;
        private int price;
        private float weight;
        private bool equipped;

        public List<string> AllowableClasses
        {
            get { return allowableClasses; }
            protected set { allowableClasses = value; }
        }

        public string Type
        {
            get { return type; }
            protected  set { type = value; }
        }

        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }
        public float Weight
        {
            get { return weight; }
            protected set { weight = value; }
        }
        public int Price
        {
            get { return price; }
            protected set { price = value; }
        }
        public bool IsEquipped
        {
            get { return equipped; }
            protected set { equipped = value; }
        }

        public BaseItem(string name, string type, int price, float weight, params string[] allowableClasses  )
        {
            Name = name;
            Price = price;
            Type = type;
            Weight = weight;
            IsEquipped = false;

            foreach (string t in allowableClasses)
            {
                AllowableClasses.Add(t);
            }
        }

        public abstract object Clone();

        public virtual bool CanEquip(string characterType)
        {
            return allowableClasses.Contains(characterType);
        }

        public override string ToString()
        {
            string itemString = "";

            itemString += Name + ", ";
            itemString += Type + ", ";
            itemString += Price + ", ";
            itemString += Weight + "";

            return itemString;
        }
    }
}
