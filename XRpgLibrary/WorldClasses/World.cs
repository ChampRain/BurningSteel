using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.ItemClasses;
using XRpgLibrary.TileEngine;

namespace XRpgLibrary.WorldClasses
{
    public class World : DrawableGameComponent
    {
        ItemManager itemManager = new ItemManager();
        private Rectangle screenRect;
        private readonly List<Level> levels = new List<Level>();
        private int currentLevel = -1;

        public List<Level> Levels
        {
            get { return levels; }
        }

        public int CurrentLevel
        {
            get { return currentLevel; }
            set{
                if (value < 0 || value > levels.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                if (levels[value] == null)
                {
                    throw new NullReferenceException();
                }
                currentLevel = value;
            }
        }

        public Rectangle ScreenRectangle
        {
            get { return screenRect; }
        }

        public World(Game game, Rectangle screenRect) : base (game)
        {
            this.screenRect = screenRect;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }

        public void DrawLevel(GameTime gameTime, SpriteBatch spriteBatch, Camera camera)
        {
            levels[currentLevel].Draw(gameTime, spriteBatch, camera);
        }
    }
}
