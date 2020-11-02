using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using  System.Windows.Forms;

using TestTask_WpfApp.MVVM;

namespace TestTask_WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ApplicationViewModel();
        }

        private void CountingFolder_OnClick(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog folderBrowser = new OpenFileDialog();
            //// Set validate names and check file exists to false otherwise windows will
            //// not let you select "Folder Selection."
            //folderBrowser.ValidateNames = false;
            //folderBrowser.CheckFileExists = false;
            //folderBrowser.CheckPathExists = true;
            //// Always default to Folder Selection.
            //folderBrowser.FileName = "Выбор папки";
            //if (folderBrowser.ShowDialog() == DialogResult.HasValue)
            //{
            //    string folderPath = folderBrowser.InitialDirectory;
            //    MessageBox.Show("fileContent", "File Content at path: " + folderPath, MessageBoxButton.OK);
            //    Debugger.Log(0, "", $"{folderPath}.\n");
            //    //MessageBox.Show()
            //    //string folderPath = Path.GetFlowDirection() folderBrowser
            //    //Debugger.Log(0, "", $"{folderPath}.\n");
            //    //string folderPath = Path.GetFlowDirection(folderBrowser.FileName);//GetDirectoryName
            //    // ...

            //}
        }
    }
}
