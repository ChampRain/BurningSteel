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
            backgroundImage = new PictureBox(Content.Load<Texture2D>(@"Backgrounds\titleScreen"),
                                             gameRef.ScreenRectangle);
            ControlManager.Add(backgroundImage);
            Texture2D arrowTexture = Content.Load<Texture2D>(@"GUI\menuArrow");

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
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (InputHandler.KeyReleased(Keys.Escape))
            {
                Game.Exit();
            }
            base.Draw(gameTime);
        }
    }
}
