using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.SkillClasses
{
    public class SkillDataManager
    {
        private readonly Dictionary<string, SkillData> skillData;

        public Dictionary<string, SkillData> SkillData
        {
            get { return skillData; }
        }

        public SkillDataManager()
        {
            skillData = new Dictionary<string, SkillData>();
        }
    }
}
