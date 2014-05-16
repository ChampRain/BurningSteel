using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.TileEngine;

namespace XRpgLibrary.WorldClasses
{
    public class Level
    {
        private readonly TileMap tileMap;

        public TileMap TileMap
        {
            get { return tileMap; }
        }

        public Level(TileMap tileMap)
        {
            this.tileMap = tileMap;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            tileMap.Draw(spriteBatch, camera);
        }
    }
}
