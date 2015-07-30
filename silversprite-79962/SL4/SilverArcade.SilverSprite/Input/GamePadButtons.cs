using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Microsoft.Xna.Framework.Input
{
    // Summary:
    //     Identifies whether the buttons on an Xbox 360 Controller are pressed or released.
    //     Reference page contains links to related code samples.
    public struct GamePadButtons
    {
        KeyboardState _keyBoardState;

        public GamePadButtons(KeyboardState keyBoardState)
        {
            _keyBoardState = keyBoardState;
        }

        //
        // Summary:
        //     Initializes a new instance of the GamePadButtons class, setting the specified
        //     buttons to pressed.
        //
        // Parameters:
        //   buttons:
        //     Buttons to initialize as pressed. Specify a single button, or combine multiple
        //     buttons using a bitwise OR operation.
        //public GamePadButtons(Buttons buttons)
        //{
        //}

        // Summary:
        //     Determines whether two GamePadButtons instances are not equal.
        //
        // Parameters:
        //   left:
        //     Object on the left of the equal sign.
        //
        //   right:
        //     Object on the right of the equal sign.
        //
        // Returns:
        //     true if the objects are not equal; false otherwise.
        public static bool operator !=(GamePadButtons left, GamePadButtons right)
        {
            return true;
        }
        //
        // Summary:
        //     Determines whether two GamePadButtons instances are equal.
        //
        // Parameters:
        //   left:
        //     Object on the left of the equal sign.
        //
        //   right:
        //     Object on the right of the equal sign.
        //
        // Returns:
        //     true if the instances are equal; false otherwise.
        public static bool operator ==(GamePadButtons left, GamePadButtons right)
        {
            return false;
        }

        // Summary:
        //     Identifies whether the A button on the Xbox 360 Controller is pressed.
        //
        // Returns:
        //     ButtonState.Pressed if the button is pressed; ButtonState.Released otherwise.
        public ButtonState A {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.A);
            }
        }
        //
        // Summary:
        //     Identifies whether the B button on the Xbox 360 Controller is pressed.
        //
        // Returns:
        //     ButtonState.Pressed if the button is pressed; ButtonState.Released otherwise.
        public ButtonState B
        {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.B);
            }
        }
        //
        // Summary:
        //     Identifies whether the BACK button on the Xbox 360 Controller is pressed.
        //
        // Returns:
        //     ButtonState.Pressed if the button is pressed; ButtonState.Released otherwise.
        public ButtonState Back
        {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.Back);
            }
        }
        //
        // Summary:
        //     Identifies whether the BigButton button is pressed.
        //
        // Returns:
        //     ButtonState.Pressed if the button is pressed; ButtonState.Released otherwise.
        public ButtonState BigButton
        {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.BigButton);
            }
        }
        //
        // Summary:
        //     Identifies whether the left shoulder (bumper) button on the Xbox 360 Controller
        //     is pressed.
        //
        // Returns:
        //     ButtonState.Pressed if the button is pressed; ButtonState.Released otherwise.
        public ButtonState LeftShoulder
        {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.LeftShoulder);
            }
        }
        //
        // Summary:
        //     Identifies whether the left stick button on the Xbox 360 Controller is pressed
        //     (the stick is "clicked" in).
        //
        // Returns:
        //     ButtonState.Pressed if the button is pressed; ButtonState.Released otherwise.
        public ButtonState LeftStick
        {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.LeftStick);
            }
        }
        //
        // Summary:
        //     Identifies whether the right shoulder (bumper) button on the Xbox 360 Controller
        //     is pressed.
        //
        // Returns:
        //     ButtonState.Pressed if the button is pressed; ButtonState.Released otherwise.
        public ButtonState RightShoulder
        {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.RightShoulder);
            }
        }
        //
        // Summary:
        //     Identifies whether the right stick button on the Xbox 360 Controller is pressed
        //     (the stick is "clicked" in).
        //
        // Returns:
        //     ButtonState.Pressed if the button is pressed; ButtonState.Released otherwise.
        public ButtonState RightStick
        {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.RightStick);
            }
        }
        //
        // Summary:
        //     Identifies whether the START button on the Xbox 360 Controller is pressed.
        //
        // Returns:
        //     ButtonState.Pressed if the button is pressed; ButtonState.Released otherwise.
        public ButtonState Start
        {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.Start);
            }
        }
        //
        // Summary:
        //     Identifies whether the X button on the Xbox 360 Controller is pressed.
        //
        // Returns:
        //     ButtonState.Pressed if the button is pressed; ButtonState.Released otherwise.
        public ButtonState X
        {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.X);
            }
        }
        //
        // Summary:
        //     Identifies whether the Y button on the Xbox 360 Controller is pressed.
        //
        // Returns:
        //     ButtonState.Pressed if the button is pressed; ButtonState.Released otherwise.
        public ButtonState Y
        {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.Y);
            }
        }

        // Summary:
        //     Returns a value that indicates whether the current instance is equal to a
        //     specified object.
        //
        // Parameters:
        //   obj:
        //     Object with which to make the comparison.
        //
        // Returns:
        //     true if the current instance is equal to the specified object; false otherwise.
        public override bool Equals(object obj)
        {
            return false;
        }
        //
        // Summary:
        //     Gets the hash code for this instance.
        //
        // Returns:
        //     Hash code for this object.
        public override int GetHashCode()
        {
            return 0;
        }
        //
        // Summary:
        //     Retrieves a string representation of this object.
        //
        // Returns:
        //     String representation of this object.
        public override string ToString()
        {
            return "Microsoft.Xna.Framework.GamePadButtons";
        }
    }

}
