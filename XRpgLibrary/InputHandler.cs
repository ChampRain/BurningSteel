using System;
using System.Collections.Generic;
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
    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {
        private static GamePadState[] _gamePadStates;
        private static GamePadState[] _lastGamePadStates;

        private static KeyboardState _keyboardState;
        private static KeyboardState _lastKeyboardState;

        public static KeyboardState KeyboardState
        { get {return _keyboardState;} }
        public static KeyboardState LastKeyboardState
        { get { return _lastKeyboardState; } }
        public static GamePadState[] GamePadStates
        { get { return _gamePadStates; } }
        public static GamePadState[] LastGamePadStates
        { get { return _lastGamePadStates; } }


        public InputHandler(Game game) : base(game)
        {
            _keyboardState = Keyboard.GetState();
            _gamePadStates = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];

            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
            {
                _gamePadStates[(int) index] = GamePad.GetState(index);
            }
        }

        /// <summary>
        /// Allows the game component to perform any in
        /// itialization it needs to before starting
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
            _lastKeyboardState = _keyboardState;
            _keyboardState = Keyboard.GetState();

            _lastGamePadStates = (GamePadState[]) _gamePadStates.Clone();

            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
            {
                _gamePadStates[(int) index] = GamePad.GetState(index);
            }

            base.Update(gameTime);
        }

        public static void Flush()
        {
            _lastKeyboardState = _keyboardState;
        }

        public static Boolean KeyReleased(Keys key)
        {
            return _keyboardState.IsKeyUp(key) && _lastKeyboardState.IsKeyDown(key);
        }

        public static Boolean KeyPressed(Keys key)
        {
            return _keyboardState.IsKeyDown(key) && _lastKeyboardState.IsKeyUp(key);
        }

        public static Boolean KeyDown(Keys key)
        {
            return _keyboardState.IsKeyDown(key);
        }

        public static Boolean ButtonReleased(Buttons button, PlayerIndex index)
        {
            return _gamePadStates[(int)index].IsButtonUp(button)
                && _lastGamePadStates[(int)index].IsButtonDown(button);
        }

        public static Boolean ButtonPressed(Buttons button, PlayerIndex index)
        {
            return _gamePadStates[(int)index].IsButtonDown(button)
                && _lastGamePadStates[(int)index].IsButtonUp(button);
        }

        public static Boolean ButtonDown(Buttons button, PlayerIndex index)
        {
            return _gamePadStates[(int) index].IsButtonDown(button);
        }
    }
}
