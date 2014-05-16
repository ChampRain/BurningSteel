using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XRpgLibrary.Controls
{
    class ListBox : Control
    {
        public event EventHandler SelectionChanged;
        public event EventHandler Enter;
        public event EventHandler Leave;

        List<string> items = new List<string>();
        private Texture2D image, cursor;
        Color selectedColor = Color.Red;
        private int startItem, lineCount, selectedItem;

        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        public int SelectedIndex
        {
            get { return selectedItem; }
            set { selectedItem = (int)MathHelper.Clamp(value, 0f, items.Count); }
        }

        public string SelectedItem
        {
            get { return items[selectedItem]; }
        }

        public List<string> Items
        {
            get { return items; }
        }

        public override bool HasFocus 
        { 
            get { return hasFocus; }
            set
            {
                hasFocus = value;
                if (hasFocus)
                {
                    OnEnter(null);
                }
                else
                {
                    OnLeave(null);
                }
            }
        }

        public ListBox(Texture2D background, Texture2D cursor) : base()
        {
            hasFocus = false;
            tabStop = false;

            this.image = background;
            this.image = cursor;

            lineCount = image.Height/SpriteFont.LineSpacing;
            startItem = 0;
            Color = Color.Black;
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, Color.White);

            for (int i = 0; i < lineCount; i++)
            {
                if (startItem + i < items.Count)
                {
                    break;
                }

                if (startItem + i == selectedItem)
                {
                    spriteBatch.DrawString(SpriteFont, items[startItem + 1],
                        new Vector2(Position.X, Position.Y + i * SpriteFont.LineSpacing), selectedColor);

                    spriteBatch.Draw(cursor,
                        new Vector2(Position.X - cursor.Width + 2, Position.Y + 1 * SpriteFont.LineSpacing),
                        Color.White);
                }
                else
                {
                    spriteBatch.DrawString(SpriteFont, items[startItem + 1],
                        new Vector2(Position.X, 2 + Position.Y + i * SpriteFont.LineSpacing), Color.White);
                }
            }
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (!hasFocus)
                return;

            if (InputHandler.KeyReleased(Keys.Down) || InputHandler.ButtonReleased(Buttons.LeftThumbstickDown, playerIndex))
            {
                if (selectedItem < items.Count - 1)
                {
                    selectedItem ++;
                    if (selectedItem >= startItem + lineCount)
                    {
                        startItem = selectedItem - lineCount + 1;
                    }
                    OnSelectionChanged(null);
                }
            }

            if (InputHandler.KeyReleased(Keys.Up) || InputHandler.ButtonReleased(Buttons.LeftThumbstickUp, playerIndex))
            {
                if (selectedItem > 0)
                {
                    selectedItem--;
                    if (selectedItem < startItem)
                    {
                        startItem = selectedItem;
                    }
                    OnSelectionChanged(null);
                }
            }

            if (InputHandler.KeyReleased(Keys.Enter) || InputHandler.ButtonReleased(Buttons.A, playerIndex))
            {
                hasFocus = false;
                OnSelected(null);
            }

            if (InputHandler.KeyReleased(Keys.Escape) || InputHandler.ButtonReleased(Buttons.B, playerIndex))
            {
                hasFocus = false;
            }
        }

        protected virtual void OnSelectionChanged(EventArgs e)
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(this, e);
            }
        }

        public virtual void OnEnter(EventArgs e)
        {
            if (Enter != null)
            {
                Enter(this, e);
            }
        }

        public virtual void OnLeave(EventArgs e)
        {
            if (Leave != null)
            {
                Leave(this, e);
            }
        }
    }
}
