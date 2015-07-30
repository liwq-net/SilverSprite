using System;
using Input = Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Windows.Input;

namespace Microsoft.Xna.Framework.Input
{
    public struct GamePadState
    {
        GamePadThumbSticks _thumbSticks;
        GamePadTriggers _triggers;
        GamePadDPad _dpad;
        GamePadButtons _buttons;

        static Dictionary<Buttons, Input.Keys> keyMappings;
        KeyboardState _keyBoardState;

        public static void MapKey(Buttons b, Keys k)
        {

            if (KeyboardState.IsKeyWatched(k))
            {
                if (keyMappings.ContainsKey(b))
                {
                    keyMappings[b] = k;
                }
                else
                {
                    keyMappings.Add(b, k);
                }
            }
            else
            {
                throw new InvalidOperationException("Key mapping " + k.ToString() + " not available.");
            }
        }

        public void SetCurrentState(KeyboardState keyBoardState)
        {
            _keyBoardState = keyBoardState;

            _buttons = new GamePadButtons(_keyBoardState);
            _triggers = new GamePadTriggers(_keyBoardState);
            _thumbSticks = new GamePadThumbSticks(_keyBoardState);
            _dpad = new GamePadDPad(_keyBoardState);
        }

        public static void Initialize()
        {
            if (keyMappings != null) return;
            keyMappings = new Dictionary<Buttons, Keys>();
            keyMappings.Add(Input.Buttons.A, Keys.Space);
            keyMappings.Add(Input.Buttons.B, Keys.Delete);
            keyMappings.Add(Input.Buttons.Y, Keys.Y);
            keyMappings.Add(Input.Buttons.X, Keys.X);
            keyMappings.Add(Input.Buttons.DPadLeft, Keys.Left);
            keyMappings.Add(Input.Buttons.DPadRight, Keys.Right);
            keyMappings.Add(Input.Buttons.DPadUp, Keys.Up);
            keyMappings.Add(Input.Buttons.DPadDown, Keys.Down);
            keyMappings.Add(Input.Buttons.Back, Keys.Back);
            keyMappings.Add(Input.Buttons.Start, Keys.Enter);
        }

        public GamePadButtons Buttons
        {
            get
            {
                return _buttons;
            }
        }

        public static ButtonState GetButtonState(KeyboardState keyBoardState, Buttons b)
        {



            for (int i = 1; i <= (int)Input.Buttons.Y; i *= 2)
            {
                if (((int)b & i) == 0) continue;

                if (b == Input.Buttons.LeftTrigger)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Is Pressed - "));
                }

                if (keyMappings.ContainsKey(b))
                {
                    return keyBoardState.IsKeyDown(keyMappings[b]) ? ButtonState.Pressed : ButtonState.Released;
                }
                else
                {
                    return ButtonState.Released;
                }
            }
            return ButtonState.Released;
        }

        public bool IsButtonUp(Buttons b)
        {
            return !IsButtonDown(b);
        }

        public bool IsButtonDown(Buttons b)
        {
            return (GamePadState.GetButtonState(_keyBoardState, b) == ButtonState.Pressed);
        }

        public GamePadThumbSticks ThumbSticks
        {
            get
            {
                return _thumbSticks;
            }
        }

        public GamePadDPad DPad
        {
            get
            {
                return _dpad;
            }
        }

        public GamePadTriggers Triggers
        {
            get
            {
                return _triggers;
            }
        }

        public bool IsConnected
        {
            get
            {
                return false;
            }
        }
    }
}
