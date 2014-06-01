using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.ItemClasses;
using XRpgLibrary.SpriteClass;

namespace XRpgLibrary.ItemClasses
{
    public class ItemSprite
    {
        private BaseSprite sprite;
        private BaseItem item;

        public BaseSprite Sprite
        {
            get { return sprite; }
        }

        public BaseItem Item
        {
            get { return item; }
        }

        public ItemSprite(BaseItem item, BaseSprite sprite)
        {
            this.item = item;
            this.sprite = sprite;
        }

        public virtual void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(gameTime, spriteBatch);
        }
    }
}
