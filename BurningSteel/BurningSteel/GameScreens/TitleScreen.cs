using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary;
using XRpgLibrary.Controls;

namespace BurningSteel.GameScreens
{
    public class TitleScreen : BaseGameState
    {

        Texture2D backgroundImage;
        LinkLabel startLabel;

        public TitleScreen(Game game, GameStateManager manager) : base(game, manager)
        {
            
        }

        protected override void LoadContent()
        {
            ContentManager content = gameRef.Content;
            backgroundImage = content.Load<Texture2D>(@"Backgrounds\introbackground");  //add in background

            base.LoadContent();

            startLabel = new LinkLabel();
            startLabel.Color = Color.White;
            startLabel.Position = new Vector2(350,600);
            startLabel.Text = "Press ENTER To Begin";
            startLabel.TabStop = true;
            startLabel.HasFocus = true;
            startLabel.Selected += new EventHandler(linkLabel_Selected);

            ControlManager.Add(startLabel);
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

            gameRef.spriteBatch.Draw(backgroundImage, gameRef.ScreenRectangle, Color.White);

            ControlManager.Draw(gameRef.spriteBatch);

            gameRef.spriteBatch.End();
        }

        private void linkLabel_Selected(object sender, EventArgs e)
        {
            stateManager.PushState(gameRef.startMenuScreen);
        }
    }
}
