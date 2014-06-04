using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Chest : BaseItem
    {
        static Random random = new Random();
        private ChestData chestData;

        public bool IsLocked
        {
            get { return chestData.IsLocked; }
        }

        public bool IsTrapped
        {
            get { return chestData.IsTrapped; }
        }

        public int Gold
        {
            get {
                if (chestData.MinGold == 0 && chestData.MaxGold == 0)
                {
                    return 0;
                }

                int gold = random.Next(chestData.MinGold, chestData.MaxGold);
                chestData.MaxGold = 0;
                chestData.MinGold = 0;

                return gold;
            }
        }

        public Chest(ChestData data) : base(data.Name, "", 0, 0)
        {
            this.chestData = data;
        }

        public override object Clone()
        {
            ChestData data = new ChestData();
            data.Name = chestData.Name;
            data.DifficultyLevel = chestData.DifficultyLevel;
            data.IsLocked = chestData.IsLocked;
            data.IsTrapped = chestData.IsTrapped;
            data.KeyName = chestData.KeyName;
            data.KeyType = chestData.KeyType;
            data.KeysRequired = chestData.KeysRequired;
            data.TrapName = chestData.TrapName;
            data.KeyName = chestData.KeyName;
            data.MinGold = chestData.MinGold;
            data.MaxGold = chestData.MaxGold;

            foreach (KeyValuePair<string, string> pair in chestData.ItemCollection)
            {
                chestData.ItemCollection.Add(pair.Key, pair.Value);
            }

            Chest chest = new Chest(chestData);

            return chest;
        }
    }
}
