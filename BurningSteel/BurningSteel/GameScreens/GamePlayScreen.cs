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

namespace BurningSteel.GameScreens
{
    public class GamePlayScreen : BaseGameState
    {
        private Engine engine = new Engine(32,32);
        private TileMap map;
        private Player player;
        private AnimatedSprite sprite;

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
            Texture2D spriteSheet = Game.Content.Load<Texture2D>(@"PlayerSprites/malefighter");
            Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();

            Animation animation = new Animation(3,32,32,0,0);
            animations.Add(AnimationKey.Down, animation);

            animation = new Animation(3,32,32,0,32);
            animations.Add(AnimationKey.Left, animation);

            animation = new Animation(3,32,32,0,64);
            animations.Add(AnimationKey.Right, animation);

            animation = new Animation(3, 32, 32, 0, 96);
            animations.Add(AnimationKey.Up, animation);

            sprite = new AnimatedSprite(spriteSheet, animations);

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
            sprite.Draw(gameTime, gameRef.spriteBatch, player.Camera);
            base.Draw(gameTime);
            gameRef.spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            sprite.Update(gameTime);

            if (InputHandler.KeyReleased(Keys.PageUp) ||
                InputHandler.ButtonReleased(Buttons.LeftShoulder, PlayerIndex.One))
            {
                //player.Camera.Zoom();
            }


            Vector2 motion = new Vector2();

            if (InputHandler.KeyDown(Keys.W) || InputHandler.ButtonDown(Buttons.LeftThumbstickUp, PlayerIndex.One))
            {
                sprite.CurrentAnimation = AnimationKey.Up;
                motion.Y = -1;
            }
            if (InputHandler.KeyDown(Keys.S) || InputHandler.ButtonDown(Buttons.LeftThumbstickDown, PlayerIndex.One))
            {
                sprite.CurrentAnimation = AnimationKey.Down;
                motion.Y = 1;
            }
            if (InputHandler.KeyDown(Keys.A) || InputHandler.ButtonDown(Buttons.LeftThumbstickLeft, PlayerIndex.One))
            {
                sprite.CurrentAnimation = AnimationKey.Left;
                motion.X = -1;
            }
            if (InputHandler.KeyDown(Keys.D) || InputHandler.ButtonDown(Buttons.LeftThumbstickRight, PlayerIndex.One))
            {
                sprite.CurrentAnimation = AnimationKey.Right;
                motion.X = 1;
            }

            if (motion != Vector2.Zero)
            {
                sprite.IsAnimating = true;
                motion.Normalize();

                sprite.Position += motion*sprite.Speed;
                sprite.LockToMap();

                if (player.Camera.CameraMode == CameraMode.Follow)
                {
                    player.Camera.LockToSprite(sprite);
                }
            }
            else
            {
                sprite.IsAnimating = false;
            }

            if (InputHandler.KeyReleased(Keys.F) || InputHandler.ButtonReleased(Buttons.RightStick, PlayerIndex.One))
            {
                player.Camera.ToggleCameraMode();
                if (player.Camera.CameraMode == CameraMode.Follow)
                {
                    player.Camera.LockToSprite(sprite);
                }
            }

            if (player.Camera.CameraMode != CameraMode.Follow)
            {
                if (InputHandler.KeyReleased(Keys.C) || InputHandler.ButtonReleased(Buttons.LeftStick, PlayerIndex.One))
                {
                    player.Camera.LockToSprite(sprite);
                }
            }

            base.Update(gameTime);
        }
    }
}
