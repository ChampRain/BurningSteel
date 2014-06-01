using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using XRpgLibrary.SpriteClass;
using XRpgLibrary.TileEngine;

namespace XRpgLibrary.SpriteClass
{
    public class AnimatedSprite
    {
        private Dictionary<AnimationKey, Animation> animations;
        AnimationKey currentAnimation;
        private bool isAnimating;

        private Texture2D texture;
        private Vector2 position, velocity;
        private float speed = 2.0f;

        public AnimationKey CurrentAnimation
        {
            get { return currentAnimation; } 
            set { currentAnimation = value; }
        }

        public bool IsAnimating
        {
            get { return isAnimating; } 
            set { isAnimating = value; }
        }

        public Vector2 Position
        {
            get { return position; } 
            set { position = value; }
        }

        public int Width
        {
            get { return animations[currentAnimation].FrameWidth; }
        }

        public int Height
        {
            get { return animations[currentAnimation].FrameHeight; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = MathHelper.Clamp(value, 1.0f, 16.0f); }
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set
            {
                velocity = value;
                if (velocity != Vector2.Zero)
                {
                    velocity.Normalize();
                }
            }
        }

        public AnimatedSprite(Texture2D sprite, Dictionary<AnimationKey, Animation> animation)
        {
            texture = sprite;
            animations = new Dictionary<AnimationKey, Animation>();

            foreach (AnimationKey key in animation.Keys)
            {
                animations.Add(key, (Animation)animation[key].Clone());
            }
        }

        public void Update(GameTime gameTime)
        {
            if (isAnimating)
            {
                animations[currentAnimation].Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animations[currentAnimation].CurrentFrameRect, Color.White);
        }

        public void LockToMap()
        {
            position.X = MathHelper.Clamp(position.X, 0, TileMap.WidthInPixels - Width);
            position.Y = MathHelper.Clamp(position.Y, 0, TileMap.HeightInPixels - Height);
        }
    }
}
