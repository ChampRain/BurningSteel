using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary
{
    public class RolePlayingGame
    {
        private string name, description;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public RolePlayingGame(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
