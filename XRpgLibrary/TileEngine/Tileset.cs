using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XRpgLibrary.TileEngine
{
    public class Tileset
    {
        private Texture2D image;
        private int tileWidthInPixels, tileHeightInPixels;
        private int tileWidth, tileHeight;
        private Rectangle[] sourceRectangles;

        public Texture2D Texture
        {
            get { return image; }
            private set { image = value; }
        }

        public int TileWidth
        {
            get { return tileWidthInPixels; }
            private set { tileWidthInPixels = value; }
        }

        public int TileHeight
        {
            get { return tileHeightInPixels; }
            private set { tileHeightInPixels = value; }
        }

        public int TilesWidth
        {
            get { return tileWidth; }
            private set { tileWidth = value; }
        }

        public int TilesHeight
        {
            get { return tileHeight; }
            private set { tileHeight = value; }
        }

        public Rectangle[] SourceRectangles
        {
            get { return (Rectangle[])sourceRectangles.Clone(); }
        }

        public Tileset(Texture2D image, int tilesWide, int tilesHigh, int tileWidth, int tileHeight)
        {
            int tile = 0, tiles;

            Texture = image;
            TilesHeight = tilesHigh;
            TilesWidth = tilesWide;
            TileHeight = tileHeight;
            TileWidth = tileWidth;

            tiles = tilesHigh * tilesWide;

            sourceRectangles = new Rectangle[tiles];

            for (int y = 0; y < tilesHigh; y++)
            {
                for (int x = 0; x < tilesWide; x++)
                {
                    sourceRectangles[tile] = new Rectangle(x * TileWidth, y * TileWidth, TileWidth, TileHeight);
                    tile ++;
                }
            }
        }
    }
}
