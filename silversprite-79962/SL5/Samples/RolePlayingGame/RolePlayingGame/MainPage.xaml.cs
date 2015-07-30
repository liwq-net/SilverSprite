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

namespace RolePlaying
{
    public partial class MainPage : UserControl
    {
        RolePlayingGame game;

        public MainPage()
        {
            InitializeComponent();
            game = new RolePlayingGame();
            game.Attach(LayoutRoot);
        }
    }
}
