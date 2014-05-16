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
        private static int mapHeight;
        private static int mapWidth;


        public static int WidthInPixels
        {
            get { return mapWidth * Engine.TileWidth; ; }
        }

        public static int HeightInPixels
        {
            get { return mapHeight * Engine.TileHeight; }
        }

        public TileMap(List<Tileset> tilesets, List<MapLayer> mapLayers)
        {
            this.tilesets = tilesets;
            this.mapLayers = mapLayers;

            mapHeight = mapLayers[0].Height;
            mapWidth = mapLayers[0].Width;
        }

        public TileMap(Tileset tileset, MapLayer mapLayer)
        {
            tilesets = new List<Tileset>();
            tilesets.Add(tileset);

            mapLayers = new List<MapLayer>();
            mapLayers.Add(mapLayer);

            mapHeight = mapLayers[0].Height;
            mapWidth = mapLayers[0].Width;
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Point cameraPoint = Engine.VectorToCell(camera.Position*(1/camera.Zoom));
            Point viewPoint = Engine.VectorToCell(new Vector2(
                                    (camera.Position.X + camera.ViewPortRectangle.Width)*(1/camera.Zoom),
                                     camera.Position.Y + camera.ViewPortRectangle.Height)*(1/camera.Zoom));
            Point min = new Point();
            Point max = new Point();

            min.X = Math.Max(0, cameraPoint.X - 1);
            min.Y = Math.Max(0, cameraPoint.Y - 1);
            max.X = Math.Max(viewPoint.X + 1, mapWidth);
            max.Y = Math.Max(viewPoint.Y + 1, mapHeight);

            Rectangle destination = new Rectangle(0,0,Engine.TileWidth, Engine.TileHeight);
            Tile tile;

            foreach (MapLayer mapLayer in mapLayers)
            {
                for (int y = min.Y; y < max.Y; y++)
                {
                    destination.Y = y * Engine.TileHeight;

                    for (int x = min.X; x < max.X; x++)
                    {
                        tile = mapLayer.GetTile(x, y);

                        if (tile.TileIndex == -1 || tile.TileSet == -1)
                        {
                            continue;
                        }

                        destination.X = x * Engine.TileWidth;

                        spriteBatch.Draw(tilesets[tile.TileSet].Texture, destination, 
                                         tilesets[tile.TileSet].SourceRectangles[tile.TileIndex], Color.White);
                    }
                }
            }
        }

        public void AddLayer(MapLayer layer)
        {
            if (layer.Width != mapWidth && layer.Height != mapHeight)
            {
                throw new Exception("Map Layer Size Exception");
            }

            mapLayers.Add(layer);
        }
    }
}
