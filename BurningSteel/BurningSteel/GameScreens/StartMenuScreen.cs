using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using XRpgLibrary;

namespace BurningSteel.GameScreens
{
    public class StartMenuScreen : BaseGameState
    {
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
