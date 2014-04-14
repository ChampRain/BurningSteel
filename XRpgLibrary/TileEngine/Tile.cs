using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.TileEngine
{
    public class Tile
    {
        int tileIndex;
        int tileSet;

        public int TileIndex
        {
            get { return tileIndex; }
            private set { tileIndex = value; }
        }

        public int TileSet
        {
            get { return tileSet; }
            private set { tileSet = value; }
        }

        public Tile(int tileIndex, int tileSet)
        {
            this.TileIndex = tileIndex;
            this.TileSet = tileSet;
        }
    }
}
