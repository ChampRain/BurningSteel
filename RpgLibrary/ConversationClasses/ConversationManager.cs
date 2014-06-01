using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ConversationClasses
{
    public class ConversationManager
    {
        public readonly Dictionary<string, Conversation> conversations;

        public Dictionary<string, Conversation> Conversations
        {
            get { return conversations; }
        }

        public ConversationManager()
        {
            conversations = new Dictionary<string, Conversation>();
        }
    }
}
