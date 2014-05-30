using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.SkillClasses
{
    public struct Reagants
    {
        public string ReagantName;
        public ushort AmountRequired;

        public Reagants(string reagant, ushort number)
        {
            ReagantName = reagant;
            AmountRequired = number;
        }
    }

    public class Recipe
    {
        public string Name;
        public Reagants[] Reagants;

        private Recipe()
        {
        }

        public Recipe(string name, params Reagants[] reagants)
        {
            Name = name;
            Reagants = new Reagants[reagants.Length];

            for (int i = 0; i < reagants.Length; i++)
            {
                Reagants[i] = reagants[i];
            }
        }
    }
}
