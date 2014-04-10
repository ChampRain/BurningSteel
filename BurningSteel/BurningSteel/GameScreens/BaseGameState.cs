using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using XRpgLibrary;

namespace BurningSteel.GameScreens
{
    public abstract partial class BaseGameState : GameState
    {
        protected Game1 gameRef;

        public BaseGameState(Game game, GameStateManager manager) : base (game, manager)
        {
            gameRef = (Game1) game;
        }
    }
}
