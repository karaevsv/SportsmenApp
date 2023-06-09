using Avalonia.Controls;
using MessageBox.Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Classes
{
    public static class Helper
    {
        public static void ShowError(string message)
        {
            MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", message,
                    MessageBox.Avalonia.Enums.ButtonEnum.Ok, 
                    MessageBox.Avalonia.Enums.Icon.Error, 
                    WindowStartupLocation.CenterScreen).Show();
        }

        public static void ShowInfo(string message)
        {
            MessageBoxManager.GetMessageBoxStandardWindow("Информация", message,
                    MessageBox.Avalonia.Enums.ButtonEnum.Ok,
                    MessageBox.Avalonia.Enums.Icon.Info,
                    WindowStartupLocation.CenterScreen).Show();
        }
    }
}
