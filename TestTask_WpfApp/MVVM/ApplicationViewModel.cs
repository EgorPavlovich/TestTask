using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace TestTask_WpfApp.MVVM
{
    /// <summary>
    /// Класс ApplicationViewModel представляет модель представления
    /// </summary>
    /// <remarks>
    /// Это класс модели представления, через который будут связаны модель Folder и представление MainWindow.xaml.
    /// В этом классе определён список объектов Folder и свойство, которое указывает на выделенный элемент в этом списке.
    /// </remarks>  
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Folder selectedFolder;

        public ObservableCollection<Folder> Folders { get; set; }

        // команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                       (addCommand = new RelayCommand(obj =>
                       {
                           Folder folder = new Folder();
                           Folders.Insert(0, folder);
                           selectedFolder = folder;
                       }));
            }
        }

        public Folder SelectedFolder
        {
            get { return selectedFolder; }
            set
            {
                selectedFolder = value;
                OnPropertyChanged("SelectedFolder");
            }
        }

        public ApplicationViewModel(string fileName, string fullPath, string byteValues)
        {
            Folders = new ObservableCollection<Folder>
            {
                new Folder { FileName = fileName, FullPath = fullPath, ByteValues = byteValues }
            };
        }

        public ApplicationViewModel()
        {
            Folders = new ObservableCollection<Folder>
            {
                new Folder { FileName = @"Microsoft Publisher Document.pub", FullPath = @"D:\Загрузки\Test", ByteValues = "45000" },
                new Folder { FileName = @"Документ Microsoft Word.docx", FullPath = @"D:\Загрузки\Test\test3", ByteValues = "56000" }
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
