using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;

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
        private Tileset tileSet;
        private TileMap map;
        
        public GamePlayScreen(Game game, GameStateManager manager) : base(game, manager)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Texture2D tileSetTexture = Game.Content.Load<Texture2D>(@"TileSets/grassTileSet"); 
            tileSet = new Tileset(tileSetTexture, 8,8,32,32);

            MapLayer layer = new MapLayer(40,40);

            for (int y = 0; y < layer.Height; y++)
            {
                for (int x = 0; x < layer.Width; x++)
                {
                    Tile tile = new Tile(0,0);
                    layer.SetTile(x,y,tile);
                }
            }

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            gameRef.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,
                                      SamplerState.PointClamp, null, null, null, Matrix.Identity);

            map.Draw(gameRef.spriteBatch);

            base.Draw(gameTime);
            gameRef.spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
