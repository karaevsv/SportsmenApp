using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Skia.Helpers;
using MessageBox.Avalonia;
using SportApp.Classes;

namespace SportApp.Pages
{
    public partial class DataPage : UserControl
    {
        public DataPage()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            SportsmanDG.Items = DataStorage.Sportsmen;
        }

        private void backBtnClick(object? sender, RoutedEventArgs args)
        {
            NavigationSystem.MainFrame.Content = new MenuPage();
        }

        private void addSportsmanBtnClick(object? sender, RoutedEventArgs args)
        {
            NavigationSystem.MainFrame.Content = new SportsmanEdit(null);
        }

        private void editSportsmanBtnClick(object? sender, RoutedEventArgs args)
        {
            var selectedSportsman = (Sportsman)SportsmanDG.SelectedItem;
            if (selectedSportsman == null)
            {
                Helper.ShowInfo("Выберите спортсмена");
                return; 
            }
            NavigationSystem.MainFrame.Content = new SportsmanEdit(selectedSportsman);
        }

        private async void deleteSportsmanBtnClick(object? sender, RoutedEventArgs args)
        {
            var selectedSportsman = (Sportsman)SportsmanDG.SelectedItem;
            if (selectedSportsman == null)
            {
                Helper.ShowInfo("Выберите спортсмена");
                return;
            }
            var answer = await MessageBoxManager.GetMessageBoxStandardWindow("Вопрос", "Вы уверены?",
                MessageBox.Avalonia.Enums.ButtonEnum.YesNo, MessageBox.Avalonia.Enums.Icon.Question).Show();
            if (answer == MessageBox.Avalonia.Enums.ButtonResult.Yes)
            {
                DataStorage.Sportsmen.Remove(selectedSportsman);
            }
        }
    }
}
