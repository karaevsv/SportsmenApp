using Avalonia.Controls;
using Avalonia.Interactivity;
using SportApp.Classes;

namespace SportApp.Pages
{
    public partial class MenuPage : UserControl
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void dataBtnClick(object? sender, RoutedEventArgs args)
        {
            NavigationSystem.MainFrame.Content = new DataPage();
        }
    }
}
