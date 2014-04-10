using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary;

namespace BurningSteel.GameScreens
{
    class TitleScreen : BaseGameState
    {

        private Texture2D backgroundImage;

        public TitleScreen(Game game, GameStateManager manager) : base(game, manager)
        {
            
        }

        protected override void LoadContent()
        {
            ContentManager Content = gameRef.Content;
            backgroundImage = Content.Load<Texture2D>("backgroundImg.png");  //add in background
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            gameRef.spriteBatch.Begin();

            base.Draw(gameTime);

            gameRef.spriteBatch.Draw(backgroundImage, gameRef.ScreenRectangle, Color.White);

            gameRef.spriteBatch.End();
        }
    }
}
