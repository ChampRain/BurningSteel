using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class Key : BaseItem
    {
        public Key(string name, string type) : base(name, type, 0, 0, null)
        {
        }

        public override object Clone()
        {
            Key key = new Key(this.Name, this.Type);
            return key;
        }
    }
}
