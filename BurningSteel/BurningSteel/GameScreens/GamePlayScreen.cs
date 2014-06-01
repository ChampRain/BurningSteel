using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using BurningSteel.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XRpgLibrary;
using XRpgLibrary.SpriteClass;
using XRpgLibrary.TileEngine;
using XRpgLibrary.WorldClasses;

namespace BurningSteel.GameScreens
{
    public class GamePlayScreen : BaseGameState
    {
        private Engine engine = new Engine(32,32);
        private static Player player;
        private static World world;

        public static World World
        {
            get { return world; }
            set { world = value; }
        }

        public static Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public GamePlayScreen(Game game, GameStateManager manager) : base(game, manager)
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

        public override void Draw(GameTime gameTime)
        {
            gameRef.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,
                                      SamplerState.PointClamp, null, null, null, player.Camera.Transformation);

            world.DrawLevel(gameTime, gameRef.spriteBatch, player.Camera);

            player.Draw(gameTime, gameRef.spriteBatch);

            base.Draw(gameTime);
            gameRef.spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);

            base.Update(gameTime);
        }
    }
}
