#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Windows;

namespace Microsoft.Xna.Framework.Input
{
    public static class Keyboard
    {
        static KeyboardState state;

        public static bool CreatesNewState = true;


        #region Constructors

        static Keyboard()
        {
            state.Initialize();
        }

        #endregion Constructors

        #region Public Methods

        public static void Update()
        {
            if (CreatesNewState)
            {
                state = new KeyboardState();
            }
            state.Update();
        }

        public static KeyboardState GetState()
        {
            //TODO: Will this work? The state contains an object on the heap. Will the reference be the same
            // when you return the "state" from this class?
            if (CreatesNewState)
            {
                return state.Clone();
            }
            else
            {
                return state;
            }
        }

        #endregion
    }
}
