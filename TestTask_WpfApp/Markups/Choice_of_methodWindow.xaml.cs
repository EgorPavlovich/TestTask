using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using static TestTask_WpfApp.FileProcessing;

namespace TestTask_WpfApp.Markups
{
    /// <summary>
    /// Логика взаимодействия для Choice_of_methodWindow.xaml
    /// </summary>
    public partial class Choice_of_methodWindow : Window
    {
        public Choice_of_methodWindow()
        {
            InitializeComponent();
        }

        private void ButtonAccept_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.Method == "--current")
                {
                    FolderHandling folder = new FolderHandling(MainWindow.path, new CurrentDirectory());
                    folder.Process();
                    MainWindow.methodWindow.Close();
                }

                if (MainWindow.Method == "--all")
                {
                    FolderHandling folder = new FolderHandling(MainWindow.path, new AllSubfolders());
                    folder.Process();
                    MainWindow.methodWindow.Close();
                }
            }
            catch (Exception ex)
            {
                // Отловленная ошибка появится в окне вывода Visual Studio.
                Debugger.Log(0, "", $"Ошибка в методе-обработчике события ButtonAccept_OnClick. Ошибка: {ex}");
                LogErrorAsync(ex);
            }
        }

        private void ToggleButton1_OnChecked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            if ((bool)pressed.IsChecked)
            {
                MainWindow.Method = "--current";
            }
        }

        private void ToggleButton2_OnChecked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            if ((bool)pressed.IsChecked)
            {
                MainWindow.Method = "--all";
            }
        }

        public async Task LogErrorAsync(Exception ex)
        {
            // Отловленная ошибка запишется в файл LOG.txt прямо в рабочей папке
            await System.Threading.Tasks.Task.Run(() =>
            {
                string p = MainWindow.path + @"\LOG.txt";
                try
                {
                    using (StreamWriter sw = new StreamWriter(p, true, Encoding.Default))
                    {
                        sw.WriteLine($"{ex} - {DateTime.Now}\n");
                    }
                }
                catch { }
            });
        }

    }
}
