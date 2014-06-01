using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.CharacterClasses;
using XRpgLibrary.ItemClasses;
using XRpgLibrary.TileEngine;

namespace XRpgLibrary.WorldClasses
{
    public class Level
    {
        private readonly TileMap tileMap;
        private readonly List<Character> characters;
        private readonly List<ItemSprite> chests; 

        public TileMap TileMap
        {
            get { return tileMap; }
        }

        public List<Character> Characters
        {
            get { return characters; }
        }

        public List<ItemSprite> Chests
        {
            get { return chests; }
        }

        public Level(TileMap tileMap)
        {
            this.tileMap = tileMap;
            characters = new List<Character>();
            chests = new List<ItemSprite>();
        }

        public void Update(GameTime gameTime)
        {
            foreach (Character c in Characters)
            {
                c.Update(gameTime);
            }

            foreach (ItemSprite c in Chests)
            {
                c.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Camera camera)
        {
            tileMap.Draw(spriteBatch, camera);
            foreach (Character c in Characters)
            {
                c.Draw(gameTime, spriteBatch);
            }

            foreach (ItemSprite chest in Chests)
            {
                chest.Draw(gameTime, spriteBatch);
            }
        }
    }
}
