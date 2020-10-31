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
        private string path;
        private int quantity;
        private float sumOfByte;

        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                OnPropertyChanged("Path"); // Путь к папке: 
            }
        }
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged("Quantity"); // Количество файлов в папке: 
            }
        }

        public float SumOfByte
        {
            get { return sumOfByte; }
            set
            {
                sumOfByte = value;
                OnPropertyChanged("SumOfByte"); // Сумма значений байт файла в папке:
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
