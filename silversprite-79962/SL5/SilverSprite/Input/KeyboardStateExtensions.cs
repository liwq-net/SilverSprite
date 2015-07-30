#region License
/*
MIT License
Copyright � 2006 The Mono.Xna Team

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

using System.Collections.Generic;
using SWI = System.Windows.Input;
using System;
using System.Windows;

namespace Microsoft.Xna.Framework.Input
{
    public static class KeyboardStateExtensions
    {
        static bool initialized = false;

        static Dictionary<Keys, SWI.Key> keyXref;

        static Dictionary<int, Keys> mPlatformSpecificKeys;

        #region Public Methods

        public static void Initialize()
        {
            PopulateKeyDictionaries();
            initialized = true;
        }

        public static bool IsKeyDown(this KeyboardState kh, Keys key)
        {
            if (!initialized) Initialize();
            return kh.IsKeyDown(keyXref[key]);
        }

        public static bool IsKeyUp(this KeyboardState kh, Keys key)
        {
            if (!initialized) Initialize();
            return !kh.IsKeyDown(keyXref[key]);
        }

        #endregion
        
        static void PopulateKeyDictionaries()
        {
            PopulateXref();
            PopulatePlatformSpecificKeys();
        }

        static void PopulateXref()
        {
            keyXref = new Dictionary<Keys, System.Windows.Input.Key>();
            keyXref.Add(Keys.A, SWI.Key.A);
            keyXref.Add(Keys.B, SWI.Key.B);
            keyXref.Add(Keys.C, SWI.Key.C);
            keyXref.Add(Keys.D, SWI.Key.D);
            keyXref.Add(Keys.E, SWI.Key.E);
            keyXref.Add(Keys.F, SWI.Key.F);
            keyXref.Add(Keys.G, SWI.Key.G);
            keyXref.Add(Keys.H, SWI.Key.H);
            keyXref.Add(Keys.I, SWI.Key.I);
            keyXref.Add(Keys.J, SWI.Key.J);
            keyXref.Add(Keys.K, SWI.Key.K);
            keyXref.Add(Keys.L, SWI.Key.L);
            keyXref.Add(Keys.M, SWI.Key.M);
            keyXref.Add(Keys.N, SWI.Key.N);
            keyXref.Add(Keys.O, SWI.Key.O);
            keyXref.Add(Keys.P, SWI.Key.P);
            keyXref.Add(Keys.Q, SWI.Key.Q);
            keyXref.Add(Keys.R, SWI.Key.R);
            keyXref.Add(Keys.S, SWI.Key.S);
            keyXref.Add(Keys.T, SWI.Key.T);
            keyXref.Add(Keys.U, SWI.Key.U);
            keyXref.Add(Keys.V, SWI.Key.V);
            keyXref.Add(Keys.W, SWI.Key.W);
            keyXref.Add(Keys.X, SWI.Key.X);
            keyXref.Add(Keys.Y, SWI.Key.Y);
            keyXref.Add(Keys.Z, SWI.Key.Z);
            keyXref.Add(Keys.Up, SWI.Key.Up);
            keyXref.Add(Keys.Down, SWI.Key.Down);
            keyXref.Add(Keys.Left, SWI.Key.Left);
            keyXref.Add(Keys.Right, SWI.Key.Right);
            keyXref.Add(Keys.Enter, SWI.Key.Enter);
            keyXref.Add(Keys.Space, SWI.Key.Space);
            keyXref.Add(Keys.Back, SWI.Key.Back);
            keyXref.Add(Keys.Delete, SWI.Key.Delete);
            keyXref.Add(Keys.Escape, SWI.Key.Escape);

            keyXref.Add(Keys.D0, SWI.Key.D0);
            keyXref.Add(Keys.D1, SWI.Key.D1);
            keyXref.Add(Keys.D2, SWI.Key.D2);
            keyXref.Add(Keys.D3, SWI.Key.D3);
            keyXref.Add(Keys.D4, SWI.Key.D4);
            keyXref.Add(Keys.D5, SWI.Key.D5);
            keyXref.Add(Keys.D6, SWI.Key.D6);
            keyXref.Add(Keys.D7, SWI.Key.D7);
            keyXref.Add(Keys.D8, SWI.Key.D8);
            keyXref.Add(Keys.D9, SWI.Key.D9);

            keyXref.Add(Keys.F1, SWI.Key.F1);
            keyXref.Add(Keys.F2, SWI.Key.F2);
            keyXref.Add(Keys.F3, SWI.Key.F3);
            keyXref.Add(Keys.F4, SWI.Key.F4);
            keyXref.Add(Keys.F5, SWI.Key.F5);
            keyXref.Add(Keys.F6, SWI.Key.F6);
            keyXref.Add(Keys.F7, SWI.Key.F7);
            keyXref.Add(Keys.F8, SWI.Key.F8);
            keyXref.Add(Keys.F9, SWI.Key.F9);
            keyXref.Add(Keys.F10, SWI.Key.F10);
            keyXref.Add(Keys.F11, SWI.Key.F11);
            keyXref.Add(Keys.F12, SWI.Key.F12);

            keyXref.Add(Keys.NumPad0, SWI.Key.NumPad0);
            keyXref.Add(Keys.NumPad1, SWI.Key.NumPad1);
            keyXref.Add(Keys.NumPad2, SWI.Key.NumPad2);
            keyXref.Add(Keys.NumPad3, SWI.Key.NumPad3);
            keyXref.Add(Keys.NumPad4, SWI.Key.NumPad4);
            keyXref.Add(Keys.NumPad5, SWI.Key.NumPad5);
            keyXref.Add(Keys.NumPad6, SWI.Key.NumPad6);
            keyXref.Add(Keys.NumPad7, SWI.Key.NumPad7);
            keyXref.Add(Keys.NumPad8, SWI.Key.NumPad8);
            keyXref.Add(Keys.NumPad9, SWI.Key.NumPad9);


            keyXref.Add(Keys.Tab, SWI.Key.Tab);
            keyXref.Add(Keys.CapsLock, SWI.Key.CapsLock);
            keyXref.Add(Keys.PageUp, SWI.Key.PageUp);
            keyXref.Add(Keys.PageDown, SWI.Key.PageDown);
            keyXref.Add(Keys.End, SWI.Key.End);
            keyXref.Add(Keys.Home, SWI.Key.Home);
            keyXref.Add(Keys.Insert, SWI.Key.Insert);
            keyXref.Add(Keys.Decimal, SWI.Key.Decimal);

            keyXref.Add(Keys.Add, SWI.Key.Add);
            keyXref.Add(Keys.Subtract, SWI.Key.Subtract);
            keyXref.Add(Keys.Multiply, SWI.Key.Multiply);
            keyXref.Add(Keys.Divide, SWI.Key.Divide);

            // These are handled in special cases
            // We'll map em to the "left" keys, but the "right" ones will also be set
            keyXref.Add(Keys.LeftShift, SWI.Key.Shift);
            keyXref.Add(Keys.RightShift, SWI.Key.Shift);
            keyXref.Add(Keys.LeftControl, SWI.Key.Ctrl);
            keyXref.Add(Keys.LeftAlt, SWI.Key.Alt);

        }

        static void PopulatePlatformSpecificKeys()
        {
            PlatformID platform = Environment.OSVersion.Platform;


            if(platform == PlatformID.MacOSX)
            {
                PopulatePlatformspecificKeysForMac();

            }
            else if(platform == PlatformID.Win32NT ||
                platform == PlatformID.Win32S ||
                platform == PlatformID.Win32Windows ||
                platform == PlatformID.WinCE)
            {
                PopulatePlatformspecificKeysForWindows();

            }
            else
            {
                throw new NotImplementedException();
            }
        }

        static void PopulatePlatformspecificKeysForWindows()
        {

            mPlatformSpecificKeys = new Dictionary<int, Keys>();

            mPlatformSpecificKeys.Add(221, Keys.OemCloseBrackets);
            mPlatformSpecificKeys.Add(188, Keys.OemComma);
            mPlatformSpecificKeys.Add(189, Keys.OemMinus);
            mPlatformSpecificKeys.Add(219, Keys.OemOpenBrackets);
            mPlatformSpecificKeys.Add(190, Keys.OemPeriod);
            mPlatformSpecificKeys.Add(220, Keys.OemPipe);
            mPlatformSpecificKeys.Add(187, Keys.OemPlus);
            mPlatformSpecificKeys.Add(191, Keys.OemQuestion);
            mPlatformSpecificKeys.Add(222, Keys.OemQuotes);
            mPlatformSpecificKeys.Add(186, Keys.OemSemicolon);
            mPlatformSpecificKeys.Add(192, Keys.OemTilde);

        }

        static void PopulatePlatformspecificKeysForMac()
        {
            mPlatformSpecificKeys = new Dictionary<int, Keys>();

            mPlatformSpecificKeys.Add(30, Keys.OemCloseBrackets);
            mPlatformSpecificKeys.Add(43, Keys.OemComma);
            mPlatformSpecificKeys.Add(27, Keys.OemMinus);
            mPlatformSpecificKeys.Add(33, Keys.OemOpenBrackets);
            mPlatformSpecificKeys.Add(47, Keys.OemPeriod);
            mPlatformSpecificKeys.Add(42, Keys.OemPipe);
            mPlatformSpecificKeys.Add(24, Keys.OemPlus);
            mPlatformSpecificKeys.Add(44, Keys.OemQuestion);
            mPlatformSpecificKeys.Add(39, Keys.OemQuotes);
            mPlatformSpecificKeys.Add(41, Keys.OemSemicolon);
            mPlatformSpecificKeys.Add(50, Keys.OemTilde);
        }
    }
}