using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BurningSteel.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary;
using XRpgLibrary.Controls;
using XRpgLibrary.SpriteClass;
using XRpgLibrary.TileEngine;
using XRpgLibrary.WorldClasses;

namespace BurningSteel.GameScreens
{
    class LoadScreen : BaseGameState
    {
        PictureBox backgroundImage;
        ListBox loadListBox;
        LinkLabel loadLinkLabel;
        LinkLabel exitLinkLabel;

        public LoadScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            ContentManager content = Game.Content;

            backgroundImage = new PictureBox(content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                                            gameRef.ScreenRectangle);

            ControlManager.Add(backgroundImage);

            loadLinkLabel = new LinkLabel();
            loadLinkLabel.Text = "Select Game";
            loadLinkLabel.Position = new Vector2(50,100);
            loadLinkLabel.Selected += new EventHandler(loadLinkLabel_Selected);
            ControlManager.Add(loadLinkLabel);

            exitLinkLabel = new LinkLabel();
            exitLinkLabel.Text = "Back";
            exitLinkLabel.Position = new Vector2(50,100 + loadLinkLabel.SpriteFont.LineSpacing);
            exitLinkLabel.Selected += new EventHandler(exitLinkLabel_Selected);
            ControlManager.Add(exitLinkLabel);

            loadListBox = new ListBox(content.Load<Texture2D>(@"GUI\listBoxImage"),
                                      content.Load<Texture2D>(@"GUI\leftarrow"));

            loadListBox.Position = new Vector2(400,100);
            loadListBox.Selected += new EventHandler(loadListBox_Selected);
            loadListBox.Leave += new EventHandler(loadListBox_Leave);

            for (int i = 0; i < 20; i++)
            {
                loadListBox.Items.Add("Game Number: " + i);
            }

            ControlManager.Add(loadListBox);
            ControlManager.NextControl();
        }

        public override void Draw(GameTime gameTime)
        {
            gameRef.spriteBatch.Begin();

            base.Draw(gameTime);

            ControlManager.Draw(gameRef.spriteBatch);

            gameRef.spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);

            base.Update(gameTime);
        }

        private void loadListBox_Leave(object sender, EventArgs e)
        {
            ControlManager.AcceptInput = true;
        }

        private void loadLinkLabel_Selected(object sender, EventArgs e)
        {
            ControlManager.AcceptInput = false;
            loadLinkLabel.HasFocus = false;
            loadListBox.HasFocus = true;
        }

        private void loadListBox_Selected(object sender, EventArgs e)
        {
            loadLinkLabel.HasFocus = true;
            loadListBox.HasFocus = false;
            ControlManager.AcceptInput = true;

            stateManager.ChangeState(gameRef.gamePlayScreen);
            CreatePlayer();
            CreateWorld();
        }

        private void exitLinkLabel_Selected(object sender, EventArgs e)
        {
            stateManager.PopState();
        }

        public void CreatePlayer()
        {
            Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();

            Animation animation = new Animation(3, 32, 32, 0, 0);
            animations.Add(AnimationKey.Down, animation);

            animation = new Animation(3, 32, 32, 0, 96);
            animations.Add(AnimationKey.Up, animation);

            animation = new Animation(3, 32, 32, 0, 32);
            animations.Add(AnimationKey.Left, animation);

            animation = new Animation(3, 32, 32, 0, 64);
            animations.Add(AnimationKey.Right, animation);

            AnimatedSprite sprite = new AnimatedSprite(gameRef.Content.Load<Texture2D>(@"GUI\malefighter"),
                                                        animations);

            GamePlayScreen.Player = new Player(gameRef, sprite);
        }

        public void CreateWorld()
        {
            Texture2D tileSetTextureGrass = Game.Content.Load<Texture2D>(@"TileSets/grassTileSet");
            Tileset tileSetGrass = new Tileset(tileSetTextureGrass, 8, 8, 32, 32);

            Texture2D tileSetTextureTown = Game.Content.Load<Texture2D>(@"TileSets/townTileSet");
            Tileset tileSetTown = new Tileset(tileSetTextureTown, 8, 8, 32, 32);

            List<Tileset> tileSets = new List<Tileset>();
            tileSets.Add(tileSetGrass);
            tileSets.Add(tileSetTown);

            MapLayer layer = new MapLayer(100, 100);

            for (int y = 0; y < layer.Height; y++)
            {
                for (int x = 0; x < layer.Width; x++)
                {
                    Tile tile = new Tile(0, 0);
                    layer.SetTile(x, y, tile);
                }
            }

            MapLayer splatter = new MapLayer(100, 100);

            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(0, 100);
                int y = random.Next(0, 100);
                int index = random.Next(2, 14);

                Tile tile = new Tile(index, 0);
                splatter.SetTile(x, y, tile);
            }

            splatter.SetTile(1, 0, new Tile(0, 1));
            splatter.SetTile(2, 0, new Tile(2, 1));
            splatter.SetTile(3, 0, new Tile(0, 1));

            List<MapLayer> mapLayers = new List<MapLayer>();
            mapLayers.Add(layer);
            mapLayers.Add(splatter);

            TileMap map = new TileMap(tileSets, mapLayers);
            Level level = new Level(map);

            World world = new World(gameRef, gameRef.ScreenRectangle);
            world.Levels.Add(level);
            world.CurrentLevel = 0;

            GamePlayScreen.World = world;
        }
    }
}
