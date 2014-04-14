using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace XRpgLibrary.TileEngine
{
    public class Engine
    {

        private static int tileWidth;
        private static int tileHeight;

        public static int TileWidth
        {
            get { return tileWidth; }
        }

        public static int TileHeight
        {
            get { return tileHeight; }
        }

        public Engine(int tileWidth, int tileHeight)
        {
            Engine.tileWidth = tileWidth;
            Engine.tileHeight = tileHeight;
        }

        public static Point VectorToCell(Vector2 position)
        {
            return new Point((int)position.X / TileWidth, (int)position.Y / TileHeight);
        }


    }
}
