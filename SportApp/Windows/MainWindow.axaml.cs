using Avalonia.Controls;
using Avalonia.Interactivity;
using SportApp.Classes;
using SportApp.Pages;
using System;

namespace SportApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigationSystem.MainFrame = MainFrame;
            MainFrame.Content = new MenuPage();
            initializeDataStorage();
        }

        private void initializeDataStorage()
        {
            DataStorage.Sportsmen.Add(new Sportsman()
            {
                BirthDate = DateTime.Parse("13.04.1992"),
                Gender = "Женский",
                Name = "Иванова"
            });
            DataStorage.Sportsmen.Add(new Sportsman()
            {
                BirthDate = DateTime.Parse("24.12.2003"),
                Gender = "Мужской",
                Name = "Иванов"
            });
        }

        private void exitBtnClick(object? sender, RoutedEventArgs args)
        {
            Close();
        }
    }
}