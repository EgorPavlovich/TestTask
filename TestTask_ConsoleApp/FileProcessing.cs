using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace TestTask_ConsoleApp
{
    public class FileProcessing
    {
        public interface IProcessFiles
        {
            string Path { get; set; }
            void Process(string Path);
            void SaveToXmlFile(ProcessedFile processedFile);
        }

        public class CurrentDirectory : IProcessFiles
        {
            public string Path { get; set; } = string.Empty;

            public void Process(string Path)
            {
                this.Path = Path;
                Console.WriteLine($"Подсчёт суммы значений байт каждого файла в папке '{Path}': ");
                if (Directory.Exists(Path))
                {
                    string[] files = Directory.GetFiles(Path);
                    foreach (string f in files)
                    {
                        FileInfo fileInfo = new FileInfo(f); // Тут не нужно проверять, что файл существует
                        // объект для сериализации
                        ProcessedFile processedFile = new ProcessedFile($"Файл: {fileInfo.Name}", $"Полный путь: {f}",
                            $"Сумма значений байт файла: {fileInfo.Length}");
                        SaveToXmlFile(processedFile);
                        Console.WriteLine(
                            $"\nФайл: {fileInfo.Name} \nПолный путь: {f} \nСумма значений байт файла: {fileInfo.Length}");
                        Console.WriteLine();
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            public void SaveToXmlFile(ProcessedFile processedFile)
            {
                // передача в конструктор типа класса
                XmlSerializer Xmlformatter = new XmlSerializer(typeof(ProcessedFile));

                // получение потока, куда будет записываться сериализованный объект
                using (FileStream fs = new FileStream(Path + @"\Processed files.xml", FileMode.OpenOrCreate))
                {
                    Xmlformatter.Serialize(fs, processedFile);
                }
            }
        }

        public class AllSubfolders : IProcessFiles
        {
            public string Path { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public void Process(string Path)
            {
                throw new NotImplementedException();
            }

            public void SaveToXmlFile(ProcessedFile processedFile)
            {
                throw new NotImplementedException();
            }
        }


    }
}
