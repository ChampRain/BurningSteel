using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.ItemClasses;

namespace XRpgLibrary.WorldClasses
{
    public class World
    {
        ItemManager itemManager = new ItemManager();
        private Rectangle screenRect;

        public Rectangle ScreenRectangle
        {
            get { return screenRect; }
        }

        public World(Rectangle screenRect)
        {
            this.screenRect = screenRect;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
    }
}
