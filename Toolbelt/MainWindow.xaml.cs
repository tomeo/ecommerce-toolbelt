using System.Windows;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace Toolbelt
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                    "Yung Lean sucks.",
                    "Toolbelt",
                    MessageBoxButton.OK,
                    MessageBoxImage.Question);
        }
    }
}
