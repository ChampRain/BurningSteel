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
    public abstract partial class BaseGameState : GameState
    {
        protected Game1 gameRef;
        protected ControlManager ControlManager;
        private PlayerIndex playerIndexInControl;

        public BaseGameState(Game game, GameStateManager manager) : base (game, manager)
        {
            gameRef = (Game1) game;
            playerIndexInControl = PlayerIndex.One;
        }

        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;

            SpriteFont menuFont = Content.Load<SpriteFont>(@"Fonts\ControlFont");
            ControlManager = new ControlManager(menuFont);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
