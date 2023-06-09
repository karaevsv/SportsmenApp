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
            if (sportsman == null)
            {
                DataContext = new Sportsman();
                GenderCb.SelectedIndex = 0;
            }
            else
            {
                isAdd = false;
                DataContext = sportsman;
                GenderCb.SelectedIndex = (sportsman.Gender == "�������") ? 0 : 1;
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
                Helper.ShowInfo("�� ��������� ���.");
                return;
            }

            try
            {
                var sportsman = (Sportsman)DataContext;
                sportsman.Gender = ((ComboBoxItem)GenderCb.SelectedItem).Content.ToString();
                if (isAdd)
                {
                    DataStorage.Sportsmen.Add(sportsman);
                }
                NavigationSystem.MainFrame.Content = new DataPage();
            }
            catch (Exception ex)
            {
                Helper.ShowError("�� �� ��������� ����������� ����");
            }
        }

        private void backBtnClick(object? sender, RoutedEventArgs args)
        {
            NavigationSystem.MainFrame.Content = new DataPage();
        }
    }
}
