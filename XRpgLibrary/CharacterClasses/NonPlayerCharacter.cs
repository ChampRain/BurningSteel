using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ConversationClasses;
using RpgLibrary.QuestClasses;
using XRpgLibrary.SpriteClass;

namespace XRpgLibrary.CharacterClasses
{
    class NonPlayerCharacter : Character
    {
        private readonly List<Conversation> conversations;
        private readonly List<Quest> quests;

        public List<Conversation> Conversations
        {
            get { return conversations; }
        }

        public List<Quest> Quests
        {
            get { return quests; }
        }

        public bool HasConverastions
        {
            get { return conversations.Count > 0; }
        }

        public bool HasQuest
        {
            get { return quests.Count > 0; }
        }

        public NonPlayerCharacter(Entity entity, AnimatedSprite sprite) : base(entity, sprite)
        {
            conversations = new List<Conversation>();
            quests = new List<Quest>();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
