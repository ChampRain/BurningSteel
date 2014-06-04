using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class KeyData
    {
        public string Name, Type;

        public KeyData()
        {
        }

        public override string ToString()
        {
            string keydata = Name + ", " + Type;
            return keydata;
        }
    }
}
