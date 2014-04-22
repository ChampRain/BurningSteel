using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XRpgLibrary.Controls
{
    public class Label : Control
    {
        public Label()
        {
            tabStop = false;
        }

        public override void Update(GameTime gameTime)
        {
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont,text,position,color);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {

        }
    }
}
