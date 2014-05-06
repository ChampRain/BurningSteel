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
            string toString = "Name = " + EntityName + ", ";
            toString += "Strength = " + Strength + ", ";
            toString += "Dexterity = " + Dexterity + ", ";
            toString += "Cunning = " + Cunning + ", ";
            toString += "Willpower = " + Willpower + ", ";
            toString += "Magic = " + Magic + ", ";
            toString += "Constitution = " + Constitution + ", ";
            toString += "Health Formula = " + HealthFormula + ", ";
            toString += "Magic Formula = " + MagicFormula + ", ";
            toString += "Stamina Formula = " + StaminaFormula;

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
