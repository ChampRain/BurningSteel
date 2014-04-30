using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XRpgLibrary.Controls
{
    public class LeftRightSelector : Control
    {
        public EventHandler SelectedChanged;

        List<String> items = new List<string>();
        private Texture2D leftTexture, rightTexture, stopTexture;
        private Color selectedColor = Color.Red;
        private int maxItemWidth, selectedItem;

        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        public int SelectedIndex 
        {
            get { return selectedItem; }
            set { selectedItem = (int) MathHelper.Clamp(value, 0f, items.Count); }
        }

        public string SelectedItem
        {
            get { return items[selectedItem]; }
        }

        public List<String> Items
        {
            get { return items; }
        }

        public LeftRightSelector(Texture2D leftArrow, Texture2D rightArrow, Texture2D stop)
        {
            leftTexture = leftArrow;
            rightTexture = rightArrow;
            stopTexture = stop;
            TabStop = true;
            Color = Color.White;
        }

        public void SetItems(string[] items, int maxWidth)
        {
            this.items.Clear();
            foreach (string s in items)
            {
                this.items.Add(s);
            }
            maxItemWidth = maxWidth;
        }

        protected void OnSelectedChanged()
        {
            base.OnSelected(null);

            if (SelectedChanged != null)
            {
                SelectedChanged(this, null);
            }
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 drawTo = position;

            spriteBatch.Draw(selectedItem != 0 ? leftTexture : stopTexture, drawTo, Color);

            drawTo.X += leftTexture.Width + 55f;

            float itemWidth = SpriteFont.MeasureString(items[selectedItem]).X;
            float offset = (maxItemWidth - itemWidth)/2;

            drawTo.X += offset;

            spriteBatch.DrawString(spriteFont, items[selectedItem], drawTo, hasFocus ? selectedColor : Color);

            drawTo.X +=  -1*offset  + 95f;

            spriteBatch.Draw(selectedItem != items.Count - 1 ? rightTexture : stopTexture, drawTo, Color.White);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (items.Count == 0)
            {
                return;
            }

            if (InputHandler.ButtonReleased(Buttons.LeftThumbstickLeft, playerIndex) ||
                InputHandler.ButtonReleased(Buttons.DPadLeft, playerIndex) ||
                InputHandler.KeyReleased(Keys.Left))
            {
                if (this.hasFocus)
                {

                    selectedItem--;
                    if (selectedItem < 0)
                    {
                        selectedItem = 0;

                    }
                    OnSelectedChanged();
                }
            }

            if (InputHandler.ButtonReleased(Buttons.LeftThumbstickRight, playerIndex) ||
                InputHandler.ButtonReleased(Buttons.DPadRight, playerIndex) ||
                InputHandler.KeyReleased(Keys.Right))
            {
                if (this.hasFocus)
                {
                    selectedItem++;
                    if (selectedItem >= items.Count)
                    {

                        selectedItem = items.Count - 1;
                    }
                }
                OnSelectedChanged();
            }
        }
    }
}
