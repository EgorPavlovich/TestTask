using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TestTask_WpfApp
{
    [Serializable]
    [DataContract]
    public class ProcessedFile // Класс для сериализации
    {
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public string FullPath { get; set; }
        [DataMember]
        public string ByteValues { get; set; }

        public ProcessedFile() { } // Конструктор по умолчанию (нужен для корректной сериализации)

        public ProcessedFile(string FileName, string FullPath, string ByteValues)
        {
            this.FileName = FileName;
            this.FullPath = FullPath;
            this.ByteValues = ByteValues;
        }
    }
}
