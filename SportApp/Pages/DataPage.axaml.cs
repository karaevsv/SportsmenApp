using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Skia.Helpers;
using MessageBox.Avalonia;
using SportApp.Classes;
using System.Collections.Generic;

namespace SportApp.Pages
{
    public partial class DataPage : UserControl
    {
        public DataPage()
        {
            InitializeComponent();
            loadData();
        }

        private void searchTbKeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            if (string.IsNullOrEmpty(SearchTb.Text))
            {
                SportsmanDG.Items = DataStorage.Sportsmen;
            }
            else
            {
                var filteredSportsmen = new List<Sportsman>();
                foreach (var el in DataStorage.Sportsmen)
                {
                    if (el.Name.Contains(SearchTb.Text))
                    {
                        filteredSportsmen.Add(el);
                    }
                }
                SportsmanDG.Items = filteredSportsmen;
            }
            
            
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
                Helper.ShowInfo("�������� ����������");
                return; 
            }
            NavigationSystem.MainFrame.Content = new SportsmanEdit(selectedSportsman);
        }

        private async void deleteSportsmanBtnClick(object? sender, RoutedEventArgs args)
        {
            var selectedSportsman = (Sportsman)SportsmanDG.SelectedItem;
            if (selectedSportsman == null)
            {
                Helper.ShowInfo("�������� ����������");
                return;
            }
            var answer = await MessageBoxManager.GetMessageBoxStandardWindow("������", "�� �������?",
                MessageBox.Avalonia.Enums.ButtonEnum.YesNo, MessageBox.Avalonia.Enums.Icon.Question).Show();
            if (answer == MessageBox.Avalonia.Enums.ButtonResult.Yes)
            {
                DataStorage.Sportsmen.Remove(selectedSportsman);
            }
        }
    }
}
