using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgLibrary.SkillClasses;

namespace RpgLibrary.ItemClasses
{
    public class ChestData
    {
        public string Name, TrapName, KeyName, KeyType;
        public DifficultyLevel DifficultyLevel;
        public bool IsTrapped, IsLocked;
        public int MaxGold, MinGold, KeysRequired;
        public Dictionary<string, string> ItemCollection;

        public ChestData()
        {
            ItemCollection = new Dictionary<string, string>();
        }

        public override string ToString()
        {
            string toString = Name + ", " + DifficultyLevel + ", " + KeyName + ", " + KeyType + ", " + KeysRequired + ", " + 
                              IsTrapped + ", " + IsLocked + ", " + TrapName + ", " + MaxGold + ", " + MinGold;

            foreach (KeyValuePair<string, string> pair in ItemCollection)
            {
                toString += ", " + pair.Key + "+" + pair.Value;
            }
            return toString;
        }
    }
}
