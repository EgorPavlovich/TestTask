using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask_ConsoleApp
{
    public class FileProcessing
    {
        public interface IProcessFiles
        {
            string Path { get; set; }
            void Process(string Path);
            void SaveToXmlFile();
        }

    }
}
