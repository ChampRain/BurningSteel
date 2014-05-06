using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.CharacterClasses
{
    public enum EntityGender {Male, Female, Unknown}
    public enum EntityType {Character, Monster, NPC, Creature}

    public abstract class Entity
    {
        private EntityGender gender;
        private EntityType type;

        private AttributePair health, stamina, mana;

        private int strength, cunning, willpower, constitution, magic, dexterity;
        private int strengthModifier, cunningModifier, willpowerModifier;
        private int constitutionModifier, magicModifier, dexterityModifier;
        private int attack, defense, damage;
        private int level;

        private long experience;
        private string entityType;

        public string EntityType
        {
            get { return entityType; }
        }

        public EntityGender Gender
        {
            get { return gender; }
            protected set { gender = value; }
        }

        public int Strength
        {
            get { return strength + strengthModifier; }
            protected set { strength = value; }
        }
        public int Dexterity
        {
            get { return dexterity + dexterityModifier; }
            protected set { dexterity = value; }
        }
        public int Cunning
        {
            get { return cunning + cunningModifier; }
            protected set { cunning = value; }
        }
        public int Willpower
        {
            get { return willpower + willpowerModifier; }
            protected set { willpower = value; }
        }
        public int Magic
        {
            get { return magic + magicModifier; }
            protected set { magic = value; }
        }
        public int Constitution
        {
            get { return constitution + constitutionModifier; }
            protected set { constitution = value; }
        }

        public AttributePair Health
        {
            get { return health; }
        }

        public AttributePair Mana
        {
            get { return mana; }
        }

        public AttributePair Stamina
        {
            get { return stamina; }
        }

        public int Level
        {
            get { return level; }
            protected set { level = value; }
        }

        public long Experience
        {
            get { return experience; }
            protected set { experience = value; }
        }

        private Entity()
        {
            Strength = 0;
            Cunning = 0;
            Dexterity = 0;
            Willpower = 0;
            Magic = 0;
            Constitution = 0;

            health = new AttributePair(0);
            mana = new AttributePair(0);
            stamina = new AttributePair(0);
        }

        public Entity(EntityData entityData)
        {
            entityType = entityData.EntityName;
            Strength = entityData.Strength;
            Cunning = entityData.Cunning;
            Constitution = entityData.Constitution;
            Willpower = entityData.Willpower;
            Magic = entityData.Magic;
            Dexterity = entityData.Dexterity;

            health = new AttributePair(0);
            mana = new AttributePair(0);
            stamina = new AttributePair(0);
        }
    }
}
