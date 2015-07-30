using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Xna.Framework;

namespace SilverArcade.SilverSprite.Tests
{
    public partial class Page : UserControl
    {
        Game _currentTest = null;

        public Page()
        {
            InitializeComponent();
        }

        private void btnTextTests_Click(object sender, RoutedEventArgs e)
        {
            if (_currentTest != null)
            {
                _currentTest.Exit();
                ContentHolder.Children.Remove(_currentTest);
            }

            _currentTest = new TestApps.DrawStrings();

            ContentHolder.Children.Add(_currentTest);
        }

        private void btnTexturesTests_Click(object sender, RoutedEventArgs e)
        {
            if (_currentTest != null)
            {
                _currentTest.Exit();
                ContentHolder.Children.Remove(_currentTest);
            }

            _currentTest = new TestApps.DrawTextures();

            ContentHolder.Children.Add(_currentTest);
        }

        private void btnSoundTests_Click(object sender, RoutedEventArgs e)
        {
            if (_currentTest != null)
            {
                _currentTest.Exit();
                ContentHolder.Children.Remove(_currentTest);
            }

            _currentTest = new TestApps.SoundEffects();

            ContentHolder.Children.Add(_currentTest);

        }

        private void btnSpriteBatch_Click(object sender, RoutedEventArgs e)
        {
            if (_currentTest != null)
            {
                _currentTest.Exit();
                ContentHolder.Children.Remove(_currentTest);
            }

            _currentTest = new TestApps.SimpleSpriteBatch();

            ContentHolder.Children.Add(_currentTest);
        }

        private void btnKeyboardTests_Click(object sender, RoutedEventArgs e)
        {
            if (_currentTest != null)
            {
                _currentTest.Exit();
                ContentHolder.Children.Remove(_currentTest);
            }

            _currentTest = new TestApps.KeyHandling();

            ContentHolder.Children.Add(_currentTest);
        }

        private void btnSingleDGC_Click(object sender, RoutedEventArgs e)
        {
            if (_currentTest != null)
            {
                _currentTest.Exit();
                ContentHolder.Children.Remove(_currentTest);
            }

            _currentTest = new TestApps.SingleGameComponent();

            ContentHolder.Children.Add(_currentTest);
        }

        private void btnOrderDGC_Click(object sender, RoutedEventArgs e)
        {
            if (_currentTest != null)
            {
                _currentTest.Exit();
                ContentHolder.Children.Remove(_currentTest);
            }

            _currentTest = new TestApps.DrawOrderTests();

            ContentHolder.Children.Add(_currentTest);
        }

        private void btnStartupSequencing_Click(object sender, RoutedEventArgs e)
        {
            if (_currentTest != null)
            {
                _currentTest.Exit();
                ContentHolder.Children.Remove(_currentTest);
            }

            _currentTest = new TestApps.StartupSequence();

            ContentHolder.Children.Add(_currentTest);
        }

        private void btnKeyboardMappings_Click(object sender, RoutedEventArgs e)
        {
            if (_currentTest is TestApps.GamePadMappings)
                return;

            if (_currentTest != null)
            {
                _currentTest.Exit();
                ContentHolder.Children.Remove(_currentTest);
            }

            _currentTest = new TestApps.GamePadMappings();

            ContentHolder.Children.Add(_currentTest);
        }

		private void btnViewport_Click(object sender, RoutedEventArgs e)
		{
			if (_currentTest is TestApps.ViewportTransformTests)
				return;

			if (_currentTest != null)
			{
				_currentTest.Exit();
				ContentHolder.Children.Remove(_currentTest);
			}

			_currentTest = new TestApps.ViewportTransformTests();

			ContentHolder.Children.Add(_currentTest);
		}

        private void btnGraphicsStress_Click(object sender, RoutedEventArgs e)
        {
            if (_currentTest is TestApps.GraphicsStressTest)
                return;

            if (_currentTest != null)
            {
                _currentTest.Exit();
                ContentHolder.Children.Remove(_currentTest);
            }

            _currentTest = new TestApps.GraphicsStressTest();

            ContentHolder.Children.Add(_currentTest);
        }
    }
}
