using Avalonia.Controls;
using Avalonia.Interactivity;
using MessageBox.Avalonia;
using SportApp.Classes;
using System;

namespace SportApp.Pages
{
    public partial class SportsmanEdit : UserControl
    {
        private bool isAdd = true;
        public SportsmanEdit(Sportsman sportsman)
        {
            InitializeComponent();
            GenderCb.Items = DataStorage.Gender;
            if (sportsman == null)
            {
                DataContext = new Sportsman();
                GenderCb.SelectedIndex = 0;
            }
            else
            {
                isAdd = false;
                DataContext = sportsman;
            }
        }

        public SportsmanEdit()
        {
            InitializeComponent();          
        }

        private void okBtnClick(object? sender, RoutedEventArgs args)
        {
            if (String.IsNullOrEmpty(NameTb.Text))
            {
                Helper.ShowInfo("Не заполнено имя.");
                return;
            }

            try
            {
                var sportsman = (Sportsman)DataContext;
                if (isAdd)
                {
                    DataStorage.Sportsmen.Add(sportsman);
                }
                NavigationSystem.MainFrame.Content = new DataPage();
            }
            catch (Exception ex)
            {
                Helper.ShowError("Вы не заполнили необходимые поля");
            }
        }

        private void backBtnClick(object? sender, RoutedEventArgs args)
        {
            NavigationSystem.MainFrame.Content = new DataPage();
        }
    }
}
