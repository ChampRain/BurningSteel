using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using BurningSteel.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary;
using XRpgLibrary.TileEngine;

namespace BurningSteel.GameScreens
{
    public class GamePlayScreen : BaseGameState
    {
        private Engine engine = new Engine(32,32);
        private TileMap map;
        private Player player;
        
        public GamePlayScreen(Game game, GameStateManager manager) : base(game, manager)
        {
            player = new Player(game);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            Texture2D tileSetTextureGrass = Game.Content.Load<Texture2D>(@"TileSets/grassTileSet");
            Tileset tileSetGrass = new Tileset(tileSetTextureGrass, 8, 8, 32, 32);

            Texture2D tileSetTextureTown = Game.Content.Load<Texture2D>(@"TileSets/townTileSet");
            Tileset tileSetTown = new Tileset(tileSetTextureTown, 8, 8, 32, 32);

            List<Tileset> tileSets = new List<Tileset>();
            tileSets.Add(tileSetGrass);
            tileSets.Add(tileSetTown);

            MapLayer layer = new MapLayer(40,40);

            for (int y = 0; y < layer.Height; y++)
            {
                for (int x = 0; x < layer.Width; x++)
                {
                    Tile tile = new Tile(0,0);
                    layer.SetTile(x,y,tile);
                }
            }

            MapLayer splatter = new MapLayer(40, 40);

            Random random = new Random();

            for (int i = 0; i < 80; i++)
            {
                int x = random.Next(0,40);
                int y = random.Next(0, 40);
                int index = random.Next(2, 14);

                Tile tile = new Tile(index, 0);
                splatter.SetTile(x,y,tile);
            }

            splatter.SetTile(1,0,new Tile(0,1));
            splatter.SetTile(2,0,new Tile(2,1));
            splatter.SetTile(3,0,new Tile(0,1));

            List<MapLayer> mapLayers = new List<MapLayer>();
            mapLayers.Add(layer);
            mapLayers.Add(splatter);

            map = new TileMap(tileSets, mapLayers);
        }

        public override void Draw(GameTime gameTime)
        {
            gameRef.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,
                                      SamplerState.PointClamp, null, null, null, Matrix.Identity);

            map.Draw(gameRef.spriteBatch, player.Camera);

            base.Draw(gameTime);
            gameRef.spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            base.Update(gameTime);
        }
    }
}
