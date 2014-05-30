using System.Collections.Generic;
using RpgLibrary.SkillClasses;

namespace RpgLibrary.ItemClasses
{
    public class RecipeManager
    {
        public readonly Dictionary<string, Recipe> recipes;

        public Dictionary<string, Recipe> Recipes
        {
            get { return recipes; }
        }

        public RecipeManager()
        {
            recipes = new Dictionary<string, Recipe>();
        }
    }
}
