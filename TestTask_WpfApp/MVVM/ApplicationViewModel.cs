using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace TestTask_WpfApp.MVVM
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Folder selectedFolder;

        public ObservableCollection<Folder> Folders { get; set; }
        public Folder SelectedFolder
        {
            get { return selectedFolder; }
            set
            {
                selectedFolder = value;
                OnPropertyChanged("SelectedFolder");
            }
        }

        public ApplicationViewModel()
        {
            Folders = new ObservableCollection<Folder>
            {
                new Folder { Path = @"D:\", Quantity = 1, SumOfByte = 56000 },
                new Folder { Path = @"C:\", Quantity = 1, SumOfByte = 34000 },
                new Folder { Path = @"C:\", Quantity = 1, SumOfByte = 66000 },
                new Folder { Path = @"D:\", Quantity = 1, SumOfByte = 88000 },
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
