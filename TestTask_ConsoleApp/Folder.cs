using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using static TestTask_ConsoleApp.FileProcessing;

namespace TestTask_ConsoleApp
{
    public class Folder
    {
        private string Path { get; set; }

        public IProcessFiles Processable { private get; set; }
        public Folder(string Path, IProcessFiles Processable)
        {
            this.Path = Path;
            this.Processable = Processable;
        }

        public void Process()
        {
            Task.Run(() =>
            {
                Processable.Process(Path);
            });
        }
    }
}
