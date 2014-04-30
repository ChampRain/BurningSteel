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

            stateManager.PopState();
            stateManager.PushState(gameRef.gamePlayScreen);
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
    }
}
