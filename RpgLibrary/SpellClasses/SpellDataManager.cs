using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.SpellClasses
{
    public class SpellDataManager
    {
        private readonly Dictionary<string, SpellData> spellData;

        public Dictionary<string, SpellData> SpellData
        {
            get { return spellData; }
        }

        public SpellDataManager()
        {
            spellData = new Dictionary<string, SpellData>();
        }
    }
}
