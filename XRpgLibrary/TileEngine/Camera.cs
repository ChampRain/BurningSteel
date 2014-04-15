using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace XRpgLibrary.TileEngine
{
    public class Camera
    {
        Vector2 position;
        float speed, zoom;
        Rectangle viewPortRectangle;

        public Vector2 Position
        {
            get { return position; }
            private set { position = value; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = (float) MathHelper.Clamp(speed, 1f, 16f); }
        }

        public float Zoom
        {
            get { return zoom; }
        }

        public Camera(Rectangle viewPortRect)
        {
            speed = 4f;
            zoom = 1f;
            viewPortRectangle = viewPortRect;
        }

        public Camera(Rectangle viewPortRect, Vector2 position)
        {
            speed = 4f;
            zoom = 1f;
            viewPortRectangle = viewPortRect;
            Position = position;
        }

        public void Update(GameTime gameTime)
        {
            Vector2 motion = Vector2.Zero;

            if (InputHandler.KeyDown(Keys.Left))
            {
                motion.X = -speed;
            }
            else if (InputHandler.KeyDown((Keys.Right)))
            {
                motion.X = speed;
            }

            if (InputHandler.KeyDown(Keys.Up))
            {
                motion.Y = -speed;
            }
            else if (InputHandler.KeyDown(Keys.Down))
            {
                motion.Y = speed;
            }

            if (motion != Vector2.Zero)
            {
                motion.Normalize();
            }

            position += motion*speed;

            LockCamera();
        }

        public void LockCamera()
        {
            position.X = MathHelper.Clamp(position.X, 0, TileMap.WidthInPixels - viewPortRectangle.Width);
            position.Y = MathHelper.Clamp(position.Y, 0, TileMap.HeightInPixels - viewPortRectangle.Height);
        }
    }
}
