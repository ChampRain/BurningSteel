using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.TileEngine;

namespace XRpgLibrary.SpriteClass
{
    public class BaseSprite
    {
        protected Texture2D texture;
        protected Rectangle SourceRectangle;

        protected Vector2 position, velocity;
        protected float speed = 2.0f;

        public int Width
        {
            get { return SourceRectangle.Width; }
        }

        public int Height
        {
            get { return SourceRectangle.Height; }
        }

        public Rectangle Rectangle
        {
            get {return new Rectangle((int) position.X, (int) position.Y, Width, Height);}
        }

        public float Speed
        {
            get { return speed; }
            set { speed = MathHelper.Clamp(value, 1.0f, 16.0f ); }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Velocity
        {
            get { return position; }
            set
            {
                velocity = value;
                if (velocity != Vector2.Zero)
                {
                    velocity.Normalize();
                }
            }
        }

        public BaseSprite(Texture2D image, Rectangle? sourceRectangle)
        {
            texture = image;

            if (sourceRectangle.HasValue)
            {
                this.SourceRectangle = sourceRectangle.Value;
            }
            else
            {
                SourceRectangle = new Rectangle(0, 0, image.Width, image.Height);
            }

            velocity = Vector2.Zero;
            position = Vector2.Zero;
        }

        public BaseSprite(Texture2D image, Rectangle? sourceRectangle, Point tile) : this(image, sourceRectangle)
        {
            position = new Vector2(tile.X * Engine.TileWidth, tile.Y * Engine.TileHeight);
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, SourceRectangle, Color.White);
        }
    }
}
