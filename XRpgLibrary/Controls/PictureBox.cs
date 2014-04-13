using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace XRpgLibrary.Controls
{
    public class PictureBox : Control
    {

        private Texture2D image;
        private Rectangle sourceRect;
        private Rectangle destRect;

        public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }
        public Rectangle SourceRect
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }
        public Rectangle DestRec
        {
            get { return destRect; }
            set { destRect = value; }
        }

        public PictureBox(Texture2D image, Rectangle destination)
        {
            Image = image;
            DestRec = destination;
            SourceRect = new Rectangle(0,0,image.Width, image.Height);
            Color = Color.White;
        }

        public PictureBox(Texture2D image, Rectangle destination, Rectangle source)
        {
            Image = image;
            DestRec = destination;
            SourceRect = source;
            Color = Color.White;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, DestRec, SourceRect, Color);
        }

        public override void HandleInput(Microsoft.Xna.Framework.PlayerIndex playerIndex)
        {
        }

        public void SetPosition(Vector2 newPosition)
        {
            DestRec = new Rectangle((int)newPosition.X, (int)newPosition.Y, SourceRect.Width, SourceRect.Height);
        }
    }
}
