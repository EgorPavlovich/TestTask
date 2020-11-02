using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TestTask_WpfApp
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
            public string Path { get; set; } = string.Empty;

            public List<string> GetAllFiles(string Path)
            {
                List<string> files = Directory.GetFiles(Path).ToList(); // добавляем в возвращаемую коллекцию все файлы в корне каталога
                DirectoryInfo dir_inf = new DirectoryInfo(Path);

                foreach (DirectoryInfo dir in dir_inf.GetDirectories()) // для каждого подкаталога
                {
                    List<string> dirfiles = new List<string>(); //локальная коллекция файлов  
                    try
                    {
                        foreach (var file in dirfiles) //и каждый файл в этом подкаталоге
                        {
                            files.Add(file); // добавляем к возвращаемой коллекции
                        }

                    }
                    catch (UnauthorizedAccessException)
                    {
                        continue;
                    }
                    files.AddRange(GetAllFiles(dir.FullName)); // рекурсия для каждого подкаталога
                }
                return files;
            }

            public void Process(string Path)
            {
                this.Path = Path;
                Console.WriteLine($"Подсчёт суммы значений байт каждого файла в папке '{Path}' и во всех её подпапках: ");
                var AllFiles = GetAllFiles(Path);
                foreach (var f in AllFiles)
                {
                    FileInfo fileInfo = new FileInfo(f); // Тут не нужно проверять, что файл существует
                    // объект для сериализации
                    ProcessedFile processedFile = new ProcessedFile($"Файл: {fileInfo.Name}", $"Полный путь: {f}", $"Сумма значений байт файла: {fileInfo.Length}");
                    SaveToXmlFile(processedFile);
                    Console.WriteLine($"\nФайл: {fileInfo.Name} \nПолный путь: {f} \nСумма значений байт файла: {fileInfo.Length}");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            public void SaveToXmlFile(ProcessedFile processedFile)
            {
                // передача в конструктор типа класса
                XmlSerializer Xmlformatter = new XmlSerializer(typeof(ProcessedFile));

                // получение потока, куда будет записываться сериализованный объект
                using (FileStream fs = new FileStream(Path + @"\Processed files in all subfolders.xml", FileMode.OpenOrCreate))
                {
                    Xmlformatter.Serialize(fs, processedFile);
                }
            }
        }

    }
}
