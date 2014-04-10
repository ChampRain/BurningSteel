using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XRpgLibrary
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GameState : Microsoft.Xna.Framework.DrawableGameComponent
    {

        private List<GameComponent> childComponents;
        private GameState tag;
        protected GameStateManager stateManager;

        public List<GameComponent> Components
        {
            get { return childComponents; }
        }


        public GameState Tag
        {
            get { return tag; }
        }

        public GameState(Game game, GameStateManager manager) : base(game)
        {
            stateManager = manager;
            childComponents = new List<GameComponent>();
            tag = this;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent component in childComponents.Where(component => component.Enabled))
            {
                component.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent drawComponent;

            foreach (DrawableGameComponent component in childComponents.OfType<DrawableGameComponent>())
            {
                drawComponent = component as DrawableGameComponent;

                if (drawComponent.Visible)
                {
                    drawComponent.Draw(gameTime);
                }
            }

            base.Draw(gameTime);
        }

        protected internal virtual void StateChange(Object sender, EventArgs e)
        {
            if (stateManager.CurrentState == tag)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        protected virtual void Show()
        {
            Visible = true;
            Enabled = true;

            foreach (GameComponent component in childComponents)
            {
                component.Enabled = true;

                if (component is DrawableGameComponent)
                {
                    ((DrawableGameComponent)component).Visible = true;
                }
            }
        }

        protected virtual void Hide()
        {
            Visible = false;
            Enabled = false;

            foreach (GameComponent component in childComponents)
            {
                component.Enabled = false;

                if (component is DrawableGameComponent)
                {
                    ((DrawableGameComponent)component).Visible = false;
                }
            }
        }
    }
}
