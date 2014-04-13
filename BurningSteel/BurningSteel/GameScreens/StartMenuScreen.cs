using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XRpgLibrary;
using XRpgLibrary.Controls;

namespace BurningSteel.GameScreens
{
    public class StartMenuScreen : BaseGameState
    {
        private PictureBox backgroundImage;
        private PictureBox arrowImage;
        private LinkLabel startGame;
        private LinkLabel loadGame;
        private LinkLabel exitGame;
        private float maxItemWidth = 0f;

        public StartMenuScreen(Game game, GameStateManager gameStateManager) : base(game, gameStateManager)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            ContentManager Content = Game.Content;
            backgroundImage = new PictureBox(Content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                                             gameRef.ScreenRectangle);
            ControlManager.Add(backgroundImage);
            Texture2D arrowTexture = Content.Load<Texture2D>(@"GUI\cursor");

            arrowImage = new PictureBox(arrowTexture, new Rectangle(0,0,arrowTexture.Width,arrowTexture.Height));
            ControlManager.Add(arrowImage);

            startGame = new LinkLabel();
            startGame.Text = "The Story Begins";
            startGame.Size = startGame.SpriteFont.MeasureString(startGame.Text);
            startGame.Selected += new EventHandler(menu_ItemSelected);

            ControlManager.Add(startGame);

            loadGame = new LinkLabel();
            loadGame.Text = "The Story Continues";
            loadGame.Size = startGame.SpriteFont.MeasureString(loadGame.Text);
            loadGame.Selected += menu_ItemSelected;

            ControlManager.Add(loadGame);

            exitGame = new LinkLabel();
            exitGame.Text = "The Story Ends";
            exitGame.Size = startGame.SpriteFont.MeasureString(exitGame.Text);
            exitGame.Selected += menu_ItemSelected;

            ControlManager.Add(exitGame);

            ControlManager.NextControl();

            ControlManager.FocusChanged += new EventHandler(ControlManager_FocusChanged);
            Vector2 position = new Vector2(350, 500);

            foreach (Control c in ControlManager)
            {
                if (c.Size.X > maxItemWidth)
                {
                    maxItemWidth = c.Size.X;
                }

                c.Position = position;
                position.Y = c.Position.Y + 5f;
            }

            ControlManager.FocusChanged(startGame, null);
        }

        private void ControlManager_FocusChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Vector2 position = new Vector2(control.Position.X + maxItemWidth + 10f, control.Position.Y);

            arrowImage.SetPosition(position);
        }

        private void menu_ItemSelected(object sender, EventArgs e)
        {
            if (sender == startGame)
            {
                stateManager.PushState(gameRef.gamePlayScreen);
            }

            if (sender == loadGame)
            {
                stateManager.PushState(gameRef.gamePlayScreen);
            }

            if (sender == exitGame)
            {
                gameRef.Exit();
            }
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, playerIndexInControl);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            gameRef.spriteBatch.Begin();

            base.Draw(gameTime);

            ControlManager.Draw(gameRef.spriteBatch);

            gameRef.spriteBatch.End();
        }
    }
}
