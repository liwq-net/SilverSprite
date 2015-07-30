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
using SnakeGame;

namespace SnakeGameSilverSprite
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
            game.AddFont("Becker Black NF", "./Becker Black NF.ttf#Becker Black NF");
        }
    }
}
