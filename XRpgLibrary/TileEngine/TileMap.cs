using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XRpgLibrary.TileEngine
{
    public class TileMap
    {
        private List<Tileset> tilesets;
        private List<MapLayer> mapLayers;

        public TileMap(List<Tileset> tilesets, List<MapLayer> mapLayers)
        {
            this.tilesets = tilesets;
            this.mapLayers = mapLayers;
        }

        public TileMap(Tileset tileset, MapLayer mapLayer)
        {
            tilesets = new List<Tileset>();
            tilesets.Add(tileset);

            mapLayers = new List<MapLayer>();
            mapLayers.Add(mapLayer);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destination = new Rectangle(0,0,Engine.TileWidth, Engine.TileHeight);
            Tile tile;

            foreach (MapLayer mapLayer in mapLayers)
            {
                for (int y = 0; y < mapLayer.Height; y++)
                {
                    destination.Y = Engine.TileHeight;

                    for (int x = 0; x < mapLayer.Width; x++)
                    {
                        tile = mapLayer.GetTile(x, y);

                        destination.X = Engine.TileWidth;

                        spriteBatch.Draw(tilesets[tile.TileSet].Texture, destination, 
                                         tilesets[tile.TileSet].SourceRectangles[tile.TileIndex], Color.White);
                    }
                }
            }
        }
    }
}
