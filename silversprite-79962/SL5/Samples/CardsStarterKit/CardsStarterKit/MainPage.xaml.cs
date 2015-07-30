using System.Windows.Controls;
using System.Windows.Graphics;
using System.Windows;

namespace CardsStarterKit
{
    public partial class MainPage
    {

        public MainPage()
        {
            InitializeComponent();
            Blackjack.BlackjackGame game = new Blackjack.BlackjackGame();
            game.Attach(LayoutRoot);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Check if GPU is on
            if (GraphicsDeviceManager.Current.RenderMode != RenderMode.Hardware)
            {
                MessageBox.Show("Please activate enableGPUAcceleration=true on your Silverlight plugin page.", "Warning", MessageBoxButton.OK);
            }
        }
    }
}
