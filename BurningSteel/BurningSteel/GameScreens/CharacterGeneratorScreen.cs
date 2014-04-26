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
        private LeftRightSelectorClass classSelector;
        private LeftRightSelectorGender genderSelector;
        private PictureBox backgroundImage;

        private string[] genderItems = {"Male", "Female"};
        private string[] classItems = {"Fighter", "Wizard", "Rogue", "Priest"};

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

            backgroundImage = new PictureBox(Game.Content.Load<Texture2D>(@"Backgrounds/titlescreen"),
                                             gameRef.ScreenRectangle);
            ControlManager.Add(backgroundImage);

            Label label = new Label();

            label.Text = "Predict The Chosen One";
            label.Size = label.SpriteFont.MeasureString(@"Fonts/ControlFont");
            label.Position = new Vector2((gameRef.Window.ClientBounds.Width - label.Size.X) / 2 - 25, 400);

            ControlManager.Add(label);

            genderSelector = new LeftRightSelectorGender(leftTexture, righTexture, stopTexture);
            genderSelector.SetItems(genderItems, 40);
            genderSelector.Position = new Vector2(400, 475);

            ControlManager.Add(genderSelector);

            classSelector = new LeftRightSelectorClass(leftTexture, righTexture, stopTexture);
            classSelector.SetItems(classItems, 40);
            classSelector.Position = new Vector2(400, 550);

            ControlManager.Add(classSelector);

            LinkLabel link = new LinkLabel();
            link.Text = "Accept His Fate";
            link.Position = new Vector2(label.Position.X + 45, 625);
            link.Selected = new EventHandler(LinkLabel_Selected);

            ControlManager.Add(link);
            ControlManager.NextControl();
        }

        void LinkLabel_Selected(object sender, EventArgs e)
        {
            InputHandler.Flush();

            stateManager.PopState();
            stateManager.PushState(gameRef.gamePlayScreen);
        }
    }
}
