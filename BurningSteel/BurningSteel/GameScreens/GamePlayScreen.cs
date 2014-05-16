using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using BurningSteel.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XRpgLibrary;
using XRpgLibrary.SpriteClass;
using XRpgLibrary.TileEngine;
using XRpgLibrary.WorldClasses;

namespace BurningSteel.GameScreens
{
    public class GamePlayScreen : BaseGameState
    {
        private Engine engine = new Engine(32,32);
        private Player player;
        private World world;

        public World World
        {
            get { return world; }
            set { world = value; }
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public GamePlayScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {

            base.LoadContent();

            /*Texture2D spriteSheet = Game.Content.Load<Texture2D>(@"PlayerSprites/" + 
                                                gameRef.characterScreen.SelectedGender + 
                                                gameRef.characterScreen.SelectedClass);

            Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();

            Animation animation = new Animation(3,32,32,0,0);
            animations.Add(AnimationKey.Down, animation);

            animation = new Animation(3,32,32,0,32);
            animations.Add(AnimationKey.Left, animation);

            animation = new Animation(3,32,32,0,64);
            animations.Add(AnimationKey.Right, animation);

            animation = new Animation(3, 32, 32, 0, 96);
            animations.Add(AnimationKey.Up, animation);

            AnimatedSprite sprite = new AnimatedSprite(spriteSheet, animations);
            player = new Player(gameRef, sprite);
           
            

            Texture2D tileSetTextureGrass = Game.Content.Load<Texture2D>(@"TileSets/grassTileSet");
            Tileset tileSetGrass = new Tileset(tileSetTextureGrass, 8, 8, 32, 32);

            Texture2D tileSetTextureTown = Game.Content.Load<Texture2D>(@"TileSets/townTileSet");
            Tileset tileSetTown = new Tileset(tileSetTextureTown, 8, 8, 32, 32);

            List<Tileset> tileSets = new List<Tileset>();
            tileSets.Add(tileSetGrass);
            tileSets.Add(tileSetTown);

            MapLayer layer = new MapLayer(100,100);

            for (int y = 0; y < layer.Height; y++)
            {
                for (int x = 0; x < layer.Width; x++)
                {
                    Tile tile = new Tile(0,0);
                    layer.SetTile(x,y,tile);
                }
            }

            MapLayer splatter = new MapLayer(100, 100);

            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(0,100);
                int y = random.Next(0, 100);
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

            TileMap map = new TileMap(tileSets, mapLayers);
            Level level = new Level(map);
            world.Levels.Add(level);
            world.CurrentLevel = 0;*/
        }

        public override void Draw(GameTime gameTime)
        {
            gameRef.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,
                                      SamplerState.PointClamp, null, null, null, player.Camera.Transformation);

            world.DrawLevel(gameRef.spriteBatch, player.Camera);

            player.Draw(gameTime, gameRef.spriteBatch);

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
