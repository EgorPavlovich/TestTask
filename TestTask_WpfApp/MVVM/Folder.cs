using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestTask_WpfApp.MVVM
{
    /// <summary>
    /// Класс Folder представляет модель приложения
    /// </summary>
    public class Folder : INotifyPropertyChanged
    {
        private string fileName;
        private string fullPath;
        private string byteValues;

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                OnPropertyChanged("FileName"); // Путь к папке: 
            }
        }
        public string FullPath
        {
            get { return fullPath; }
            set
            {
                fullPath = value;
                OnPropertyChanged("FullPath"); // Количество файлов в папке: 
            }
        }

        public string ByteValues
        {
            get { return byteValues; }
            set
            {
                byteValues = value;
                OnPropertyChanged("ByteValues"); // Сумма значений байт файла в папке:
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
