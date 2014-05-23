using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.CharacterClasses
{
    public class EntityData
    {
        public string EntityName;
        public int Strength, Dexterity, Cunning, Willpower, Constitution, Magic;
        public string HealthFormula, StaminaFormula, MagicFormula;

        private EntityData()
        {
        }

        public EntityData(string entityName, int strength, int dexterity, int cunning,
            int willpower, int constitution, int magic, string healthFormula, string staminaFormula, string magicFormula)
        {
            EntityName = entityName;
            Strength = strength;
            Dexterity = dexterity;
            Cunning = cunning;
            Willpower = willpower;
            Constitution = constitution;
            Magic = magic;

            HealthFormula = healthFormula;
            StaminaFormula = staminaFormula;
            MagicFormula = magicFormula;
        }

        public override string ToString()
        {
            string toString = EntityName + ", ";
            toString += Strength + ", ";
            toString += Dexterity + ", ";
            toString += Cunning + ", ";
            toString += Willpower + ", ";
            toString += Magic + ", ";
            toString += Constitution + ", ";
            toString += HealthFormula + ", ";
            toString += StaminaFormula + ", ";
            toString += MagicFormula;

            return toString;
        }

        public object Clone()
        {
            EntityData entityData = new EntityData();

            entityData.EntityName = EntityName;
            entityData.Strength = Strength;
            entityData.Dexterity = Dexterity;
            entityData.Cunning = Cunning;
            entityData.Willpower = Willpower;
            entityData.Magic = Magic;
            entityData.Constitution = Constitution;

            entityData.HealthFormula = HealthFormula;
            entityData.StaminaFormula = StaminaFormula;
            entityData.MagicFormula = MagicFormula;

            return entityData;
        }
    }
}
