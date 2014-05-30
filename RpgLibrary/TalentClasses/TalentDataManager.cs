using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.TalentClasses
{
    public class TalentDataManager
    {
        public readonly Dictionary<string, TalentData> talentData;

        public Dictionary<string, TalentData> TalentData
        {
            get { return talentData; }
        }

        public TalentDataManager()
        {
            talentData = new Dictionary<string, TalentData>();
        }
    }
}
