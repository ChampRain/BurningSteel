using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XRpgLibrary.Controls
{
    public abstract class Control
    {
        protected string name, text, type;
        protected Vector2 size, position;
        protected object value;
        protected bool hasFocus, enabled, visible, tabStop;
        protected SpriteFont spriteFont;
        protected Color color;
        protected int changed;

        public EventHandler Selected;

        public int Changed
        {
            get { return changed; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public Vector2 Size
        {
            get { return size; }
            set { size = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set
            {
                position = value;
                position.Y = (int) position.Y;
            }
        }

        public object Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public bool HasFocus
        {
            get { return hasFocus; }
            set { hasFocus = value; }
        }
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
        public bool TabStop
        {
            get { return tabStop; }
            set { tabStop = value; }
        }
        public SpriteFont SpriteFont
        {
            get { return spriteFont; }
            set { spriteFont = value; }
        }
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public Control()
        {
            Color = Color.White;
            enabled = true;
            visible = true;
            spriteFont = ControlManager.SpriteFont;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void HandleInput(PlayerIndex playerIndex);

        protected virtual void OnSelected(EventArgs e)
        {
            if (Selected != null)
            {
                Selected(this, e);
            }
        }
    }
}
