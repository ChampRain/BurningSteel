using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using XRpgLibrary.SpriteClass;

namespace XRpgLibrary.TileEngine
{
    public enum CameraMode { Free, Follow };

    public class Camera
    {
        Vector2 position;
        float speed, zoom;
        Rectangle viewPortRectangle;
        private CameraMode mode;

        public Matrix Transformation
        {
            get { return Matrix.CreateScale(zoom)*Matrix.CreateTranslation(new Vector3(-Position, 0f)); }
        }

        public Rectangle ViewPortRectangle
        {
            get {return new Rectangle(viewPortRectangle.X, viewPortRectangle.Y, 
                                      viewPortRectangle.Width, viewPortRectangle.Height);}
        }

        public Vector2 Position
        {
            get { return position; }
            private set { position = value; }
        }

        public CameraMode CameraMode
        {
            get { return mode; }
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
            mode = CameraMode.Follow;
        }

        public Camera(Rectangle viewPortRect, Vector2 position)
        {
            speed = 4f;
            zoom = 1f;
            viewPortRectangle = viewPortRect;
            Position = position;
            mode = CameraMode.Follow;
        }

        public void Update(GameTime gameTime)
        {

            if (InputHandler.KeyReleased(Keys.PageUp) ||
                InputHandler.ButtonReleased(Buttons.LeftShoulder, PlayerIndex.One))
            {
                ZoomIn();
            }
            else if (InputHandler.KeyReleased(Keys.PageDown) ||
                InputHandler.ButtonReleased(Buttons.RightShoulder, PlayerIndex.One))
            {
                ZoomOut();
            }

            if (mode == CameraMode.Follow)
            {
                return;
            }

            Vector2 motion = Vector2.Zero;

            if (InputHandler.KeyDown(Keys.Left) || InputHandler.ButtonDown(Buttons.LeftThumbstickLeft, PlayerIndex.One))
            {
                motion.X = -speed;
            }
            else if (InputHandler.KeyDown(Keys.Right) || InputHandler.ButtonDown(Buttons.LeftThumbstickRight, PlayerIndex.One))
            {
                motion.X = speed;
            }

            if (InputHandler.KeyDown(Keys.Up) || InputHandler.ButtonDown(Buttons.LeftThumbstickUp, PlayerIndex.One))
            {
                motion.Y = -speed;
            }
            else if (InputHandler.KeyDown(Keys.Down) || InputHandler.ButtonDown(Buttons.LeftThumbstickDown, PlayerIndex.One))
            {
                motion.Y = speed;
            }

            if (motion != Vector2.Zero)
            {
                motion.Normalize();
                position += motion*speed;

                LockCamera();
            }
        }

        public void LockCamera()
        {
            position.X = MathHelper.Clamp(position.X, 0, TileMap.WidthInPixels - viewPortRectangle.Width);
            position.Y = MathHelper.Clamp(position.Y, 0, TileMap.HeightInPixels - viewPortRectangle.Height);
        }

        public void LockToSprite(AnimatedSprite sprite)
        {
            position.X = sprite.Position.X + sprite.Width/2 - (viewPortRectangle.Width/2);
            position.Y = sprite.Position.Y + sprite.Height/2 - (viewPortRectangle.Height/2);

            LockCamera();
        }

        public void ToggleCameraMode()
        {
            if (mode == CameraMode.Follow)
            {
                mode = CameraMode.Free;
            }
            else if (mode == CameraMode.Free)
            {
                mode = CameraMode.Follow;
            }
        }

        public void ZoomIn()
        {
            zoom += .25f;

            if (zoom > 1f)
            {
                zoom = 1f;
            }
        }

        public void ZoomOut()
        {
            zoom -= .25f;

            if (zoom < .5f)
            {
                zoom = .5f;
            }
        }
    }
}
