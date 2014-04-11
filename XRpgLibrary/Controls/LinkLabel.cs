using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace XRpgLibrary.Controls
{
    public class LinkLabel : Control
    {

        private Color selectedColor = Color.Red;

        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        public LinkLabel()
        {
            tabStop = true;
            hasFocus = false;
            Position = Vector2.Zero;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFont, Text, Position, hasFocus ? selectedColor : Color);
        }

        public override void HandleInput(Microsoft.Xna.Framework.PlayerIndex playerIndex)
        {
            if (!hasFocus)
            {
                return;
            }

            if (InputHandler.KeyReleased(Keys.Enter) ||
                InputHandler.ButtonReleased(Buttons.A, playerIndex))
            {
                base.OnSelected(null);
            }
        }
    }
}
