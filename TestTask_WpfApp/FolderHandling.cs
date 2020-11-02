using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static TestTask_WpfApp.FileProcessing;

namespace TestTask_WpfApp
{
    public class FolderHandling
    {
        private string Path { get; set; }

        public IProcessFiles Processable { private get; set; }
        public FolderHandling(string Path, IProcessFiles Processable)
        {
            this.Path = Path;
            this.Processable = Processable;
        }

        public void Process()
        {
            new Thread(() =>
                {
                    Processable.Process(Path);
                })
                { IsBackground = true, Priority = ThreadPriority.Highest }.Start();
        }
    }
}