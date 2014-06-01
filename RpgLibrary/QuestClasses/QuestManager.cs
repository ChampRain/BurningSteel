using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.QuestClasses
{
    public class QuestManager
    {
        public readonly Dictionary<string, Quest> quests;

        public Dictionary<string, Quest> Quests
        {
            get { return quests; }
        }

        public QuestManager()
        {
            quests = new Dictionary<string, Quest>();
        }
    }
}
