using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.TileEngine;

namespace BurningSteel.Components
{
    public class Player
    {
        private Camera camera;
        private Game1 gameRef;

        public Camera Camera
        {
            get { return camera; }
            set { camera = value; }
        }

        public Player(Game game)
        {
            gameRef = (Game1) game;
            camera = new Camera(gameRef.ScreenRectangle);
        }

        public void Update(GameTime gameTime)
        {
            camera.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }
    }
}
