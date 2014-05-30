namespace RpgLibrary.ItemClasses
{
    public class ReagentData
    {
        public string Name, Type;
        public int Price;
        public float Weight;

        public ReagentData()
        {

        }

        public override string ToString()
        {
            string recipe = Name + ", " + Type + ", " + Price + ", " + Weight;
            return recipe;
        }
    }
}
