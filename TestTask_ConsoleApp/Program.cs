using System;

using static TestTask_ConsoleApp.FileProcessing;

namespace TestTask_ConsoleApp
{
    /// <summary>
    /// Тестовое задание.
    /// Задание направлено на оценку уровня квалификации, сроков и возможности реализации задачи.
    /// Условия, помеченные звездочкой(*) не обязательные, но будут плюсом. 
    /// </summary>
    /// <remarks>
    /// Необходимо реализовать программу для подсчёта суммы значений байт каждого файла в папке.
    /// Программа должна иметь возможность задать/выбрать папку для подсчёта.
    /// Подсчёт суммы должен выполняться не в контексте основного потока.
    /// Результат подсчёта должен быть сохранен в эту же папку в виде xml-файла с указанием имени каждого файла и его суммы байт.
    /// Программа должна быть способна обработать файлы, размер которых значительно превышает доступную оперативную память.
    /// <list type="bullet">
    /// <item>
    /// <description>* По возможности максимально использовать все ядра процессора.</description>
    /// </item>
    /// <item>
    /// <description>* Результаты подсчётов должны выводиться на экран по мере получения результатов.</description>
    /// </item>  
    /// <item>
    /// <description>* Обрабатывать все файлы во всех подпапках.</description>
    /// </item>
    /// </list>
    /// Срок реализации - 5 дней
    /// </remarks>
    /// <summary>
    /// Тестовое задание
    /// </summary> 
    class Program
    {
        static void Main(string[] args)
        {
            //Folder folder = new Folder(@"D:\Загрузки\Test", new CurrentDirectory());
            //folder.Process();

            //folder.Processable = new AllSubfolders();
            //folder.Process();

            try
            {
                string Path = string.Empty;
                string Method = string.Empty;

                Console.Write("Введите папку для подсчёта суммы значений байт каждого файла: ");
                Path = Console.ReadLine();

                Console.Write("Введите метод подсчёта (--current или --all): ");
                Method = Console.ReadLine();

                if (Method == "--current")
                {
                    Folder folder = new Folder(Path, new CurrentDirectory());
                    folder.Process();
                }

                if (Method == "--all")
                {
                    Folder folder = new Folder(Path, new AllSubfolders());
                    folder.Process();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}
