using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using BurningSteel.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary;
using XRpgLibrary.Controls;
using XRpgLibrary.SpriteClass;
using XRpgLibrary.TileEngine;
using XRpgLibrary.WorldClasses;

namespace BurningSteel.GameScreens
{
    public class CharacterGeneratorScreen : BaseGameState
    {
        private LeftRightSelector classSelector;
        private LeftRightSelector genderSelector;
        private PictureBox backgroundImage, characterBox;

        private Texture2D[,] characterImages;

        private string[] genderItems = {"Male", "Female"};
        private string[] classItems = {"Fighter", "Wizard", "Rogue", "Priest"};

        public string SelectedClass
        {
            get { return classSelector.SelectedItem; }
        }

        public string SelectedGender
        {
            get { return genderSelector.SelectedItem; }
        }

        public CharacterGeneratorScreen(Game game, GameStateManager manager) : base(game,manager)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            LoadImages();
            CreateControls();    
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            gameRef.spriteBatch.Begin();

            base.Draw(gameTime);

            ControlManager.Draw(gameRef.spriteBatch);

            gameRef.spriteBatch.End();
        }

        private void CreateControls()
        {
            Texture2D leftTexture = Game.Content.Load<Texture2D>(@"GUI/leftarrow");
            Texture2D righTexture = Game.Content.Load<Texture2D>(@"GUI/rightarrow");
            Texture2D stopTexture = Game.Content.Load<Texture2D>(@"GUI/stopshield");

            backgroundImage = new PictureBox(Game.Content.Load<Texture2D>(@"Backgrounds/title"),
                                             gameRef.ScreenRectangle);
            ControlManager.Add(backgroundImage);

            Label label = new Label();

            label.Text = "Predict The Chosen One";
            label.Size = label.SpriteFont.MeasureString(@"Fonts/ControlFont");
            label.Position = new Vector2((gameRef.Window.ClientBounds.Width - label.Size.X) / 2 - 25, 400);

            ControlManager.Add(label);

            genderSelector = new LeftRightSelector(leftTexture, righTexture, stopTexture);
            genderSelector.SetItems(genderItems, 40);
            genderSelector.Position = new Vector2(395, 475);
            genderSelector.Selected += new EventHandler(SelectionChanged);

            ControlManager.Add(genderSelector);

            classSelector = new LeftRightSelector(leftTexture, righTexture, stopTexture);
            classSelector.SetItems(classItems, 40);
            classSelector.Position = new Vector2(395, 550);
            classSelector.Selected += SelectionChanged;

            ControlManager.Add(classSelector);

            LinkLabel link = new LinkLabel();
            link.Text = "Accept His Fate";
            link.Position = new Vector2(label.Position.X + 45, 625);
            link.Selected = new EventHandler(LinkLabel_Selected);

            ControlManager.Add(link);

            characterBox = new PictureBox(characterImages[0,0], 
                                          new Rectangle(470,260,96,96),
                                          new Rectangle(0,0,32,32));

            ControlManager.Add(characterBox);
            
            ControlManager.NextControl();
        }

        void LinkLabel_Selected(object sender, EventArgs e)
        {
            InputHandler.Flush();

            stateManager.ChangeState(gameRef.gamePlayScreen);

            CreatePlayer();
            CreateWorld();
        }

        public void LoadImages()
        {
            characterImages = new Texture2D[genderItems.Length,classItems.Length];

            for (int i = 0; i < genderItems.Length; i++)
            {
                for (int j = 0; j < classItems.Length; j++)
                {
                    characterImages[i, j] =
                        Game.Content.Load<Texture2D>(@"PlayerSprites\" + genderItems[i] + classItems[j]);
                }
            }
        }

        public void SelectionChanged(object sender, EventArgs e)
        {
            characterBox.Image = characterImages[genderSelector.SelectedIndex, classSelector.SelectedIndex];
        }

        public void CreatePlayer()
        {
            Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();

            Animation animation = new Animation(3,32,32,0,0);
            animations.Add(AnimationKey.Down, animation);

            animation = new Animation(3, 32, 32, 0, 96);
            animations.Add(AnimationKey.Up, animation);

            animation = new Animation(3, 32, 32, 0, 32);
            animations.Add(AnimationKey.Left, animation);

            animation = new Animation(3, 32, 32, 0, 64);
            animations.Add(AnimationKey.Right, animation);

            AnimatedSprite sprite = new AnimatedSprite(characterImages[genderSelector.SelectedIndex, classSelector.SelectedIndex],
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

            World world = new World(gameRef, gameRef.ScreenRectangle);
            world.Levels.Add(level);
            world.CurrentLevel = 0;

            GamePlayScreen.World = world;
        }
    }
}
