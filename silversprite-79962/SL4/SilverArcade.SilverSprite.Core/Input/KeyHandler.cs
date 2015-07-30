using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Input
{
    public class KeyHandler
    {
        Dictionary<Key, bool> isPressed = new Dictionary<Key, bool>();
        Dictionary<int, bool> mPlatformKeyCodeDictionary = new Dictionary<int, bool>();

        FrameworkElement targetElement = null;
        public void ClearKeyPresses()
        {
            isPressed.Clear();
            mPlatformKeyCodeDictionary.Clear();
        }

        public KeyHandler(FrameworkElement target)
        {
            ClearKeyPresses();
            targetElement = target;
            target.KeyDown += new KeyEventHandler(target_KeyDown);
            target.KeyUp += new KeyEventHandler(target_KeyUp);
            target.LostFocus += new RoutedEventHandler(target_LostFocus);
        }

        void target_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isPressed.ContainsKey(e.Key))
            {
                isPressed.Add(e.Key, true);
                mPlatformKeyCodeDictionary.Add(e.PlatformKeyCode, true);
            }
        }

        void target_KeyUp(object sender, KeyEventArgs e)
        {
            if (isPressed.ContainsKey(e.Key))
            {
                isPressed.Remove(e.Key);
                mPlatformKeyCodeDictionary.Remove(e.PlatformKeyCode);
            }
        }
            
        void target_LostFocus(object sender, RoutedEventArgs e)
        {
            ClearKeyPresses();            
        }

        public bool IsKeyPressed(Key k)
        {
            return isPressed.ContainsKey(k);
        }

        public bool IsPlatformSpecificKeyPressed(int keyCode)
        {
            return mPlatformKeyCodeDictionary.ContainsKey(keyCode);
        }

        public int GetFirstPlatformKeyPressed()
        {
            if (mPlatformKeyCodeDictionary.Count == 0)
            {
                return -1;
            }
            else
            {
                foreach (KeyValuePair<int, bool> kvp in mPlatformKeyCodeDictionary)
                {
                    return kvp.Key;
                }
            }
            return -1;
        }
    }
}
