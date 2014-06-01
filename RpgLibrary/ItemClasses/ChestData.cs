using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ChestData
    {
        public string Name, TextureName, TrapName, KeyName;
        public bool IsTrapped, IsLocked;
        public int MaxGold, MinGold;
        public Dictionary<string, string> ItemCollection;

        public ChestData()
        {
            ItemCollection = new Dictionary<string, string>();
        }

        public override string ToString()
        {
            string toString = Name + ", " + TextureName + ", " + IsTrapped + ", " + IsLocked + ", " +
                              TrapName + ", " + MaxGold + ", " + MinGold;

            foreach (KeyValuePair<string, string> pair in ItemCollection)
            {
                toString += ", " + pair.Key + "+" + pair.Value;
            }
            return toString;
        }
    }
}
